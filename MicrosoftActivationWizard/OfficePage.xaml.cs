using System.Windows;
using System.Windows.Controls;

namespace MicrosoftActivationWizard
{
    /// <summary>
    /// Interaction logic for OfficePage.xaml
    /// </summary>
    public partial class OfficePage : Page
    {
        private MainWindow _parent;

        public OfficePage(MainWindow parent)
        {
            _parent = parent;
            InitializeComponent();
        }

        private void ButtonOfficeNonStandard_OnClick(object sender, RoutedEventArgs e) => _parent.ButtonOfficeNonStandard_OnClick(sender, e);

        private void ButtonOfficeStandard_OnClick(object sender, RoutedEventArgs e) => _parent.ButtonOfficeStandard_OnClick(sender, e);
    }
}
