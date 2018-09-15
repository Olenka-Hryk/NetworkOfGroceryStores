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
    /// Логика взаимодействия для SaleProductWindow.xaml
    /// </summary>
    public partial class SaleProductWindow : Window
    {
        SqlConnection conn;
        public SaleProductWindow()
        {
            InitializeComponent();
            MethodSearchSalelistBox.SelectedIndex = 0;
        }

        private void SearchNow_button_Click(object sender, RoutedEventArgs e)
        {
            int selecteVal = MethodSearchSalelistBox.SelectedIndex;

            if (selecteVal == 0) // акція місяця
            {
                try
                {
                    conn = new SqlConnection(@"Server = (local); Database = DB_NetworkOfGroceryStores; Uid = sa; Pwd = 11111111;");
                    conn.Open();
                    SqlDataAdapter adapt = new SqlDataAdapter("SELECT Name, Firm, Quantity, Name_sale, Percents, DateOfStart, DateOfFinish FROM vSaleShop Where Name_sale = 'Акція місяця'", conn);
                    DataSet ds = new DataSet();
                    DataTable dt = new DataTable();
                    adapt.Fill(dt);
                    dt.Columns["Name"].ColumnName = "Назва продукту";
                    dt.Columns["Firm"].ColumnName = "Виробник";
                    dt.Columns["Quantity"].ColumnName = "Кількість";
                    dt.Columns["Name_sale"].ColumnName = "Акція";
                    dt.Columns["Percents"].ColumnName = "Відсоток";
                    dt.Columns["DateOfStart"].ColumnName = "Початок";
                    dt.Columns["DateOfFinish"].ColumnName = "Кінець";
                    ProductOfSale_dataGrid.ItemsSource = dt.DefaultView;
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    conn.Close();
                }
            }

            if (selecteVal == 1) // акція тижня
            {
                try
                {
                    conn = new SqlConnection(@"Server = (local); Database = DB_NetworkOfGroceryStores; Uid = sa; Pwd = 11111111;");
                    conn.Open();
                    SqlDataAdapter adapt = new SqlDataAdapter("SELECT Name, Firm, Quantity, Name_sale, Percents, DateOfStart, DateOfFinish FROM vSaleShop Where Name_sale = 'Акція тижня'", conn);
                    DataSet ds = new DataSet();
                    DataTable dt = new DataTable();
                    adapt.Fill(dt);
                    dt.Columns["Name"].ColumnName = "Назва продукту";
                    dt.Columns["Firm"].ColumnName = "Виробник";
                    dt.Columns["Quantity"].ColumnName = "Кількість";
                    dt.Columns["Name_sale"].ColumnName = "Акція";
                    dt.Columns["Percents"].ColumnName = "Відсоток";
                    dt.Columns["DateOfStart"].ColumnName = "Початок";
                    dt.Columns["DateOfFinish"].ColumnName = "Кінець";
                    ProductOfSale_dataGrid.ItemsSource = dt.DefaultView;
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    conn.Close();
                }
            }

            if (selecteVal == 2) // акція дня
            {
                try
                {
                    conn = new SqlConnection(@"Server = (local); Database = DB_NetworkOfGroceryStores; Uid = sa; Pwd = 11111111;");
                    conn.Open();
                    SqlDataAdapter adapt = new SqlDataAdapter("SELECT Name, Firm, Quantity, Name_sale, Percents, DateOfStart, DateOfFinish FROM vSaleShop Where Name_sale = 'Акція дня'", conn);
                    DataSet ds = new DataSet();
                    DataTable dt = new DataTable();
                    adapt.Fill(dt);
                    dt.Columns["Name"].ColumnName = "Назва продукту";
                    dt.Columns["Firm"].ColumnName = "Виробник";
                    dt.Columns["Quantity"].ColumnName = "Кількість";
                    dt.Columns["Name_sale"].ColumnName = "Акція";
                    dt.Columns["Percents"].ColumnName = "Відсоток";
                    dt.Columns["DateOfStart"].ColumnName = "Початок";
                    dt.Columns["DateOfFinish"].ColumnName = "Кінець";
                    ProductOfSale_dataGrid.ItemsSource = dt.DefaultView;
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    conn.Close();
                }
            }

            if (selecteVal == 3) // Майбутня  акція
            {
                try
                {
                    string s = DateTime.Now.ToString("yyyy-MM-dd");
                    Console.WriteLine(s);

                    conn = new SqlConnection(@"Server = (local); Database = DB_NetworkOfGroceryStores; Uid = sa; Pwd = 11111111;");
                    conn.Open();
                    SqlDataAdapter adapt = new SqlDataAdapter("SELECT Name, Firm, Quantity, Name_sale, Percents, DateOfStart, DateOfFinish FROM vSaleShop Where DateOfStart > '"+s+"'", conn);
                    DataSet ds = new DataSet();
                    DataTable dt = new DataTable();
                    adapt.Fill(dt);
                    dt.Columns["Name"].ColumnName = "Назва продукту";
                    dt.Columns["Firm"].ColumnName = "Виробник";
                    dt.Columns["Quantity"].ColumnName = "Кількість";
                    dt.Columns["Name_sale"].ColumnName = "Акція";
                    dt.Columns["Percents"].ColumnName = "Відсоток";
                    dt.Columns["DateOfStart"].ColumnName = "Початок";
                    dt.Columns["DateOfFinish"].ColumnName = "Кінець";
                    ProductOfSale_dataGrid.ItemsSource = dt.DefaultView;
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    conn.Close();
                }
            }
        }
    }
}
