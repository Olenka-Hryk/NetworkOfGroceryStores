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
    /// Логика взаимодействия для SearchProductWindow.xaml
    /// </summary>
    public partial class SearchProductWindow : Window
    {
        SqlConnection conn;
        public SearchProductWindow()
        {
            InitializeComponent();
            MethodSearchProductlistBox.SelectedIndex = 0;
        }

        private void SearchNow_button_Click(object sender, RoutedEventArgs e)
        {
            int selecteVal = MethodSearchProductlistBox.SelectedIndex;

            if (WhatISearch_textBox.Text != "")
            {
                if (selecteVal == 0) //  за назвою продукту
                {
                    try
                    {
                        string NamePrd = WhatISearch_textBox.Text.ToString();
                        conn = new SqlConnection(@"Server = (local); Database = DB_NetworkOfGroceryStores; Uid = sa; Pwd = 11111111;");
                        conn.Open();
                        SqlDataAdapter adapt = new SqlDataAdapter("SELECT Name, Firm, Price, Quantity, ProductSize FROM vProductOfSubtypes Where Name = '" + NamePrd + "'", conn);
                        DataSet ds = new DataSet();
                        DataTable dt = new DataTable();
                        adapt.Fill(dt);

                        string i = dt.Rows[0][0].ToString();

                        if (i == null)
                        {
                            MessageBox.Show("Немає такого продукту!", "Помилка: ", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        else
                        {
                            dt.Columns["Name"].ColumnName = "Назва продукту";
                            dt.Columns["Firm"].ColumnName = "Назва фірми";
                            dt.Columns["Price"].ColumnName = "Ціна";
                            dt.Columns["Quantity"].ColumnName = "Кількість";
                            dt.Columns["ProductSize"].ColumnName = "Розмір";
                            ProductOfSubtypes_dataGrid.ItemsSource = dt.DefaultView;
                        }
                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Немає такого продукту!", "Помилка: ", MessageBoxButton.OK, MessageBoxImage.Information);                
                      //  MessageBox.Show(ex.Message);
                        conn.Close();
                    }
                }

                if (selecteVal == 1) //  за виробником
                {
                    try
                    {
                        string FirmPrd = WhatISearch_textBox.Text.ToString();
                        conn = new SqlConnection(@"Server = (local); Database = DB_NetworkOfGroceryStores; Uid = sa; Pwd = 11111111;");
                        conn.Open();
                        SqlDataAdapter adapt = new SqlDataAdapter("SELECT Name, Firm, Price, Quantity, ProductSize FROM vProductOfSubtypes Where Firm = '" + FirmPrd + "'", conn);
                        DataSet ds = new DataSet();
                        DataTable dt = new DataTable();
                        adapt.Fill(dt);

                        string i = dt.Rows[0][0].ToString();

                        if (i == null)
                        {
                            MessageBox.Show("Немає такого продукту!", "Помилка: ", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        else
                        {
                            dt.Columns["Name"].ColumnName = "Назва продукту";
                            dt.Columns["Firm"].ColumnName = "Назва фірми";
                            dt.Columns["Price"].ColumnName = "Ціна";
                            dt.Columns["Quantity"].ColumnName = "Кількість";
                            dt.Columns["ProductSize"].ColumnName = "Розмір";
                            ProductOfSubtypes_dataGrid.ItemsSource = dt.DefaultView;
                        }
                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Немає такого продукту!", "Помилка: ", MessageBoxButton.OK, MessageBoxImage.Information);
                        //  MessageBox.Show(ex.Message);
                        conn.Close();
                    }
                }

                if (selecteVal == 2) //  за ціною
                {                   
                    try
                    {
                        string PricePrd = WhatISearch_textBox.Text;
                        Console.WriteLine(PricePrd);

                        conn = new SqlConnection(@"Server = (local); Database = DB_NetworkOfGroceryStores; Uid = sa; Pwd = 11111111;");
                        conn.Open();
                        SqlDataAdapter adapt = new SqlDataAdapter("SELECT Name, Firm, Price, Quantity, ProductSize FROM vProductOfSubtypes Where Price = '"+PricePrd+"'", conn);
                        DataSet ds = new DataSet();
                        DataTable dt = new DataTable();
                        adapt.Fill(dt);

                        string i = dt.Rows[0][0].ToString();

                        if (i == null)
                        {
                           // MessageBox.Show("Немає такого продукту!", "Помилка: ", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        else
                        {
                            dt.Columns["Name"].ColumnName = "Назва продукту";
                            dt.Columns["Firm"].ColumnName = "Назва фірми";
                            dt.Columns["Price"].ColumnName = "Ціна";
                            dt.Columns["Quantity"].ColumnName = "Кількість";
                            dt.Columns["ProductSize"].ColumnName = "Розмір";
                            ProductOfSubtypes_dataGrid.ItemsSource = dt.DefaultView;
                        }
                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Немає такого продукту!", "Помилка: ", MessageBoxButton.OK, MessageBoxImage.Information);
                         MessageBox.Show(ex.Message);
                        conn.Close();
                    }
                }

                if (selecteVal == 3) //  за штрих-кодом
                {
                    try
                    {
                        string BarCodePrd = WhatISearch_textBox.Text.ToString();
                        conn = new SqlConnection(@"Server = (local); Database = DB_NetworkOfGroceryStores; Uid = sa; Pwd = 11111111;");
                        conn.Open();
                        SqlDataAdapter adapt = new SqlDataAdapter("SELECT Name, Firm, Price, Quantity, ProductSize FROM vProductOfSubtypes Where BarCode = "+BarCodePrd+"", conn);
                        DataSet ds = new DataSet();
                        DataTable dt = new DataTable();
                        adapt.Fill(dt);

                        string i = dt.Rows[0][0].ToString();

                        if (i == null)
                        {
                            MessageBox.Show("Немає такого продукту!", "Помилка: ", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        else
                        {
                            dt.Columns["Name"].ColumnName = "Назва продукту";
                            dt.Columns["Firm"].ColumnName = "Назва фірми";
                            dt.Columns["Price"].ColumnName = "Ціна";
                            dt.Columns["Quantity"].ColumnName = "Кількість";
                            dt.Columns["ProductSize"].ColumnName = "Розмір";
                            ProductOfSubtypes_dataGrid.ItemsSource = dt.DefaultView;
                        }
                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Немає такого продукту!", "Помилка: ", MessageBoxButton.OK, MessageBoxImage.Information);
                        //  MessageBox.Show(ex.Message);
                        conn.Close();
                    }
                }
            }
            else
                MessageBox.Show("Заповніть пошукові данні! Будьте уважні!", "Помилка: ", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
