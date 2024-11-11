using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FloorMaster
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataFrame.Navigate(new PartnerData());
            Manager.NavigationFrame = DataFrame;
        }

        private void DataFrame_ContentRendered(object sender, EventArgs e)
        {
            if (DataFrame.CanGoBack)
            {
                AddPartnerButton.Visibility = Visibility.Hidden;
                BackButton.Visibility = Visibility.Visible;
            }
            else
            {
                AddPartnerButton.Visibility = Visibility.Visible;
                BackButton.Visibility = Visibility.Hidden;
                //this.Height = 450;
                //this.MinHeight = 275;
            }
        }

        private void AddPartnerButton_Click(object sender, RoutedEventArgs e)
        {
            DataFrame.Navigate(new AddPartner(null));
            
            AddPartnerButton.Visibility = Visibility.Hidden;
            BackButton.Visibility = Visibility.Visible;
            
            //this.Height = 635;
            //this.MinHeight = 635;


        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            DataFrame.GoBack();
            //this.Height = 450;
            //this.MinHeight = 275;
        }
    }
}
