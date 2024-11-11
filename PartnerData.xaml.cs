using FloorMaster.Database;
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
    /// Логика взаимодействия для PartnerData.xaml
    /// </summary>
    public partial class PartnerData : Page
    {
        public PartnerData()
        {
            InitializeComponent();
            var currentPartner = FloorMasterEntities.GetContext().Partner.ToList();
            PartnerListView.ItemsSource = currentPartner;
        }

        private void DeletePartner_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditPartner_Click(object sender, RoutedEventArgs e)
        {
            Manager.NavigationFrame.Navigate(new AddPartner((sender as MenuItem).DataContext as Partner));
        }

        private void Update()
        {
            var partner = FloorMasterEntities.GetContext().Partner.ToList();
            PartnerListView.ItemsSource = partner;
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            Update();
        }
    }
}
