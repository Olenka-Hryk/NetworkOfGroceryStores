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
    /// Логика взаимодействия для AdminGoodsWindow.xaml
    /// </summary>
    public partial class AdminGoodsWindow : Window
    {
        SqlConnection conn;
        public AdminGoodsWindow()
        {
            InitializeComponent();
        }

        //Select 
        public void SelectGoods()
        {
            try
            {
                conn = new SqlConnection(@"Server = (local); Database = DB_NetworkOfGroceryStores; Uid = sa; Pwd = 11111111;");
                conn.Open();
                SqlDataAdapter adapt = new SqlDataAdapter("SELECT vpi.ID_product, vpi.[Name], res.BarCode, vpi.Firm, sub.[Name], res.Price  FROM Products vpi, Subtypes sub, Reserve res Where vpi.ID_subtypes = sub.ID_subtypes And vpi.ID_product = res.ID_product", conn);
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                adapt.Fill(dt);
                dt.Columns["Name"].ColumnName = "Назва продукту";
                dt.Columns["BarCode"].ColumnName = "Штрих-код";
                dt.Columns["Firm"].ColumnName = "Фірма";
                dt.Columns["name1"].ColumnName = "Назва типу";
                dt.Columns["Price"].ColumnName = "Ціна";
                GoodsShop_dataGrid.ItemsSource = dt.DefaultView;
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
            SelectGoods();
        }

        private void AddWorkers_button_Click(object sender, RoutedEventArgs e)
        {
            AdminAddGroup aag = new AdminAddGroup();
            aag.Show();
        }

        private void EditWorkers_button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataRowView rowSelected = GoodsShop_dataGrid.SelectedItem as DataRowView;
                if (rowSelected != null)
                {
                    string id = rowSelected[0].ToString();
                    string name = rowSelected[1].ToString();
                    string barcode = rowSelected[2].ToString();
                    string firm = rowSelected[3].ToString();
                    string name_gr = rowSelected[4].ToString();
                    string price = rowSelected[5].ToString();

                    Console.WriteLine(rowSelected[0].ToString());

                    conn = new SqlConnection(@"Server = (local); Database = DB_NetworkOfGroceryStores; Uid = sa; Pwd = 11111111;");
                    conn.Open();
                    SqlCommand query = new SqlCommand("UPDATE Subtypes SET Name = '"+name_gr+ "' WHERE ID_subtypes = (SELECT ID_subtypes From Products Where ID_product = " + id + ")", conn);
                    query.ExecuteNonQuery();

                    SqlCommand query1 = new SqlCommand("UPDATE Products SET Name = '" + name + "', Firm = '" + firm + "' WHERE ID_product = '" + id + "'", conn);
                    query1.ExecuteNonQuery();

                    SqlCommand query2 = new SqlCommand("UPDATE Reserve SET Price = "+float.Parse(price)+", BarCode = '"+barcode+"' WHERE ID_product = '" + id + "'", conn);
                    query2.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Товар відредаговано в базі даних!", "Редагування: ", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                SelectGoods();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }
          
        }

        private void DeleteWorkers_button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataRowView rowSelected = GoodsShop_dataGrid.SelectedItem as DataRowView;
                if (rowSelected != null)
                {
                    string id = rowSelected[0].ToString();
                    Console.WriteLine(rowSelected[0].ToString());

                    conn = new SqlConnection(@"Server = (local); Database = DB_NetworkOfGroceryStores; Uid = sa; Pwd = 11111111;");
                    conn.Open();
                    //SqlCommand query = new SqlCommand("DELETE FROM Subtypes WHERE ID_subtypes = (SELECT ID_subtypes From Products Where ID_product = " + id + ")", conn);
                    //query.ExecuteNonQuery();

                    SqlCommand query2 = new SqlCommand("DELETE FROM Reserve WHERE ID_product = '" + id + "'", conn);
                    query2.ExecuteNonQuery();

                    SqlCommand query1 = new SqlCommand("DELETE FROM Products WHERE ID_product = '" + id + "'", conn);
                    query1.ExecuteNonQuery();

                    conn.Close();
                    MessageBox.Show("Товар видалено з бази даних!", "Редагування: ", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                SelectGoods();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }
        }

        private void SearchWorker_button_Click(object sender, RoutedEventArgs e)
        {
            SearchProductWindow prd = new SearchProductWindow();
            prd.Show();
        }
    }
}
