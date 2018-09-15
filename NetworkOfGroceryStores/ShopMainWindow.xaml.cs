using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для ShopMainWindow.xaml
    /// </summary>
    public partial class ShopMainWindow : Window
    {
        SqlConnection conn;
        int COUNTPRODUCT = 0;
        float SUMMAofORDER = 0;
        double SUMMAofSALE = 0;
        double SUMMAofPDV = 0;

        int NomerOrderOfthisDay = 0;
        int NomerChequeOfthisMounth = 0; // зробити, щоб змінюкалася і зберігалася
        string price;

        public class Test
        {
            public string Test1 { get; set; }
            public string Test2 { get; set; }
            public string Test3 { get; set; }
            public string Test4 { get; set; }
            public string Test5 { get; set; }
            public string Test6 { get; set; }
        }

        public ShopMainWindow()
        {
            InitializeComponent();
            MethodlistBox.SelectedIndex = 0;
            MethodPaylistBox.SelectedIndex = 0;
            ID_product.Text = COUNTPRODUCT.ToString();
            

            // INFORMATION DETAILS
            Nomer.Text = NomerOrderOfthisDay.ToString();
            //Cashier.Text = acnt.Login.Text;  
            DataTime1.Text = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            Cashier.Text = AcountWindow.NAMEUSER;
            NameStore.Text = AcountWindow.NAMESTORE;
            AdressStore.Text = AcountWindow.ADRESSSTORE;
            //адреса

            if (!AcountWindow.AdminOrNot)
            {
                Workers_button.Visibility = Visibility.Hidden;
                Customers_button.Visibility = Visibility.Hidden;
            }

        }

        private void NewOrder_button_Click(object sender, RoutedEventArgs e)
        {
            //...............................................................................
            int quantityproducts = 0;
            //float zagalnasuma = 0;
            // float summaPDV = 0;
            NomerOrderOfthisDay++;
            NomerChequeOfthisMounth++;
            Nomer.Text = NomerOrderOfthisDay.ToString();
            NomerCheque.Text = NomerChequeOfthisMounth.ToString();
            QuantityProductsALL.Text = quantityproducts.ToString();
            Summary.Text = "0,00";
            PDV.Text = "4";
            SummaAll.Text = "0,00";
            PaySummaForCustomer.Text = "0,00";
            Hotivka.Text = "";
            Reshta.Text = "";
            BalanceCard.Text = "";
            SummaSalle.Text = "";
            Salle.Text = "";
            COUNTPRODUCT++;
            ID_product.Text = COUNTPRODUCT.ToString();
            //...............................................................................
            SUMMAofORDER = 0;

        }

        private void SubtypesGoods_button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            SubtypesAllPoductsWindow subtyp = new SubtypesAllPoductsWindow();
            subtyp.Show();
        }

        private void SearchGoods_button_Click(object sender, RoutedEventArgs e)
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

        private void Workers_button_Click(object sender, RoutedEventArgs e)
        {
            MenedgerWorkersShopWindow worker = new MenedgerWorkersShopWindow();
            worker.Show();
        }

        private void Customers_button_Click(object sender, RoutedEventArgs e)
        {
            AdminCustomersShopWindow customer = new AdminCustomersShopWindow();
            customer.Show();
        }

        private void Name_product_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void Name_product_KeyDown(object sender, KeyEventArgs e)
        {
            int selecteVal = MethodlistBox.SelectedIndex;

            if (e.Key == Key.Enter)
            {
                ID_product.Text = (COUNTPRODUCT).ToString();
                if (Name_product.Text != "")
                {
                    if (selecteVal == 0) //  за назвою продукту
                    {
                        try
                        {
                            string NamePrd = Name_product.Text.ToString();
                            conn = new SqlConnection(@"Server = (local); Database = DB_NetworkOfGroceryStores; Uid = sa; Pwd = 11111111;");
                            conn.Open();
                            SqlDataAdapter adapt = new SqlDataAdapter("SELECT Name, Firm, BarCode, Price, Quantity, ProductSize FROM vProductOfSubtypes Where Name = '" + NamePrd + "'", conn);
                            DataSet ds = new DataSet();
                            DataTable dt = new DataTable();
                            adapt.Fill(dt);

                            string i = dt.Rows[0][0].ToString();

                            if (i == null)
                            {
                                MessageBox.Show("Немає такого продукту!", "Помилка: ", MessageBoxButton.OK, MessageBoxImage.Information);
                                COUNTPRODUCT--;
                            }
                            else
                            {
                                dt.Columns["Name"].ColumnName = "Назва продукту";
                                dt.Columns["Firm"].ColumnName = "Виробник";
                                dt.Columns["BarCode"].ColumnName = "Штрих-код";
                                dt.Columns["Price"].ColumnName = "Ціна";
                                dt.Columns["Quantity"].ColumnName = "Кількість";
                                dt.Columns["ProductSize"].ColumnName = "Розмір";

                                ShopGoods_dataGrid.ItemsSource = dt.DefaultView;
                               // OrderGoods_dataGrid.Visibility = Visibility.Hidden;
                                string firm = dt.Rows[0][1].ToString();
                                Firm_product.Text = firm;
                                price = dt.Rows[0][3].ToString();
                                Price_product.Text = price;
                                BarCodeText.Text = dt.Rows[0][2].ToString();
                            }
                            conn.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Немає такого продукту!", "Помилка: ", MessageBoxButton.OK, MessageBoxImage.Information);
                            COUNTPRODUCT--;
                            MessageBox.Show(ex.Message);
                            conn.Close();
                        }
                    }
                }
            }
        }

        private void Quantity_product_KeyDown(object sender, KeyEventArgs e)
        {
                if (e.Key == Key.Enter)
                {
                 float result = (float.Parse(price.ToString()) * Int16.Parse(Quantity_product.Text.ToString()));
                 Summery_product.AppendText(result.ToString());
                }
            }

        private void AddGoods_button_Click(object sender, RoutedEventArgs e)
        {
            //try
            //{
            //    QuantityProductsALL.Text = COUNTPRODUCT.ToString();
            //    COUNTPRODUCT++;

            //    var data = new Test { Test1 = (COUNTPRODUCT - 1).ToString(), Test2 = Name_product.Text, Test3 = Firm_product.Text, Test4 = Price_product.Text, Test5 = Quantity_product.Text, Test6 = Summery_product.Text };
            //    SUMMAofORDER += (float)Convert.ToDouble(Summery_product.Text);
            //    Summary.Text = Convert.ToString(SUMMAofORDER);
            //    SUMMAofPDV = (Double.Parse(PDV.Text) * 0.1) * Convert.ToDouble(SUMMAofORDER);
            //    SummaAll.Text = (SUMMAofORDER + SUMMAofPDV).ToString();
            //    PaySummaForCustomer.Text = SummaAll.Text;
            //    if (Salle.Text != "")
            //    {
            //        SUMMAofSALE = (Double.Parse(Salle.Text) * 0.1) * Convert.ToDouble(SUMMAofORDER + SUMMAofPDV);
            //        SummaSalle.Text = SUMMAofSALE.ToString();
            //        PaySummaForCustomer.Text = (SUMMAofORDER + SUMMAofPDV - SUMMAofSALE).ToString();
            //    }
            //    ChequeGoods_dataGrid.Items.Add(data);

              
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Заповніть коректно данні!", "Помилка: ", MessageBoxButton.OK, MessageBoxImage.Information);
            //    MessageBox.Show(ex.Message);
            //}

            try
            {
                Console.WriteLine(Quantity_product.Text + "    " + BarCodeText.Text);
                conn = new SqlConnection(@"Server = (local); Database = DB_NetworkOfGroceryStores; Uid = sa; Pwd = 11111111;");
                conn.Open();
                SqlCommand query = new SqlCommand("UPDATE Reserve SET Quantity = (Quantity-" + int.Parse(Quantity_product.Text) + ") WHERE BarCode = '" + BarCodeText.Text + "'", conn);
                query.ExecuteNonQuery();

                SqlCommand query2 = new SqlCommand("INSERT INTO Orders VALUES(10004, (SELECT ID_sale FROM Sale Where ID_product = (SELECT ID_product From Products Where Name = '"+Name_product.Text+"')), (SELECT ID_reserve FROM Reserve WHERE ID_product = (SELECT ID_product From Products Where Name = '"+Name_product.Text+"')), "+float.Parse(PaySummaForCustomer.Text)+")", conn);
                query2.ExecuteNonQuery();
                //try
                //{
                //    Console.WriteLine(Salle.Text + "    " + QuantityProductsALL.Text);
                //    SqlCommand query1 = new SqlCommand("INSERT INTO Cheque VALUES((SELECT MAX(ID_order) FROM Orders), (SELECT ID_reserve FROM Orders WHERE ID_order = (SELECT MAX(ID_order) FROM Orders)), 20006, " + int.Parse(Salle.Text) + ", " + int.Parse(QuantityProductsALL.Text) + ", '2017-10-11')", conn);
                //    query1.ExecuteNonQuery();
                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show("  " + ex);
                //}

                conn.Close();
            }
            catch (Exception ex)
            {
             //   MessageBox.Show(ex.Message);
                conn.Close();
            }
            Name_product.Text = "";
            Firm_product.Text = "";
            Price_product.Text = "";
            Quantity_product.Text = "";
            Summery_product.Text = "";
        }

        private void SaveOrder_button_Click(object sender, RoutedEventArgs e)
        {
            COUNTPRODUCT = 0;
            MessageBox.Show("Кількість товару оновлено!", "Сповіщення: ", MessageBoxButton.OK, MessageBoxImage.Information);

        }

        private void Salle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                SUMMAofSALE = (Double.Parse(Salle.Text) * 0.1) * Convert.ToDouble(SUMMAofORDER + SUMMAofPDV);
                SummaSalle.Text = SUMMAofSALE.ToString();
                PaySummaForCustomer.Text = (SUMMAofORDER + SUMMAofPDV - SUMMAofSALE).ToString();
            }
        }

        private void DeleteGoods_button_Click(object sender, RoutedEventArgs e)
        {
            ShopGoods_dataGrid.ItemsSource = null;
            Name_product.Text = "";
            Firm_product.Text = "";
            Price_product.Text = "";
            Quantity_product.Text = "";
            Summery_product.Text = "";
        }

        private void DeleteOrder_button_Click(object sender, RoutedEventArgs e)
        {
            ShopGoods_dataGrid.ItemsSource = null;
            ChequeGoods_dataGrid.Items.Clear();
            QuantityProductsALL.Text = "0";
            Summary.Text = "0,00";
            PDV.Text = "4";
            SummaAll.Text = "0,00";
            PaySummaForCustomer.Text = "0,00";
            Name_product.Text = "";
            Firm_product.Text = "";
            Price_product.Text = "";
            Quantity_product.Text = "";
            Summery_product.Text = "";
            Hotivka.Text = "";
            Reshta.Text = "";
            BalanceCard.Text = "";
            SummaSalle.Text = "";
            Salle.Text = "";
            COUNTPRODUCT = 0;
        }

        private void BarCodeText_KeyDown(object sender, KeyEventArgs e)
        {
            if (BarCodeText.Text != "") //  за штрих-кодом
            {
                try
                {
                    string barCode = BarCodeText.Text.ToString();
                    conn = new SqlConnection(@"Server = (local); Database = DB_NetworkOfGroceryStores; Uid = sa; Pwd = 11111111;");
                    conn.Open();
                    SqlDataAdapter adapt = new SqlDataAdapter("SELECT Name, Firm, BarCode, Price, Quantity, ProductSize FROM vProductOfSubtypes Where BarCode = '" + barCode + "'", conn);
                    DataSet ds = new DataSet();
                    DataTable dt = new DataTable();
                    adapt.Fill(dt);

                    string i = dt.Rows[0][0].ToString();

                    if (i == null)
                    {
                        MessageBox.Show("Немає такого продукту!", "Помилка: ", MessageBoxButton.OK, MessageBoxImage.Information);
                        COUNTPRODUCT--;
                    }
                    else
                    {
                        dt.Columns["Name"].ColumnName = "Назва продукту";
                        dt.Columns["Firm"].ColumnName = "Виробник";
                        dt.Columns["BarCode"].ColumnName = "Штрих-код";
                        dt.Columns["Price"].ColumnName = "Ціна";
                        dt.Columns["Quantity"].ColumnName = "Кількість";
                        dt.Columns["ProductSize"].ColumnName = "Розмір";

                        ShopGoods_dataGrid.ItemsSource = dt.DefaultView;
                        // OrderGoods_dataGrid.Visibility = Visibility.Hidden;
                        string name= dt.Rows[0][0].ToString();
                        Name_product.Text = name;
                        string firm = dt.Rows[0][1].ToString();
                        Firm_product.Text = firm;
                        price = dt.Rows[0][3].ToString();
                        Price_product.Text = price;
                        BarCodeText.Text = dt.Rows[0][2].ToString();
                    }
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Немає такого продукту!", "Помилка: ", MessageBoxButton.OK, MessageBoxImage.Information);
                    COUNTPRODUCT--;
                    MessageBox.Show(ex.Message);
                    conn.Close();
                }
            }
            else
                MessageBox.Show("Введіть данні!", "Помилка: ", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Hotivka_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                float money = float.Parse(Hotivka.Text);
                Reshta.Text = (money - float.Parse(PaySummaForCustomer.Text)).ToString();
            }
        }

        private void CustomerName_KeyDown(object sender, KeyEventArgs e)
        {
            if (CustomerName.Text != "") //  за номером карти
            {
                try
                {
                    string card = CustomerName.Text.ToString();
                    conn = new SqlConnection(@"Server = (local); Database = DB_NetworkOfGroceryStores; Uid = sa; Pwd = 11111111;");
                    conn.Open();
                    SqlDataAdapter adapt = new SqlDataAdapter("SELECT Discount FROM Customers Where NumberCard = '" + card + "'", conn);
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
                        Salle.Text = dt.Rows[0][0].ToString();
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

        private void Info_button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Програмне забезпечення для купівлі-продажу товарів продуктового магазину. Виконала: Андрущакевич Олена Тарасівна Група: ПІ-32.", "Редагування: ", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void PrintOrderCheque_button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Друкую...", "Сповіщення: ", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Quantity_product_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}

