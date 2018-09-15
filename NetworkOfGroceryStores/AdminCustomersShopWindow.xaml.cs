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
    /// Логика взаимодействия для AdminCustomersShopWindow.xaml
    /// </summary>
    public partial class AdminCustomersShopWindow : Window
    {
        SqlConnection conn;
        public AdminCustomersShopWindow()
        {
            InitializeComponent();
        }

        //Select Customers
        public void SelectCustomers()
        {
            try
            {
                conn = new SqlConnection(@"Server = (local); Database = DB_NetworkOfGroceryStores; Uid = sa; Pwd = 11111111;");
                conn.Open();
                SqlDataAdapter adapt = new SqlDataAdapter("SELECT ID_customers, Surname, Name, MiddleName, DateOfBirth, PhoneNumder, NumberCard, Discount FROM Customers", conn);
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                adapt.Fill(dt);
                dt.Columns["SurName"].ColumnName = "Прізвище";
                dt.Columns["Name"].ColumnName = "Імя";
                dt.Columns["MiddleName"].ColumnName = "По батькові";
                dt.Columns["DateOfBirth"].ColumnName = "Дата народження";
                dt.Columns["PhoneNumder"].ColumnName = "Мобільний";
                dt.Columns["NumberCard"].ColumnName = "Номер карти";
                dt.Columns["Discount"].ColumnName = "Знижка";
               
                CustomerShop_dataGrid.ItemsSource = dt.DefaultView;
                CustomerShop_dataGrid.Columns[0].Visibility = Visibility.Hidden;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SelectCustomers();
        }

        private void Deletecustomer_button_Click(object sender, RoutedEventArgs e)
        {
            DataRowView rowSelected = CustomerShop_dataGrid.SelectedItem as DataRowView;

            if (rowSelected != null)
            {
                Console.WriteLine(rowSelected[0].ToString());
            }
            try
            {
                conn = new SqlConnection(@"Server = (local); Database = DB_NetworkOfGroceryStores; Uid = sa; Pwd = 11111111;");
                conn.Open();
                SqlCommand query = new SqlCommand("DELETE FROM Customers WHERE ID_customers = " + rowSelected[0].ToString() + "", conn);
                query.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Клієнта видалено з бази даних!", "Видалення: ", MessageBoxButton.OK, MessageBoxImage.Information);

                SelectCustomers();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }
        }

        private void AddCustomer_button_Click(object sender, RoutedEventArgs e)
        {
            AdminNewCustomerWindow cust = new AdminNewCustomerWindow();
            cust.Show();
            SelectCustomers();
        }

        private void EditCustomer_button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataRowView rowSelected = CustomerShop_dataGrid.SelectedItem as DataRowView;
                if (rowSelected != null)
                 {
                    string id = rowSelected[0].ToString();
                    string surname = rowSelected[1].ToString();
                    string name = rowSelected[2].ToString();
                    string middleName = rowSelected[3].ToString();
                    string dateOfBirth = Convert.ToDateTime(rowSelected[4]).ToString("yyyy-MM-dd");
                    string phoneOfNumber = rowSelected[5].ToString();
                    string numberCard = rowSelected[6].ToString();
                    string discount = rowSelected[7].ToString();
                    Console.WriteLine(rowSelected[0].ToString());

                conn = new SqlConnection(@"Server = (local); Database = DB_NetworkOfGroceryStores; Uid = sa; Pwd = 11111111;");
                conn.Open();
                SqlCommand query = new SqlCommand("UPDATE Customers SET Surname = '"+ surname + "', Name = '"+name+"', MiddleName = '"+middleName+"', DateOfBirth = '"+ dateOfBirth +"', PhoneNumder = '"+phoneOfNumber+"', NumberCard = '"+numberCard+"', Discount = '"+Int16.Parse(discount)+"' WHERE ID_customers = " + id + "", conn);
                query.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Клієнта відредаговано в базі даних!", "Редагування: ", MessageBoxButton.OK, MessageBoxImage.Information);
                 }
                SelectCustomers();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }
        }

        private void Searchcustomer_button_Click(object sender, RoutedEventArgs e)
        {
            SearchCustomerWindow cust = new SearchCustomerWindow();
            cust.Show();
        }
    }
}
