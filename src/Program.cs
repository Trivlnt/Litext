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
            // Se houver argumentos, o primeiro argumento é o caminho do arquivo
            string filePath = args[0];

            Application.Run(new mainForm(filePath));
        }
        else
        {
            Application.Run(new mainForm());
        }
    }
}
