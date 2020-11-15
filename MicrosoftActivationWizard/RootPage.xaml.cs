using System.Windows;
using System.Windows.Controls;

namespace MicrosoftActivationWizard
{
    /// <summary>
    /// Interaction logic for RootPage.xaml
    /// </summary>
    public partial class RootPage : Page
    {
        private MainWindow _parent;

        public RootPage(MainWindow parent)
        {
            _parent = parent;
            InitializeComponent();
        }

        private void ButtonWindows_OnClick(object sender, RoutedEventArgs e) => _parent.ButtonWindows_OnClick(sender, e);

        private void ButtonOffice_OnClick(object sender, RoutedEventArgs e) => _parent.ButtonOffice_OnClick(sender, e);
    }
}
