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
    /// Логика взаимодействия для SearchCustomerWindow.xaml
    /// </summary>
    public partial class SearchCustomerWindow : Window
    {
        SqlConnection conn;
        public SearchCustomerWindow()
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
                        SqlDataAdapter adapt = new SqlDataAdapter("SELECT ID_customers, Surname, Name, MiddleName, DateOfBirth, PhoneNumder, NumberCard, Discount FROM Customers Where Surname = '" + Name + "'", conn);
                        DataSet ds = new DataSet();
                        DataTable dt = new DataTable();
                        adapt.Fill(dt);

                        string i = dt.Rows[0][0].ToString();

                        if (i == null)
                        {
                            MessageBox.Show("Немає такого клієнта!", "Помилка: ", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        else
                        {
                            dt.Columns["SurName"].ColumnName = "Прізвище";
                            dt.Columns["Name"].ColumnName = "Імя";
                            dt.Columns["MiddleName"].ColumnName = "По батькові";
                            dt.Columns["DateOfBirth"].ColumnName = "Дата народження";
                            dt.Columns["PhoneNumder"].ColumnName = "Мобільний";
                            dt.Columns["NumberCard"].ColumnName = "Номер карти";
                            dt.Columns["Discount"].ColumnName = "Знижка";
                            ProductOfSubtypes_dataGrid.ItemsSource = dt.DefaultView;
                        }
                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Немає такого клієнта!", "Помилка: ", MessageBoxButton.OK, MessageBoxImage.Information);
                         MessageBox.Show(ex.Message);
                        conn.Close();
                    }
                }

                if (selecteVal == 1) //  за мобільним
                {
                    try
                    {
                        string phone = WhatISearch_textBox.Text.ToString();
                        conn = new SqlConnection(@"Server = (local); Database = DB_NetworkOfGroceryStores; Uid = sa; Pwd = 11111111;");
                        conn.Open();
                        SqlDataAdapter adapt = new SqlDataAdapter("SELECT ID_customers, Surname, Name, MiddleName, DateOfBirth, PhoneNumder, NumberCard, Discount FROM Customers Where PhoneNumder = '" + phone + "'", conn);
                        DataSet ds = new DataSet();
                        DataTable dt = new DataTable();
                        adapt.Fill(dt);

                        string i = dt.Rows[0][0].ToString();

                        if (i == null)
                        {
                            MessageBox.Show("Немає такого клієнта!", "Помилка: ", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        else
                        {
                            dt.Columns["SurName"].ColumnName = "Прізвище";
                            dt.Columns["Name"].ColumnName = "Імя";
                            dt.Columns["MiddleName"].ColumnName = "По батькові";
                            dt.Columns["DateOfBirth"].ColumnName = "Дата народження";
                            dt.Columns["PhoneNumder"].ColumnName = "Мобільний";
                            dt.Columns["NumberCard"].ColumnName = "Номер карти";
                            dt.Columns["Discount"].ColumnName = "Знижка";
                            ProductOfSubtypes_dataGrid.ItemsSource = dt.DefaultView;
                        }
                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Немає такого клієнта!", "Помилка: ", MessageBoxButton.OK, MessageBoxImage.Information);
                         MessageBox.Show(ex.Message);
                        conn.Close();
                    }
                }

                if (selecteVal == 2) //  за картою
                {
                    try
                    {
                        string card = WhatISearch_textBox.Text.ToString();
                        conn = new SqlConnection(@"Server = (local); Database = DB_NetworkOfGroceryStores; Uid = sa; Pwd = 11111111;");
                        conn.Open();
                        SqlDataAdapter adapt = new SqlDataAdapter("SELECT ID_customers, Surname, Name, MiddleName, DateOfBirth, PhoneNumder, NumberCard, Discount FROM Customers Where NumberCard = '" + card + "'", conn);
                        DataSet ds = new DataSet();
                        DataTable dt = new DataTable();
                        adapt.Fill(dt);

                        string i = dt.Rows[0][0].ToString();

                        if (i == null)
                        {
                            MessageBox.Show("Немає такого клієнта!", "Помилка: ", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        else
                        {
                            dt.Columns["SurName"].ColumnName = "Прізвище";
                            dt.Columns["Name"].ColumnName = "Імя";
                            dt.Columns["MiddleName"].ColumnName = "По батькові";
                            dt.Columns["DateOfBirth"].ColumnName = "Дата народження";
                            dt.Columns["PhoneNumder"].ColumnName = "Мобільний";
                            dt.Columns["NumberCard"].ColumnName = "Номер карти";
                            dt.Columns["Discount"].ColumnName = "Знижка";
                            ProductOfSubtypes_dataGrid.ItemsSource = dt.DefaultView;
                        }
                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Немає такого клієнта!", "Помилка: ", MessageBoxButton.OK, MessageBoxImage.Information);
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
