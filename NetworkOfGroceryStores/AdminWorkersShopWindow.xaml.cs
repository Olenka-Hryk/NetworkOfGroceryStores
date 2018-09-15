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
    /// Логика взаимодействия для MenedgerWorkersShopWindow.xaml
    /// </summary>
    public partial class MenedgerWorkersShopWindow : Window
    {
        SqlConnection conn;
        public MenedgerWorkersShopWindow()
        {
            InitializeComponent();
        }

        //Select Workers
        public void SelectWorkers()
        {
             try
            {
                
                conn = new SqlConnection(@"Server = (local); Database = DB_NetworkOfGroceryStores; Uid = sa; Pwd = 11111111;");
                conn.Open();
               
                SqlDataAdapter adapt = new SqlDataAdapter("SELECT ID_workers, Surname, Name, MiddleName, DateOfBirth FROM Workers", conn);
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                adapt.Fill(dt);
                dt.Columns["ID_workers"].ColumnName = "IDworkers";
                dt.Columns["SurName"].ColumnName = "Прізвище";
                dt.Columns["Name"].ColumnName = "Імя";
                dt.Columns["MiddleName"].ColumnName = "По батькові";
                dt.Columns["DateOfBirth"].ColumnName = "Дата народження";
               
                WorkersShop_dataGrid.ItemsSource = dt.DefaultView;
                WorkersShop_dataGrid.Columns[0].Visibility = Visibility.Hidden;
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
            SelectWorkers();
        }

        private void AddWorkers_button_Click(object sender, RoutedEventArgs e)
        {
            AdminNewWorkerWindow work = new AdminNewWorkerWindow();
            work.Show();
            SelectWorkers();
        }

        private void EditWorkers_button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataRowView rowSelected = WorkersShop_dataGrid.SelectedItem as DataRowView;
                if (rowSelected != null)
                {
                    string id = rowSelected[0].ToString();
                    string surname = rowSelected[1].ToString();
                    string name = rowSelected[2].ToString();
                    string middleName = rowSelected[3].ToString();
                    string dateOfBirth = Convert.ToDateTime(rowSelected[4]).ToString("yyyy-MM-dd");
                    Console.WriteLine(rowSelected[0].ToString());

                    conn = new SqlConnection(@"Server = (local); Database = DB_NetworkOfGroceryStores; Uid = sa; Pwd = 11111111;");
                    conn.Open();
                    SqlCommand query = new SqlCommand("UPDATE Workers SET Surname = '" + surname + "', Name = '" + name + "', MiddleName = '" + middleName + "', DateOfBirth = '" + dateOfBirth + "' WHERE ID_workers = " + id + "", conn);
                    query.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Працівника відредаговано в базі даних!", "Редагування: ", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                SelectWorkers();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }
        }

        private void SearchWorker_button_Click(object sender, RoutedEventArgs e)
        {
            SearchWorkerWindow wrk = new SearchWorkerWindow();
            wrk.Show();
        }

        private void DeleteWorkers_button_Click(object sender, RoutedEventArgs e)
        {
            DataRowView rowSelected = WorkersShop_dataGrid.SelectedItem as DataRowView;

            if (rowSelected != null)
            {
                Console.WriteLine(rowSelected[0].ToString());
            }
            try
            {
                conn = new SqlConnection(@"Server = (local); Database = DB_NetworkOfGroceryStores; Uid = sa; Pwd = 11111111;");
                conn.Open();
                SqlCommand query = new SqlCommand("DELETE FROM Workers WHERE ID_workers = " + rowSelected[0].ToString() + "", conn);
                query.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Працівника видалено з бази даних!", "Видалення: ", MessageBoxButton.OK, MessageBoxImage.Information);

                SelectWorkers();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }
        }
    }
}
