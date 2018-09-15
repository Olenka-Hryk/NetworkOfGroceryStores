using System.Windows;
using System.Windows.Media;

namespace NetworkOfGroceryStores
{
    /// <summary>
    /// Логика взаимодействия для AcountWindow.xaml
    /// </summary>
    public partial class AcountWindow : Window
    {
       public static bool AdminOrNot = false;
        public static string NAMEUSER;
        public static string NAMESTORE;
        public static string ADRESSSTORE;

        public AcountWindow()
        {
            InitializeComponent();
        }

        private void AvtorisationButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Login.Text == "dbadmin" && Password.Password == "12345")
                {
                    this.Visibility = Visibility.Visible;
                    NAMEUSER = "Адміністратор Урбанська Надія";
                    NAMESTORE = "ТзОВ ТВК Львівхолод Магазин Рукавичка";
                    ADRESSSTORE = "м.Львів, вул.Золота, 17";
                    AdminOrNot = true;
                    this.Hide();
                    ShopMainWindow adminPage = new ShopMainWindow();
                    adminPage.Show();
                }
                else if (Login.Text == "cashier" && Password.Password == "02042017")
                {
                    AdminOrNot = false;
                    NAMEUSER = "Касир Урбанська Надія";
                    NAMESTORE = "ТзОВ ТВК Львівхолод Магазин Рукавичка";
                    ADRESSSTORE = "м.Львів, вул.Золота, 17";
                    this.Hide();
                    ShopMainWindow cashierPage = new ShopMainWindow();
                    cashierPage.Show();
                }
                else
                {
                    MessageBox.Show("Не правильно введено логін або пароль! Будьте уважні!", "Помилка: ", MessageBoxButton.OK, MessageBoxImage.Error);
                    Login.Clear();
                    Password.Clear();
                    label1.Foreground = new SolidColorBrush(Colors.Red);
                    label1_Copy.Foreground = new SolidColorBrush(Colors.Red);
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
