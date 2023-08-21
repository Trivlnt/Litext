namespace SimpplIDE
{
    partial class mainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            newToolStripMenuItem = new ToolStripMenuItem();
            blankToolStripMenuItem = new ToolStripMenuItem();
            hTMLToolStripMenuItem = new ToolStripMenuItem();
            pythonToolStripMenuItem = new ToolStripMenuItem();
            openToolStripMenuItem = new ToolStripMenuItem();
            saveToolStripMenuItem = new ToolStripMenuItem();
            saveAsToolStripMenuItem = new ToolStripMenuItem();
            editToolStripMenuItem = new ToolStripMenuItem();
            formatToolStripMenuItem = new ToolStripMenuItem();
            localizeToolStripMenuItem = new ToolStripMenuItem();
            preferencesToolStripMenuItem = new ToolStripMenuItem();
            themeToolStripMenuItem = new ToolStripMenuItem();
            defaultSystemToolStripMenuItem = new ToolStripMenuItem();
            darkToolStripMenuItem = new ToolStripMenuItem();
            lightToolStripMenuItem = new ToolStripMenuItem();
            resetTextHighligthingToolStripMenuItem = new ToolStripMenuItem();
            editColorsToolStripMenuItem = new ToolStripMenuItem();
            resetColorsToolStripMenuItem = new ToolStripMenuItem();
            runToolStripMenuItem = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            terminalInfoLabel = new Label();
            tabPage1 = new TabPage();
            mainInput = new RichTextBox();
            tabPages = new TabControl();
            panel1 = new Panel();
            terminalOutput = new Label();
            menuStrip1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPages.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.FromArgb(50, 50, 50);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, editToolStripMenuItem, formatToolStripMenuItem, localizeToolStripMenuItem, preferencesToolStripMenuItem, runToolStripMenuItem, helpToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(878, 24);
            menuStrip1.TabIndex = 2;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newToolStripMenuItem, openToolStripMenuItem, saveToolStripMenuItem, saveAsToolStripMenuItem });
            fileToolStripMenuItem.ForeColor = SystemColors.Control;
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            newToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { blankToolStripMenuItem, hTMLToolStripMenuItem, pythonToolStripMenuItem });
            newToolStripMenuItem.Name = "newToolStripMenuItem";
            newToolStripMenuItem.Size = new Size(180, 22);
            newToolStripMenuItem.Text = "New";
            newToolStripMenuItem.Click += newToolStripMenuItem_Click_1;
            // 
            // blankToolStripMenuItem
            // 
            blankToolStripMenuItem.Name = "blankToolStripMenuItem";
            blankToolStripMenuItem.Size = new Size(180, 22);
            blankToolStripMenuItem.Text = "Blank";
            blankToolStripMenuItem.Click += blankToolStripMenuItem_Click;
            // 
            // hTMLToolStripMenuItem
            // 
            hTMLToolStripMenuItem.Name = "hTMLToolStripMenuItem";
            hTMLToolStripMenuItem.Size = new Size(180, 22);
            hTMLToolStripMenuItem.Text = "HTML";
            hTMLToolStripMenuItem.Click += hTMLToolStripMenuItem_Click;
            // 
            // pythonToolStripMenuItem
            // 
            pythonToolStripMenuItem.Name = "pythonToolStripMenuItem";
            pythonToolStripMenuItem.Size = new Size(180, 22);
            pythonToolStripMenuItem.Text = "Python";
            pythonToolStripMenuItem.Click += pythonToolStripMenuItem_Click;
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.Size = new Size(180, 22);
            openToolStripMenuItem.Text = "Open";
            openToolStripMenuItem.Click += openToolStripMenuItem_Click;
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new Size(180, 22);
            saveToolStripMenuItem.Text = "Save";
            saveToolStripMenuItem.Click += saveToolStripMenuItem_Click;
            // 
            // saveAsToolStripMenuItem
            // 
            saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            saveAsToolStripMenuItem.Size = new Size(180, 22);
            saveAsToolStripMenuItem.Text = "Save as";
            saveAsToolStripMenuItem.Click += saveAsToolStripMenuItem_Click;
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.ForeColor = SystemColors.Control;
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new Size(39, 20);
            editToolStripMenuItem.Text = "Edit";
            // 
            // formatToolStripMenuItem
            // 
            formatToolStripMenuItem.ForeColor = SystemColors.Control;
            formatToolStripMenuItem.Name = "formatToolStripMenuItem";
            formatToolStripMenuItem.Size = new Size(57, 20);
            formatToolStripMenuItem.Text = "Format";
            // 
            // localizeToolStripMenuItem
            // 
            localizeToolStripMenuItem.ForeColor = SystemColors.Control;
            localizeToolStripMenuItem.Name = "localizeToolStripMenuItem";
            localizeToolStripMenuItem.Size = new Size(42, 20);
            localizeToolStripMenuItem.Text = "Find";
            // 
            // preferencesToolStripMenuItem
            // 
            preferencesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { themeToolStripMenuItem, resetTextHighligthingToolStripMenuItem });
            preferencesToolStripMenuItem.ForeColor = SystemColors.ButtonHighlight;
            preferencesToolStripMenuItem.Name = "preferencesToolStripMenuItem";
            preferencesToolStripMenuItem.Size = new Size(80, 20);
            preferencesToolStripMenuItem.Text = "Preferences";
            // 
            // themeToolStripMenuItem
            // 
            themeToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { defaultSystemToolStripMenuItem, darkToolStripMenuItem, lightToolStripMenuItem });
            themeToolStripMenuItem.Name = "themeToolStripMenuItem";
            themeToolStripMenuItem.Size = new Size(179, 22);
            themeToolStripMenuItem.Text = "Theme";
            // 
            // defaultSystemToolStripMenuItem
            // 
            defaultSystemToolStripMenuItem.Name = "defaultSystemToolStripMenuItem";
            defaultSystemToolStripMenuItem.Size = new Size(161, 22);
            defaultSystemToolStripMenuItem.Text = "Default (System)";
            // 
            // darkToolStripMenuItem
            // 
            darkToolStripMenuItem.Name = "darkToolStripMenuItem";
            darkToolStripMenuItem.Size = new Size(161, 22);
            darkToolStripMenuItem.Text = "Dark";
            // 
            // lightToolStripMenuItem
            // 
            lightToolStripMenuItem.Name = "lightToolStripMenuItem";
            lightToolStripMenuItem.Size = new Size(161, 22);
            lightToolStripMenuItem.Text = "Light";
            // 
            // resetTextHighligthingToolStripMenuItem
            // 
            resetTextHighligthingToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { editColorsToolStripMenuItem, resetColorsToolStripMenuItem });
            resetTextHighligthingToolStripMenuItem.Name = "resetTextHighligthingToolStripMenuItem";
            resetTextHighligthingToolStripMenuItem.Size = new Size(179, 22);
            resetTextHighligthingToolStripMenuItem.Text = "Syntax Highlighting";
            // 
            // editColorsToolStripMenuItem
            // 
            editColorsToolStripMenuItem.Name = "editColorsToolStripMenuItem";
            editColorsToolStripMenuItem.Size = new Size(137, 22);
            editColorsToolStripMenuItem.Text = "Edit colors";
            editColorsToolStripMenuItem.Click += editColorsToolStripMenuItem_Click;
            // 
            // resetColorsToolStripMenuItem
            // 
            resetColorsToolStripMenuItem.Name = "resetColorsToolStripMenuItem";
            resetColorsToolStripMenuItem.Size = new Size(137, 22);
            resetColorsToolStripMenuItem.Text = "Reset colors";
            resetColorsToolStripMenuItem.Click += resetColorsToolStripMenuItem_Click;
            // 
            // runToolStripMenuItem
            // 
            runToolStripMenuItem.ForeColor = SystemColors.Control;
            runToolStripMenuItem.Name = "runToolStripMenuItem";
            runToolStripMenuItem.Size = new Size(40, 20);
            runToolStripMenuItem.Text = "Run";
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { aboutToolStripMenuItem });
            helpToolStripMenuItem.ForeColor = SystemColors.Control;
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(44, 20);
            helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(107, 22);
            aboutToolStripMenuItem.Text = "About";
            aboutToolStripMenuItem.Click += aboutToolStripMenuItem_Click;
            // 
            // terminalInfoLabel
            // 
            terminalInfoLabel.AutoSize = true;
            terminalInfoLabel.Dock = DockStyle.Right;
            terminalInfoLabel.ForeColor = SystemColors.Control;
            terminalInfoLabel.Location = new Point(817, 0);
            terminalInfoLabel.Name = "terminalInfoLabel";
            terminalInfoLabel.Size = new Size(61, 15);
            terminalInfoLabel.TabIndex = 6;
            terminalInfoLabel.Text = "lines: 1000";
            // 
            // tabPage1
            // 
            tabPage1.BackColor = Color.FromArgb(47, 51, 55);
            tabPage1.BorderStyle = BorderStyle.FixedSingle;
            tabPage1.Controls.Add(mainInput);
            tabPage1.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tabPage1.ForeColor = Color.FromArgb(47, 51, 55);
            tabPage1.Location = new Point(4, 30);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(870, 466);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "untitled";
            // 
            // mainInput
            // 
            mainInput.AcceptsTab = true;
            mainInput.AutoWordSelection = true;
            mainInput.BackColor = Color.FromArgb(59, 64, 69);
            mainInput.Dock = DockStyle.Fill;
            mainInput.Font = new Font("Georgia", 12.75F, FontStyle.Regular, GraphicsUnit.Point);
            mainInput.ForeColor = SystemColors.Window;
            mainInput.ImeMode = ImeMode.Hiragana;
            mainInput.Location = new Point(3, 3);
            mainInput.Name = "mainInput";
            mainInput.Size = new Size(862, 458);
            mainInput.TabIndex = 5;
            mainInput.TabStop = false;
            mainInput.Text = "";
            mainInput.TextChanged += mainInput_TextChanged;
            // 
            // tabPages
            // 
            tabPages.Controls.Add(tabPage1);
            tabPages.Dock = DockStyle.Fill;
            tabPages.Location = new Point(0, 24);
            tabPages.Name = "tabPages";
            tabPages.Padding = new Point(6, 6);
            tabPages.SelectedIndex = 0;
            tabPages.Size = new Size(878, 500);
            tabPages.TabIndex = 6;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(47, 51, 55);
            panel1.Controls.Add(terminalOutput);
            panel1.Controls.Add(terminalInfoLabel);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 524);
            panel1.Name = "panel1";
            panel1.Size = new Size(878, 20);
            panel1.TabIndex = 4;
            // 
            // terminalOutput
            // 
            terminalOutput.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            terminalOutput.AutoSize = true;
            terminalOutput.ForeColor = SystemColors.Control;
            terminalOutput.Location = new Point(8, 3);
            terminalOutput.Name = "terminalOutput";
            terminalOutput.Size = new Size(51, 15);
            terminalOutput.TabIndex = 7;
            terminalOutput.Text = "terminal";
            // 
            // mainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDarkDark;
            ClientSize = new Size(878, 544);
            Controls.Add(tabPages);
            Controls.Add(panel1);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "mainForm";
            Text = "Litext";
            Load += mainForm_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            tabPage1.ResumeLayout(false);
            tabPages.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem formatToolStripMenuItem;
        private ToolStripMenuItem localizeToolStripMenuItem;
        private ToolStripMenuItem runToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem newToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem saveAsToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private Label terminalInfoLabel;
        private TabPage tabPage1;
        private RichTextBox mainInput;
        private TabControl tabPages;
        private Panel panel1;
        private Label terminalOutput;
        private ToolStripMenuItem preferencesToolStripMenuItem;
        private ToolStripMenuItem themeToolStripMenuItem;
        private ToolStripMenuItem defaultSystemToolStripMenuItem;
        private ToolStripMenuItem darkToolStripMenuItem;
        private ToolStripMenuItem lightToolStripMenuItem;
        private ToolStripMenuItem resetTextHighligthingToolStripMenuItem;
        private ToolStripMenuItem editColorsToolStripMenuItem;
        private ToolStripMenuItem resetColorsToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ToolStripMenuItem blankToolStripMenuItem;
        private ToolStripMenuItem hTMLToolStripMenuItem;
        private ToolStripMenuItem pythonToolStripMenuItem;
    }
}