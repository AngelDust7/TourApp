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

namespace ToursApp
{
    /// <summary>
    /// Логика взаимодействия для AddEditPage.xaml
    /// </summary>
    public partial class AddEditPage : Page
    {

        //---------------Экземпляр для добавляемого Отеля--------------

        private Hotel _currentHotel = new Hotel();

        //---------------Экземпляр для добавляемого Отеля--------------
        public AddEditPage( Hotel selectedHotel) //<----- Параметр для изменения данных
        {
            InitializeComponent();


            // Параметр для изменения данных
            if (selectedHotel != null )
            {
                _currentHotel = selectedHotel;
            }
            // Параметр для изменения данных


            DataContext = _currentHotel;
            ComboCountries.ItemsSource = ToursBaseEntities.GetContext().Country.ToList();
        }


       //----------------------Кнопка Save--------------------
        private void BthSave_Click(object sender, RoutedEventArgs e)
        {

            //Проверка на error
            StringBuilder error = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentHotel.HotelName))
            {
                error.AppendLine("Write name of hotel");
            }
            if(_currentHotel.CountOfStars < 1 || _currentHotel.CountOfStars > 10) {
                error.AppendLine("1-10");
            }
            if(_currentHotel.Country == null)
            {
                error.AppendLine("Select country");
            }

            if(error.Length > 0)
            {
                MessageBox.Show(error.ToString());
                return;
            }

            //Проверка на error

            //Код на добавление

            if (_currentHotel.HotelId == 0)
            {
                ToursBaseEntities.GetContext().Hotel.Add(_currentHotel);
               
            }
            try
            {
                ToursBaseEntities.GetContext().SaveChanges();
                MessageBox.Show("Info saved");
                Manager.MainFrame.GoBack();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            //Код на добавление
        }

        //----------------------Кнопка Save--------------------


         private void Button_Click_1(object sender, RoutedEventArgs e)
             {
                 Manager.MainFrame.GoBack();
             }
    }
}
