﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace SimpplIDE
{
    public partial class mainForm : Form
    {
        private Dictionary<string, Color> keywordColors = new Dictionary<string, Color>();

        string filePath;

        public List<string> files = new List<string>();
        private List<string> fileTexts = new List<string>();

        string configFolderPath;
        string configFile;

        public mainForm(string filePath = null)
        {
            configFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config");
            configFile = Path.Combine(configFolderPath, "codecolors.json");

            InitializeComponent();
            LoadKeywordColors();

            terminalOutput.Text = string.Empty;
            //mainInput.TextChanged += mainInput_TextChanged;
            //tabPages.SelectedIndexChanged += tabPages_SelectedIndexChanged;

            this.filePath = filePath;



            Debug.Write("a");
            if (!string.IsNullOrEmpty(filePath) && File.Exists(filePath))
            {
                OpenFile(filePath);
            }

            UpdateTerminalInfo();
        }

        void NewFile()
        {
            tabPage1.Text = "untitled";
            mainInput.Text = string.Empty;
            Print("New file created!");
            UpdateTerminalInfo();
            UpdateTitle("untitled");
        }

        private void OpenFile(string filePath)
        {

            if (filePath == null || filePath == "")
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;

                    try
                    {

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error reading the file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            string fileContent = File.ReadAllText(filePath);
            mainInput.Text = fileContent;

            files.Add(filePath);
            fileTexts.Add(mainInput.Text);

            bool removeLater = true;
            tabPages.SelectedTab.Text = Path.GetFileName(filePath);
            UpdateTitle(filePath);

            if (!removeLater)
            {
                TabPage tabPage = new TabPage(Path.GetFileName(filePath));
                tabPages.TabPages.Add(tabPage);

                tabPage.Controls.Add(mainInput);

                TextBox textBox = new TextBox();
                tabPage.Controls.Add(textBox);
                textBox.Dock = DockStyle.Fill;
                textBox.Multiline = true;
                textBox.ScrollBars = ScrollBars.Both;
                textBox.Text = mainInput.Text;


                tabPages.SelectedTab = tabPage;
            }

            UpdateTerminalInfo();

        }

        void UpdateTitle(string filePath)
        {
            tabPages.SelectedTab.Text = Path.GetFileName(filePath);
            Text = $"Litext - {filePath}";
        }


        private void LoadKeywordColors()
        {
            Directory.CreateDirectory(configFolderPath);

            if (File.Exists(configFile))
            {
                string json = File.ReadAllText(configFile);
                KeywordConfig config = JsonConvert.DeserializeObject<KeywordConfig>(json);

                foreach (var keywordColor in config.KeywordColors)
                {
                    if (ColorTranslator.FromHtml(keywordColor.Value) is Color color)
                    {
                        keywordColors[keywordColor.Key] = color;
                    }
                }
            }
            else
            {
                LoadDefaultKeywordColors();
                SaveKeywordColorsToFile(configFile);
            }
        }

        private void LoadDefaultKeywordColors()
        {
            keywordColors = new Dictionary<string, Color>
            {
                { "using", Color.DarkCyan },
                { "public", Color.DarkCyan },
                { "private", Color.DarkCyan },
                { "static", Color.DarkCyan },
                { "class", Color.DarkCyan },
                { "namespace", Color.DarkCyan },
                { "new", Color.DarkCyan },

                { "void", Color.LightGreen },
                { "int", Color.LightGreen },
                { "string", Color.LightGreen },
                { "float", Color.LightGreen },
                { "bool", Color.LightGreen },

                { "if", Color.Pink },
                { "return", Color.Pink },
                { "break", Color.Pink },
                { "else", Color.Pink },
                { "else if", Color.Pink },
                { "switch", Color.Pink },
                { "case", Color.Pink },
                { "for", Color.Pink },
                { "foreach", Color.Pink },

                { "'", Color.Orange },
                { "\"", Color.Orange },
                { ";", Color.Orange },
                { ":", Color.Orange },

                { ",", Color.LightSkyBlue },
                { "=", Color.LightSkyBlue },
                { "==", Color.LightSkyBlue },
                { "&&", Color.LightSkyBlue },
                { "||", Color.LightSkyBlue },
                { "<", Color.LightSkyBlue },
                { ">", Color.LightSkyBlue },

                { "or", Color.Magenta },

                { "true", Color.DeepSkyBlue },
                { "false", Color.DeepSkyBlue },
                { "null", Color.DeepSkyBlue },

                { "//", Color.Green },

                { "<html>", Color.Yellow }, { "</html>", Color.Yellow },
                { "<head>", Color.Yellow }, { "</head>", Color.Yellow },
                { "<body>", Color.Yellow }, { "</body>", Color.Yellow },
                { "<title>", Color.LightYellow }, { "</title>", Color.LightYellow },

                { "<p", Color.Yellow }, { "<p>", Color.Yellow }, { "</p>", Color.Yellow },
                { "<h1", Color.Yellow }, { "<h1>", Color.Yellow }, { "</h1>", Color.Yellow },
                { "<h2", Color.Yellow }, { "<h2>", Color.Yellow }, { "</h2>", Color.Yellow },

                { "<img", Color.LightYellow },
            };
        }

        private void SaveKeywordColorsToFile(string filePath)
        {
            KeywordConfig config = new KeywordConfig
            {
                KeywordColors = keywordColors.ToDictionary(kv => kv.Key, kv => ColorTranslator.ToHtml(kv.Value))
            };

            SaveKeywordConfig(config, filePath);
        }

        private void SaveKeywordConfig(KeywordConfig config, string filePath)
        {
            string json = JsonConvert.SerializeObject(config, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }

        private void Form1Dark_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveKeywordColorsToFile("codecolors.json");
        }

        private void mainInput_TextChanged(object sender, EventArgs e)
        {
            if (tabPages.SelectedTab != null)
            {
                TextBox selectedTextBox = tabPages.SelectedTab.Controls.OfType<TextBox>().FirstOrDefault();
                if (selectedTextBox != null)
                {
                    selectedTextBox.Text = mainInput.Text;
                }
            }

            UpdateTerminalInfo();

            ColorizeKeywords();
        }

        void UpdateTerminalInfo()
        {
            terminalInfoLabel.Text = $"{(int)(mainInput.ZoomFactor * 100f)} % lines: {mainInput.Lines.Length.ToString()}";
        }

        private void ColorizeKeywords()
        {
            int originalSelectionStart = mainInput.SelectionStart;
            int originalSelectionLength = mainInput.SelectionLength;
            Color originalSelectionColor = mainInput.SelectionColor;

            mainInput.SelectionStart = 0;
            mainInput.SelectionLength = mainInput.TextLength;
            mainInput.SelectionColor = mainInput.ForeColor;

            foreach (var keyword in keywordColors.Keys)
            {
                int index = 0;
                while (index < mainInput.TextLength)
                {
                    index = mainInput.Text.IndexOf(keyword, index);

                    if (index == -1)
                        break;

                    bool isWholeWord = IsWholeWord(mainInput.Text, index, keyword.Length);

                    if (isWholeWord)
                    {
                        mainInput.SelectionStart = index;
                        mainInput.SelectionLength = keyword.Length;
                        mainInput.SelectionColor = keywordColors[keyword];
                    }

                    index += keyword.Length;
                }
            }

            mainInput.SelectionStart = originalSelectionStart;
            mainInput.SelectionLength = originalSelectionLength;
            mainInput.SelectionColor = originalSelectionColor;
        }



        private bool IsWholeWord(string text, int startIndex, int length)
        {
            if (startIndex > 0 && char.IsLetterOrDigit(text[startIndex - 1]))
                return false;

            if (startIndex + length < text.Length && char.IsLetterOrDigit(text[startIndex + length]))
                return false;

            return true;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFile("");
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewFile();
        }



        private void tabPages_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedTabIndex = tabPages.SelectedIndex;

            if (selectedTabIndex >= 0 && selectedTabIndex < files.Count)
            {
                TextBox selectedTextBox = tabPages.SelectedTab.Controls.OfType<TextBox>().FirstOrDefault();
                if (selectedTextBox != null)
                {
                    mainInput.Text = selectedTextBox.Text;
                }
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFile();
        }

        public void SaveFile()
        {
            string textToSave = mainInput.Text;

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text Files|*.txt|All files|*.*";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;

                File.WriteAllText(filePath, textToSave);

                Print("File saved!");
                UpdateTitle(filePath);
            }
        }



        private void resetColors_Click(object sender, EventArgs e)
        {


        }

        public void Print(string msg)
        {
            terminalOutput.Text += msg + "\n";
        }


        private void resetColorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to reset the Text Highlighting colors to default?", "Atention", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                LoadDefaultKeywordColors();
                SaveKeywordColorsToFile(configFile);

                mainInput.Text += "";
            }
        }

        private void editColorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("You want to save your file first?", "Litext", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                SaveFile();

            }

            OpenFile(configFile);
        }

        private void newToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(mainInput.Text))
            {
                if (MessageBox.Show("Do you want to save your changes?", "Litext", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    SaveFile();
                }
            }

            NewFile();

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new About().Show();
        }
    }

    public class KeywordConfig
    {
        public Dictionary<string, string> KeywordColors { get; set; }
    }
}
