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
    /// Логика взаимодействия для AdminSaleWindow.xaml
    /// </summary>
    public partial class AdminSaleWindow : Window
    {
        SqlConnection conn;
        public AdminSaleWindow()
        {
            InitializeComponent();
        }
        //Select 
        public void SelectSales()
        {
            try
            {
                conn = new SqlConnection(@"Server = (local); Database = DB_NetworkOfGroceryStores; Uid = sa; Pwd = 11111111;");
                conn.Open();
                SqlDataAdapter adapt = new SqlDataAdapter("SELECT Id_sale, Name, Firm, Quantity, Name_sale, Percents, DateOfStart, DateOfFinish FROM vSaleShop", conn);
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                adapt.Fill(dt);
                dt.Columns["Name"].ColumnName = "Назва продукту";
                dt.Columns["Firm"].ColumnName = "Фірма";
                dt.Columns["Quantity"].ColumnName = "Кількість";
                dt.Columns["Name_Sale"].ColumnName = "Назва знижки";
                dt.Columns["Percents"].ColumnName = "Відсотки";
                dt.Columns["DateOfStart"].ColumnName = "Дата початку акції";
                dt.Columns["DateOfFinish"].ColumnName = "Дата закінчання акції";
                SaleShop_dataGrid.ItemsSource = dt.DefaultView;
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
            SelectSales();
        }

        private void AddSale_button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditSale_button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataRowView rowSelected = SaleShop_dataGrid.SelectedItem as DataRowView;
                if (rowSelected != null)
                {
                    string id = rowSelected[0].ToString();
                    string name = rowSelected[1].ToString();
                    string firm = rowSelected[2].ToString();
                    string quantity = rowSelected[3].ToString();
                    string name_Sale = rowSelected[4].ToString();
                    string percents = rowSelected[5].ToString();
                    string dateOfStart = Convert.ToDateTime(rowSelected[6]).ToString("yyyy-MM-dd");
                    string dateOfFinish = Convert.ToDateTime(rowSelected[7]).ToString("yyyy-MM-dd");
                    Console.WriteLine(rowSelected[0].ToString());

                    conn = new SqlConnection(@"Server = (local); Database = DB_NetworkOfGroceryStores; Uid = sa; Pwd = 11111111;");
                    conn.Open();
                    SqlCommand query = new SqlCommand("UPDATE Sale SET Percents = " + Int16.Parse(percents) + ", Name_sale = '" + name_Sale + "', DateOfStart = '" + dateOfStart + "', DateOfFinish = '" + dateOfFinish + "' WHERE ID_sale = " + id + "", conn);
                    query.ExecuteNonQuery();

                    SqlCommand query1 = new SqlCommand("UPDATE Products SET Name = '"+name+"', Firm = '"+firm+"' WHERE ID_product = (Select ID_product from Sale where ID_sale = '"+id+"')", conn);
                    query1.ExecuteNonQuery();

                    SqlCommand query2 = new SqlCommand("UPDATE Reserve SET Quantity = '" + Int16.Parse(quantity) + "'WHERE ID_product = (Select ID_product from Sale where ID_sale = '"+id+"')", conn);
                    query2.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Товар відредаговано в базі даних!", "Редагування: ", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                SelectSales();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }
        }

        private void DeleteSale_button_Click(object sender, RoutedEventArgs e)
        {

            DataRowView rowSelected = SaleShop_dataGrid.SelectedItem as DataRowView;
            try
            {
                if (rowSelected != null)
                {
                    string id = rowSelected[0].ToString();
                    Console.WriteLine(rowSelected[0].ToString());


                    conn = new SqlConnection(@"Server = (local); Database = DB_NetworkOfGroceryStores; Uid = sa; Pwd = 11111111;");
                    conn.Open();

                    SqlCommand query3 = new SqlCommand("DELETE FROM Cheque WHERE ID_sale = '" + id + "'", conn);
                    query3.ExecuteNonQuery();

                    SqlCommand query = new SqlCommand("DELETE FROM Sale WHERE ID_sale = " + id + "", conn);
                    query.ExecuteNonQuery();

                    SqlCommand query1 = new SqlCommand("DELETE FROM Products WHERE ID_product = (Select ID_product from Sale where ID_sale = '" + id + "')", conn);
                    query1.ExecuteNonQuery();

                    SqlCommand query2 = new SqlCommand("DELETE FROM Reserve WHERE ID_product = (Select ID_product from Sale where ID_sale = '" + id + "')", conn);
                    query2.ExecuteNonQuery();

                    conn.Close();
                    MessageBox.Show("Товар видалено з бази даних!", "Видалення: ", MessageBoxButton.OK, MessageBoxImage.Information);

                    SelectSales();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }
        }

        private void SearchSale_button_Click(object sender, RoutedEventArgs e)
        {
            SaleProductWindow sale = new SaleProductWindow();
            sale.Show();
        }
    }
}
