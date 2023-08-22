using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Litext;
using Litext.src.utils;
using Newtonsoft.Json;

namespace SimpplIDE
{
    public partial class mainForm : Form
    {
        public mainForm(string filePath = null)
        {
            InitializeComponent();

            if (!string.IsNullOrEmpty(filePath) && File.Exists(filePath))
            {
                SetInput(OpenFile(filePath));
                UpdateTitle(filePath);
            }

            UpdateTerminalInfo();
            Print("");

            SyntaxHighlight.Instance.LoadKeywordColors();
        }

        public void SetInput(string input)
        {
            mainInput.Text = input;
        }

        /// <summary>
        /// Will update the text by adding a blank character, refreshing the syntax colors.
        /// This will not effect the base text content.
        /// </summary>
        public void RefreshInput()
        {
            mainInput.Text += "";
        }

        public string GetFilePath()
        {
            return FilesManager.Instance.GetFilePath();
        }

        void NewFile()
        {
            tabPage1.Text = "untitled";
            SetInput("");
            Print("New file created!");
            UpdateTerminalInfo();
            UpdateTitle("untitled");
        }

        private string OpenFile(string filePath)
        {
            return FilesManager.Instance.OpenFile(filePath);
        }

        void UpdateTitle(string filePath)
        {
            tabPages.SelectedTab.Text = Path.GetFileName(GetFilePath());
            Text = $"Litext - {GetFilePath()}";
        }

        private void Form1Dark_FormClosing(object sender, FormClosingEventArgs e)
        {
            SyntaxHighlight.Instance.SaveKeywordColorsToFile("codecolors.json");
        }

        private void mainInput_TextChanged(object sender, EventArgs e)
        {
            UpdateTerminalInfo();

            SyntaxHighlight.Instance.ColorizeKeywords(mainInput);
        }

        void UpdateTerminalInfo()
        {
            terminalInfoLabel.Text = $"{(int)(mainInput.ZoomFactor * 100f)} % lines: {mainInput.Lines.Length.ToString()}";
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetInput(OpenFile(FilesManager.Instance.GetFilePath()));
            UpdateTitle(FilesManager.Instance.GetFilePath());

        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewFile();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FilesManager.Instance.SaveFile(mainInput.Text);
        }

        public void Print(string msg)
        {
            terminalOutput.Text += msg + "\n";
        }


        private void resetColorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to reset the Text Highlighting colors to default?", "Atention", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                SyntaxHighlight.Instance.LoadDefaultKeywordColors();
                SyntaxHighlight.Instance.SaveKeywordColorsToFile(SyntaxHighlight.Instance.GetConfigFile());

                RefreshInput();
            }
        }


        private void editColorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("You want to save your file first?", "Litext", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                FilesManager.Instance.SaveFile(mainInput.Text);

            }

            SetInput(OpenFile(SyntaxHighlight.Instance.GetConfigFile()));
        }

        private void newToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(mainInput.Text))
            {
                if (MessageBox.Show("Do you want to save your changes?", "Litext", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    FilesManager.Instance.SaveFile(mainInput.Text);
                }
            }

            NewFile();

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new About().Show();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FilesManager.Instance.SaveFile(mainInput.Text);
        }

        private void blankToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewFile();
        }

        private void pythonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewFile();
            SetInput("print(\"Hello, World!\");");
        }

        private void hTMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewFile();
            SetInput("<!DOCTYPE html>\n<html lang=\"en\">\n<head>\n" +
                "     <meta charset=\"UTF-8\">\n     <meta name=\"viewport\" " +
                "content=\"width=device-width, initial-scale=1.0\">\n     " +
                "<title>Document</title>\n</head>\n<body>\n/body>\n</html>");
        }
    }


}
