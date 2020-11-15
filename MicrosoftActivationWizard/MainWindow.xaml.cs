using System;
using System.Diagnostics;
using System.IO;
using System.Windows;

namespace MicrosoftActivationWizard
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Content = new RootPage(this);
        }

        private void PrepTools()
        {
            RemoveTools();
            System.IO.Compression.ZipFile.ExtractToDirectory(Path.Combine(Directory.GetCurrentDirectory(), "tools.zip"), Directory.GetCurrentDirectory());
        }

        private void RemoveTools()
        {
            if (Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), "tools.")))
                Directory.Delete(Path.Combine(Directory.GetCurrentDirectory(), "tools."), true);
        }

        private Process RunInCmd(string path, string args = "")
        {
            var proc = new Process { StartInfo = new ProcessStartInfo("cmd.exe", $"/C \"{path}\" {args}") };
            proc.Start();

            return proc;
        }

        // RootPage buttons
        public void ButtonWindows_OnClick(object sender, RoutedEventArgs e) => Content = new WindowsPage(this);

        public void ButtonOffice_OnClick(object sender, RoutedEventArgs e) => Content = new OfficePage(this);

        // WindowsPage buttons
        public void ButtonWinServer_OnClick(object sender, RoutedEventArgs e)
        {
            PrepTools();

            var proc = RunInCmd(Path.Combine(Directory.GetCurrentDirectory(), "tools\\hwid-kms38\\KMS38_Activation.cmd"), "/u");
            proc.WaitForExit();
            MessageBox.Show("Please restart your PC after the activation is completed.");

            RemoveTools();
            Environment.Exit(0);
        }

        public void ButtonWin10_OnClick(object sender, RoutedEventArgs e)
        {
            PrepTools();

            var proc = RunInCmd(Path.Combine(Directory.GetCurrentDirectory(), "tools\\hwid-kms38\\HWID_Activation.cmd"), "/u");
            proc.WaitForExit();
            MessageBox.Show("Please restart your PC after the activation is completed.");

            RemoveTools();
            Environment.Exit(0);
        }

        // OfficePage buttons
        public void ButtonOfficeNonStandard_OnClick(object sender, RoutedEventArgs e)
        {
            PrepTools();

            var c2rToVolProc = RunInCmd(Path.Combine(Directory.GetCurrentDirectory(), "tools\\c2r-to-vol\\elevate.cmd"));
            c2rToVolProc.WaitForExit();
            MessageBox.Show("Prepping Office for activation. When the blue window says \"press any key to exit\", press a key, then click OK.");

            var kmsProc = RunInCmd(Path.Combine(Directory.GetCurrentDirectory(), "tools\\online-kms\\Activate.cmd"));
            kmsProc.WaitForExit();
            MessageBox.Show("Activating Office. When the black window says \"press any key to exit\", press a key, then click OK.");

            MessageBox.Show("Office is active. Please relaunch any open Office apps.");

            RemoveTools();
            Environment.Exit(0);
        }

        public void ButtonOfficeStandard_OnClick(object sender, RoutedEventArgs e)
        {
            PrepTools();

            var kmsProc = RunInCmd(Path.Combine(Directory.GetCurrentDirectory(), "tools\\online-kms\\Activate.cmd"));
            kmsProc.WaitForExit();
            MessageBox.Show("Activating Office. When the black window says \"press any key to exit\", press a key, then click OK.");

            MessageBox.Show("Office is active. Please relaunch any open Office apps.");

            RemoveTools();
            Environment.Exit(0);
        }
    }
}
