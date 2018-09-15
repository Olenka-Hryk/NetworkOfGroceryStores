using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows;

namespace NetworkOfGroceryStores
{
    /// <summary>
    /// Логика взаимодействия для SubtypesAllPoductsWindow.xaml
    /// </summary>
    public partial class SubtypesAllPoductsWindow : Window
    {
        SqlConnection conn;
        public SubtypesAllPoductsWindow()
        {
            InitializeComponent();
            if (!AcountWindow.AdminOrNot)
            {
                UpdateGoods_button.Visibility = Visibility.Hidden;
                UpdateSale_button.Visibility = Visibility.Hidden;
            }
        }

        private void Milk_button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                conn = new SqlConnection(@"Server = (local); Database = DB_NetworkOfGroceryStores; Uid = sa; Pwd = 11111111;");
                conn.Open();
                SqlDataAdapter adapt = new SqlDataAdapter("SELECT Name, Firm, Price, Quantity, ProductSize FROM vProductOfSubtypes Where NameSubtypes = 'Молочні продукти'", conn);
                DataSet ds = new DataSet();
                DataTable dt = new DataTable(); 
                adapt.Fill(dt);
                dt.Columns["Name"].ColumnName = "Назва продукту";
                dt.Columns["Firm"].ColumnName = "Назва фірми";
                dt.Columns["Price"].ColumnName = "Ціна";
                dt.Columns["Quantity"].ColumnName = "Кількість";
                dt.Columns["ProductSize"].ColumnName = "Розмір";
                ProductOfSubtypes_dataGrid.ItemsSource = dt.DefaultView;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }
                //var GroceryStoreBD = new DB_NetworkOfGroceryStoresEntities1();
                //ProductOfSubtypes_dataGrid.ItemsSource = GroceryStoreBD.vProductOfSubtypes.Where(c => c.Група == "Молочні продукти").Select(c => new { c.Назва_продукту, c.Виробник, c.Ціна, c.Кількість }).ToList();
            }

        private void Beef_button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                conn = new SqlConnection(@"Server = (local); Database = DB_NetworkOfGroceryStores; Uid = sa; Pwd = 11111111;");
                conn.Open();
                SqlDataAdapter adapt = new SqlDataAdapter("SELECT Name, Firm, Price, Quantity, ProductSize FROM vProductOfSubtypes Where NameSubtypes = 'Мясні продукти'", conn);
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                adapt.Fill(dt);
                dt.Columns["Name"].ColumnName = "Назва продукту";
                dt.Columns["Firm"].ColumnName = "Назва фірми";
                dt.Columns["Price"].ColumnName = "Ціна";
                dt.Columns["Quantity"].ColumnName = "Кількість";
                dt.Columns["ProductSize"].ColumnName = "Розмір";
                ProductOfSubtypes_dataGrid.ItemsSource = dt.DefaultView;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }
        }

        private void Fish_button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                conn = new SqlConnection(@"Server = (local); Database = DB_NetworkOfGroceryStores; Uid = sa; Pwd = 11111111;");
                conn.Open();
                SqlDataAdapter adapt = new SqlDataAdapter("SELECT Name, Firm, Price, Quantity, ProductSize FROM vProductOfSubtypes Where NameSubtypes = 'Рибні продукти'", conn);
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                adapt.Fill(dt);
                dt.Columns["Name"].ColumnName = "Назва продукту";
                dt.Columns["Firm"].ColumnName = "Назва фірми";
                dt.Columns["Price"].ColumnName = "Ціна";
                dt.Columns["Quantity"].ColumnName = "Кількість";
                dt.Columns["ProductSize"].ColumnName = "Розмір";
                ProductOfSubtypes_dataGrid.ItemsSource = dt.DefaultView;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }
        }

        private void Frozen_button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                conn = new SqlConnection(@"Server = (local); Database = DB_NetworkOfGroceryStores; Uid = sa; Pwd = 11111111;");
                conn.Open();
                SqlDataAdapter adapt = new SqlDataAdapter("SELECT Name, Firm, Price, Quantity, ProductSize FROM vProductOfSubtypes Where NameSubtypes = 'Заморожені продукти'", conn);
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                adapt.Fill(dt);
                dt.Columns["Name"].ColumnName = "Назва продукту";
                dt.Columns["Firm"].ColumnName = "Назва фірми";
                dt.Columns["Price"].ColumnName = "Ціна";
                dt.Columns["Quantity"].ColumnName = "Кількість";
                dt.Columns["ProductSize"].ColumnName = "Розмір";
                ProductOfSubtypes_dataGrid.ItemsSource = dt.DefaultView;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }
        }

        private void Backery_button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                conn = new SqlConnection(@"Server = (local); Database = DB_NetworkOfGroceryStores; Uid = sa; Pwd = 11111111;");
                conn.Open();
                SqlDataAdapter adapt = new SqlDataAdapter("SELECT Name, Firm, Price, Quantity, ProductSize FROM vProductOfSubtypes Where NameSubtypes = 'Бакалія'", conn);
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                adapt.Fill(dt);
                dt.Columns["Name"].ColumnName = "Назва продукту";
                dt.Columns["Firm"].ColumnName = "Назва фірми";
                dt.Columns["Price"].ColumnName = "Ціна";
                dt.Columns["Quantity"].ColumnName = "Кількість";
                dt.Columns["ProductSize"].ColumnName = "Розмір";
                ProductOfSubtypes_dataGrid.ItemsSource = dt.DefaultView;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }
        }

        private void Drinks_button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                conn = new SqlConnection(@"Server = (local); Database = DB_NetworkOfGroceryStores; Uid = sa; Pwd = 11111111;");
                conn.Open();
                SqlDataAdapter adapt = new SqlDataAdapter("SELECT Name, Firm, Price, Quantity, ProductSize FROM vProductOfSubtypes Where NameSubtypes = 'Напої'", conn);
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                adapt.Fill(dt);
                dt.Columns["Name"].ColumnName = "Назва продукту";
                dt.Columns["Firm"].ColumnName = "Назва фірми";
                dt.Columns["Price"].ColumnName = "Ціна";
                dt.Columns["Quantity"].ColumnName = "Кількість";
                dt.Columns["ProductSize"].ColumnName = "Розмір";
                ProductOfSubtypes_dataGrid.ItemsSource = dt.DefaultView;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }
        }

        private void Vegetable_button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                conn = new SqlConnection(@"Server = (local); Database = DB_NetworkOfGroceryStores; Uid = sa; Pwd = 11111111;");
                conn.Open();
                SqlDataAdapter adapt = new SqlDataAdapter("SELECT Name, Firm, Price, Quantity, ProductSize FROM vProductOfSubtypes Where NameSubtypes = 'Овочі'", conn);
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                adapt.Fill(dt);
                dt.Columns["Name"].ColumnName = "Назва продукту";
                dt.Columns["Firm"].ColumnName = "Назва фірми";
                dt.Columns["Price"].ColumnName = "Ціна";
                dt.Columns["Quantity"].ColumnName = "Кількість";
                dt.Columns["ProductSize"].ColumnName = "Розмір";
                ProductOfSubtypes_dataGrid.ItemsSource = dt.DefaultView;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }
        }

        private void Fruit_button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                conn = new SqlConnection(@"Server = (local); Database = DB_NetworkOfGroceryStores; Uid = sa; Pwd = 11111111;");
                conn.Open();
                SqlDataAdapter adapt = new SqlDataAdapter("SELECT Name, Firm, Price, Quantity, ProductSize FROM vProductOfSubtypes Where NameSubtypes = 'Фрукти'", conn);
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                adapt.Fill(dt);
                dt.Columns["Name"].ColumnName = "Назва продукту";
                dt.Columns["Firm"].ColumnName = "Назва фірми";
                dt.Columns["Price"].ColumnName = "Ціна";
                dt.Columns["Quantity"].ColumnName = "Кількість";
                dt.Columns["ProductSize"].ColumnName = "Розмір";
                ProductOfSubtypes_dataGrid.ItemsSource = dt.DefaultView;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }
        }

        private void Coffee_button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                conn = new SqlConnection(@"Server = (local); Database = DB_NetworkOfGroceryStores; Uid = sa; Pwd = 11111111;");
                conn.Open();
                SqlDataAdapter adapt = new SqlDataAdapter("SELECT Name, Firm, Price, Quantity, ProductSize FROM vProductOfSubtypes Where NameSubtypes = 'Чай та Кава'", conn);
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                adapt.Fill(dt);
                dt.Columns["Name"].ColumnName = "Назва продукту";
                dt.Columns["Firm"].ColumnName = "Назва фірми";
                dt.Columns["Price"].ColumnName = "Ціна";
                dt.Columns["Quantity"].ColumnName = "Кількість";
                dt.Columns["ProductSize"].ColumnName = "Розмір";
                ProductOfSubtypes_dataGrid.ItemsSource = dt.DefaultView;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }
        }

        private void Bread_button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                conn = new SqlConnection(@"Server = (local); Database = DB_NetworkOfGroceryStores; Uid = sa; Pwd = 11111111;");
                conn.Open();
                SqlDataAdapter adapt = new SqlDataAdapter("SELECT Name, Firm, Price, Quantity, ProductSize FROM vProductOfSubtypes Where NameSubtypes = 'Хлібобулочні вироби'", conn);
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                adapt.Fill(dt);
                dt.Columns["Name"].ColumnName = "Назва продукту";
                dt.Columns["Firm"].ColumnName = "Назва фірми";
                dt.Columns["Price"].ColumnName = "Ціна";
                dt.Columns["Quantity"].ColumnName = "Кількість";
                dt.Columns["ProductSize"].ColumnName = "Розмір";
                ProductOfSubtypes_dataGrid.ItemsSource = dt.DefaultView;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }
        }

        private void Sweet_button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                conn = new SqlConnection(@"Server = (local); Database = DB_NetworkOfGroceryStores; Uid = sa; Pwd = 11111111;");
                conn.Open();
                SqlDataAdapter adapt = new SqlDataAdapter("SELECT Name, Firm, Price, Quantity, ProductSize FROM vProductOfSubtypes Where NameSubtypes = 'Солодощі'", conn);
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                adapt.Fill(dt);
                dt.Columns["Name"].ColumnName = "Назва продукту";
                dt.Columns["Firm"].ColumnName = "Назва фірми";
                dt.Columns["Price"].ColumnName = "Ціна";
                dt.Columns["Quantity"].ColumnName = "Кількість";
                dt.Columns["ProductSize"].ColumnName = "Розмір";
                ProductOfSubtypes_dataGrid.ItemsSource = dt.DefaultView;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }
        }

        private void Back_button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            ShopMainWindow shop = new ShopMainWindow();
            shop.Show();
        }

        private void SearchProduct_button_Click(object sender, RoutedEventArgs e)
        {
            SearchProductWindow searchprd = new SearchProductWindow();
            searchprd.Show();
        }

        private void Sale_button_Click(object sender, RoutedEventArgs e)
        {
            SaleProductWindow Saleprd = new SaleProductWindow();
            Saleprd.Show();
        }

        private void Profile_button_Click(object sender, RoutedEventArgs e)
        {
            ProfileUserWindow profile = new ProfileUserWindow();
            profile.Show();
        }

        private void InfoProduct_button_Click(object sender, RoutedEventArgs e)
        {
            AdminGoodsWindow gds = new AdminGoodsWindow();
            gds.Show();
        }

        private void InfoSale_button_Click(object sender, RoutedEventArgs e)
        {
            AdminSaleWindow sale = new AdminSaleWindow();
            sale.Show();
        }
    }
}
