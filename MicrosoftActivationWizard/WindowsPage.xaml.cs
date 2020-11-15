using System.Windows;
using System.Windows.Controls;

namespace MicrosoftActivationWizard
{
    /// <summary>
    /// Interaction logic for WindowsPage.xaml
    /// </summary>
    public partial class WindowsPage : Page
    {
        private MainWindow _parent;

        public WindowsPage(MainWindow parent)
        {
            _parent = parent;
            InitializeComponent();
        }

        private void ButtonWinServer_OnClick(object sender, RoutedEventArgs e) => _parent.ButtonWinServer_OnClick(sender, e);

        private void ButtonWin10_OnClick(object sender, RoutedEventArgs e) => _parent.ButtonWin10_OnClick(sender, e);
    }
}
