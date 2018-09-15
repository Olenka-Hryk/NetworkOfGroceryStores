using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace NetworkOfGroceryStores
{
    /// <summary>
    /// Логика взаимодействия для SearchWorkerWindow.xaml
    /// </summary>
    public partial class SearchWorkerWindow : Window
    {
        SqlConnection conn;
        public SearchWorkerWindow()
        {
            InitializeComponent();
            MethodSearchProductlistBox.SelectedIndex = 0;
        }

        private void SearchNow_button_Click(object sender, RoutedEventArgs e)
        {
            int selecteVal = MethodSearchProductlistBox.SelectedIndex;

            if (WhatISearch_textBox.Text != "")
            {
                if (selecteVal == 0) //  за прізвищем
                {
                    try
                    {
                        string Name = WhatISearch_textBox.Text.ToString();
                        conn = new SqlConnection(@"Server = (local); Database = DB_NetworkOfGroceryStores; Uid = sa; Pwd = 11111111;");
                        conn.Open();
                        SqlDataAdapter adapt = new SqlDataAdapter("SELECT ID_workers, Surname, Name, MiddleName, DateOfBirth FROM Workers Where Surname = '" + Name + "'", conn);
                        DataSet ds = new DataSet();
                        DataTable dt = new DataTable();
                        adapt.Fill(dt);

                        string i = dt.Rows[0][0].ToString();

                        if (i == null)
                        {
                            MessageBox.Show("Немає такого працівника!", "Помилка: ", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        else
                        {
                            dt.Columns["SurName"].ColumnName = "Прізвище";
                            dt.Columns["Name"].ColumnName = "Імя";
                            dt.Columns["MiddleName"].ColumnName = "По батькові";
                            dt.Columns["DateOfBirth"].ColumnName = "Дата народження";
                            ProductOfSubtypes_dataGrid.ItemsSource = dt.DefaultView;
                        }
                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Немає такого працівника!", "Помилка: ", MessageBoxButton.OK, MessageBoxImage.Information);
                        MessageBox.Show(ex.Message);
                        conn.Close();
                    }
                }
            }
            else
                MessageBox.Show("Заповніть пошукові данні! Будьте уважні!", "Помилка: ", MessageBoxButton.OK, MessageBoxImage.Error);

        }
    }
}
