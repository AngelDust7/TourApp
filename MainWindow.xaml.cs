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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            

            //Для открытия Page

            MainFrame.Navigate(new HotelsPage());
            Manager.MainFrame = MainFrame;

            //Для открытия Page
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            log log = new log();
            this.Close();
            log.ShowDialog();
        }
    }
}
