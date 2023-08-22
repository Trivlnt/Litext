using Litext;
using SimpplIDE;

static class Program
{
    [STAThread]
    static void Main(string[] args)
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);

        if (args.Length > 0)
        {
            string filePath = args[0];
            FilesManager.Instance.SetFilePath(filePath);

            Application.Run(new mainForm(filePath));
        }
        else
        {
            Application.Run(new mainForm());
        }
    }
}
