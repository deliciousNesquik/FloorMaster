using FloorMaster.Database;
using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace FloorMaster
{
    public partial class AddPartner : Page
    {
        private Partner PartnerData = new Partner();
        public AddPartner(Partner SelectedPartners)
        {
            InitializeComponent();

            if (SelectedPartners != null)
            {
                PartnerData = SelectedPartners;
            }
            DataContext = PartnerData;

            var FormOrganizations = FloorMasterEntities.GetContext().TheFormOfTheOrganization.Select(p => p.TypePartner);
            var LastIDPartners = FloorMasterEntities.GetContext().Partner.Max(p => p.ID) + 1;

            IDTextBlock.Text = LastIDPartners.ToString();

            foreach (var FormOrganization in FormOrganizations)
            {
                FormOrgComboBox.Items.Add(FormOrganization);
            }
            FormOrgComboBox.SelectedIndex = 0;

        }

        private bool CheckUserInput()
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(IndexTextBox.Text))
            {
                errors.AppendLine("Уканите индекс");
            }
            else
            {
                if (IndexTextBox.Text.Length > 6 || IndexTextBox.Text.Length < 6)
                {
                    errors.AppendLine("Укажите правильный индекс!");
                }
            }

            if (string.IsNullOrWhiteSpace(RegionTextBox.Text))
            {
                errors.AppendLine("Уканите область");
            }


            if (string.IsNullOrWhiteSpace(CityTextBox.Text))
            {
                errors.AppendLine("Уканите город");
            }

            if (string.IsNullOrWhiteSpace(StreetTextBox.Text))
            {    
                errors.AppendLine("Уканите улицу");
            }

            if (string.IsNullOrWhiteSpace(HouseNumberTextBox.Text))
            {    
                errors.AppendLine("Уканите номер дома");
            }

            if (string.IsNullOrWhiteSpace(INNTextBox.Text))
            {    
                errors.AppendLine("Уканите ИНН");
            }

            if (string.IsNullOrWhiteSpace(RatingTextBox.Text))
            {    
                errors.AppendLine("Уканите рейтинг");
            }

            if (string.IsNullOrWhiteSpace(SurnameTextBox.Text))
            {
                errors.AppendLine("Уканите фамилию директора");
            }
            else
            {
                if (!Regex.IsMatch(SurnameTextBox.Text, "[A-Za-zА-яа-я]"))
                {
                    errors.AppendLine("Укажите настоящую фамилию директора!");
                }
            }

            if (string.IsNullOrWhiteSpace(NameTextBox.Text))
            {    
                errors.AppendLine("Уканите имя директора");
            }
            else
            {
                if (!Regex.IsMatch(NameTextBox.Text, "[A-Za-zА-яа-я]"))
                {
                    errors.AppendLine("Укажите настоящее имя директора!");
                }
            }

            if (string.IsNullOrWhiteSpace(NamePartnerTextBox.Text))
            {    
                errors.AppendLine("Уканите наимнование партнера");
            }

            if (string.IsNullOrWhiteSpace(MailPartnerTextBox.Text))
            {    
                errors.AppendLine("Уканите почту партнера");
            }
            else
            {
                string pattern = @"^(?!\.)(?!.*\.\.)(?!.*\.{2,})[A-Za-z0-9!#$%&'*+/=?^_`{|}~.-]+@[A-Za-z0-9-]+\.[A-Z|a-z]{2,}$";
                if (!Regex.IsMatch(MailPartnerTextBox.Text, pattern))
                {
                    errors.AppendLine("Укажите правильную почту!");
                }
            }

            if (string.IsNullOrWhiteSpace(PhoneNumberPartnerTextBox.Text.Replace("-", "").Replace("+", "")))
            {    
                errors.AppendLine("Уканите номер партнера");
            }
            else
            {
                if (!Regex.IsMatch(PhoneNumberPartnerTextBox.Text.Replace("-", "").Replace("+", ""), "[0-9]") || PhoneNumberPartnerTextBox.Text.Replace("-", "").Replace("+", "").Length != 11)
                {
                    errors.AppendLine("Укажите правильный номер телефона партнера!");
                }
            }

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString(), "Ошибки при заполнении данных");
                return false;
            }

            return true;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {

            if (CheckUserInput())
            {
                PartnerData.Index = Int32.Parse(IndexTextBox.Text);
                PartnerData.Region = RegionTextBox.Text;
                PartnerData.City = CityTextBox.Text;
                PartnerData.Street = StreetTextBox.Text;
                PartnerData.HouseNumber = HouseNumberTextBox.Text;
                PartnerData.INN = INNTextBox.Text;
                PartnerData.Rating = Double.Parse(RatingTextBox.Text);
                PartnerData.Surname = SurnameTextBox.Text;
                PartnerData.Name = NameTextBox.Text;
                PartnerData.Patronomic = (PatronymicTextBox.Text == "") ? null : PatronymicTextBox.Text;
                PartnerData.TheFormOfTheOrganization = FormOrgComboBox.SelectedIndex;
                PartnerData.Title = NamePartnerTextBox.Text;
                PartnerData.Mail = MailPartnerTextBox.Text;
                PartnerData.PhoneNumber = PhoneNumberPartnerTextBox.Text;
                PartnerData.Logo = null;


                
                if (PartnerData.ID == 0)
                    FloorMasterEntities.GetContext().Partner.Add(PartnerData);
                try
                {
                    FloorMasterEntities.GetContext().SaveChanges();
                    MessageBox.Show("Информация сохранена");
                    Manager.NavigationFrame.GoBack();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }

                if (FloorMasterEntities.GetContext().SaveChanges() > 0)
                {
                    MessageBox.Show("Успешное сохранение партнера!", "Успешно");
                }
                else
                {
                    MessageBox.Show("Ошибка при сохранении данных партнера", "Ошибка");
                }
                
            }
        }
    }
}
