using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
using System.Windows.Shapes;

namespace ToursApp
{
    /// <summary>
    /// Логика взаимодействия для log.xaml
    /// </summary>
    public partial class log : Window
    {
        public log()
        {
            InitializeComponent();
        }


        public DataTable Select(string selectSQL)
        {
            DataTable dataTable = new DataTable("dataBase");
            //Прописываем строку подключения
            SqlConnection sqlConnection = new SqlConnection(@"data source=DESKTOP-SFUJH1J;initial catalog=ToursBase;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework;");
            sqlConnection.Open();
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = selectSQL;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            sqlDataAdapter.Fill(dataTable);
            return dataTable;
        }


        private void BtnEnter_Click(object sender, RoutedEventArgs e)
        {
            if (TbLogin.Text.Length > 0) // проверяем введён ли логин 
            {
                if (PsBox.Password.Length > 0) // проверяем введён ли пароль 
                { // ищем в базе данных пользователя с такими данными 
                    DataTable dt_user = Select("SELECT HotelName, CountOfStars FROM Hotel WHERE HotelName = '" + TbLogin.Text + "' AND CountOfStars = '" + PsBox.Password + "'");
                if (dt_user.Rows.Count > 0) // если такая запись существует 
                    {
                        
                        var w1 = new MainWindow(); //при успешной авторизации
                        this.Close(); //Закрытие предыдущего
                        w1.ShowDialog(); //откроется новое окно
                        
                    }
                    else MessageBox.Show("Пользователя не найден"); // выводим ошибку 
                }
                else MessageBox.Show("Введите пароль"); // выводим ошибку 
            }
            else MessageBox.Show("Введите логин"); // выводим ошибку
        }

    }
}
