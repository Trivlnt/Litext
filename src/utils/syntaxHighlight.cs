using Newtonsoft.Json;
using SimpplIDE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Litext.src.utils
{
    internal class SyntaxHighlight
    {
        private static SyntaxHighlight instance;

        private SyntaxHighlight() { }

        public static SyntaxHighlight Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SyntaxHighlight();
                }
                return instance;
            }
        }

        private Dictionary<string, Color> keywordColors = new Dictionary<string, Color>();

        string configFolderPath;
        string configFile;

        public string GetConfigFolderPath() { return  configFolderPath; }
        public string GetConfigFile() { return configFile; }

        public void LoadDefaultKeywordColors()
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

                { "print", Color.BlueViolet },
                { "Console", Color.BlueViolet },
                { "Debug", Color.BlueViolet },

                { "Rigidbody2D", Color.LightGreen },
                { "Rigidbody", Color.LightGreen },
                { "Input", Color.LightGreen },
                { "Vector2", Color.LightGreen },
                { "Vector3", Color.LightGreen },
                { "Transform", Color.LightGreen },
                { "GameObject", Color.LightGreen },
                { "Camera", Color.LightGreen },
                { "Physics", Color.LightGreen },
                { "Physics2D", Color.LightGreen },

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
                { "<title>", Color.Yellow }, { "</title>", Color.Yellow },
                { "<a>", Color.Yellow }, { "</a>", Color.Yellow }, { "<a", Color.Yellow },
                { "href", Color.Cyan }, { "\">", Color.Yellow },

                { "<p", Color.Yellow }, { "<p>", Color.Yellow }, { "</p>", Color.Yellow },
                { "<h1", Color.Yellow }, { "<h1>", Color.Yellow }, { "</h1>", Color.Yellow },
                { "<h2", Color.Yellow }, { "<h2>", Color.Yellow }, { "</h2>", Color.Yellow },

                { "<img", Color.LightYellow },
            };
        }

        public void LoadKeywordColors()
        {
            configFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config");
            configFile = Path.Combine(configFolderPath, "codecolors.json");

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

        public void SaveKeywordColorsToFile(string filePath)
        {
            KeywordConfig config = new KeywordConfig
            {
                KeywordColors = keywordColors.ToDictionary(kv => kv.Key, kv => ColorTranslator.ToHtml(kv.Value))
            };

            SaveKeywordConfig(config, filePath);
        }

        public void SaveKeywordConfig(KeywordConfig config, string filePath)
        {
            string json = JsonConvert.SerializeObject(config, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }

        public class KeywordConfig
        {
            public Dictionary<string, string> KeywordColors { get; set; }
        }

        public RichTextBox ColorizeKeywords(RichTextBox input)
        {
            int originalSelectionStart = input.SelectionStart;
            int originalSelectionLength = input.SelectionLength;
            Color originalSelectionColor = input.SelectionColor;

            input.SelectionStart = 0;
            input.SelectionLength = input.TextLength;
            input.SelectionColor = input.ForeColor;

            foreach (var keyword in keywordColors.Keys)
            {
                int index = 0;
                while (index < input.TextLength)
                {
                    index = input.Text.IndexOf(keyword, index);

                    if (index == -1)
                        break;

                    bool isWholeWord = IsWholeWord(input.Text, index, keyword.Length);

                    if (isWholeWord)
                    {
                        input.SelectionStart = index;
                        input.SelectionLength = keyword.Length;
                        input.SelectionColor = keywordColors[keyword];
                    }

                    index += keyword.Length;
                }
            }

            input.SelectionStart = originalSelectionStart;
            input.SelectionLength = originalSelectionLength;
            input.SelectionColor = originalSelectionColor;

            return input;
        }

        private bool IsWholeWord(string text, int startIndex, int length)
        {
            if (startIndex > 0 && char.IsLetterOrDigit(text[startIndex - 1]))
                return false;

            if (startIndex + length < text.Length && char.IsLetterOrDigit(text[startIndex + length]))
                return false;

            return true;
        }
    }
}
