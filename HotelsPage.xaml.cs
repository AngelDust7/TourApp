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
    /// Логика взаимодействия для HotelsPage.xaml
    /// </summary>
    public partial class HotelsPage : Page
    {
        public HotelsPage()
        {
            InitializeComponent();
            //DGridHotels.ItemsSource = ToursBaseEntities.GetContext().Hotel.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }


        //---------------------------Кнопки действий для отображения "Page-Создать Класс Manager для отображения" (Добавление Удаление и Редактирование)---------------------------------------------

        private void BthEdit_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditPage((sender as Button).DataContext as Hotel)); //<---- Передача экземпляра редактируемого отеля
        }

        private void BthAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditPage(null)); //<----- При добавлении кода на изменения присвоить null чтобы убрать ошибку
        }

        private void BthDel_Click(object sender, RoutedEventArgs e)
 {


     var hotelsForDel = DGridHotels.SelectedItems.Cast<Hotel>().ToList();

     if (DGridHotels.SelectedItems.Count == 0)
     {
         MessageBox.Show("Не выбрана ни одна строка!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Warning);
         return;
     }

     if (MessageBox.Show($"Вы точно хотите удалить следующие {hotelsForDel.Count()} элементов?", "Внимание!",
      MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
     {
         try
         {
             ToursBaseEntities.GetContext().Hotel.RemoveRange(hotelsForDel);
             ToursBaseEntities.GetContext().SaveChanges();
             MessageBox.Show("Deleted");

             DGridHotels.ItemsSource = ToursBaseEntities.GetContext().Hotel.ToList();
         }
         catch (Exception ex)
         {
             MessageBox.Show(ex.Message.ToString());
         }
     }

 }
        //---------------------------Кнопки действий для отображения "Page-Создать Класс Manager для отображения" (Добавление Удаление и Редактирование)---------------------------------------------



        //---------------------------------------Отображение и обновление вывода данных--------------------------------------------------------------------------

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                ToursBaseEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGridHotels.ItemsSource = ToursBaseEntities.GetContext().Hotel.ToList();
            }
        }

        //---------------------------------------Отображение и обновление вывода данных--------------------------------------------------------------------------
    }
}
