namespace Litext
{
    internal class FilesManager
    {
        private static FilesManager instance;
        private string filePath;
        public List<string> files = new List<string>();
        private List<string> fileTexts = new List<string>();

        private FilesManager() { }

        public static FilesManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new FilesManager();
                }
                return instance;
            }
        }

        public string GetFilePath() { return filePath; }
        public void SetFilePath(string newFilePath) { filePath = newFilePath; }

        public string OpenFile(string filePathToOpen)
        {
            if (string.IsNullOrEmpty(filePathToOpen))
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    SetFilePath(openFileDialog.FileName);

                    try
                    {

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error reading the file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return "";
                    }
                }
            }
            string fileContent = File.ReadAllText(GetFilePath());

            return fileContent;
        }

        public void SaveFile(string textToSave)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Text Files|*.txt|All files|*.*";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = saveFileDialog.FileName;
                }
            }

            if (string.IsNullOrEmpty(filePath)) { return; }

            File.WriteAllText(filePath, textToSave);

        }


    }
}
