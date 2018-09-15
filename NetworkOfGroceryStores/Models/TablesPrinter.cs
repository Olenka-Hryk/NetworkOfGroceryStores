//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Controls;

//namespace NetworkOfGroceryStores.Models
//{
//    static class TablesPrinter
//    {
//        public static void printOrderCheque(DataGrid table)
//        {
//            using (DB_NetworkOfGroceryStoresEntities1 db = new DB_NetworkOfGroceryStoresEntities1())
//            {
//                var query = from product in db.vProductOfSubtypes
//                            select new
//                            {
//                                Name = product.Назва_продукту,
//                                Firm = product.Виробник,
//                                Price = product.Ціна
//                            };
//                table.ItemsSource = query.ToList();
//            }
//        }

//        public static void printProductOfSubtypes(DataGrid table)
//        {
//            using (DB_NetworkOfGroceryStoresEntities1 db = new DB_NetworkOfGroceryStoresEntities1())
//            {
//                var query = from subtype in db.vProductOfSubtypes
//                            select new
//                            {
//                                Name = subtype.Назва_продукту,
//                                Firm = subtype.Виробник,
//                                Price = subtype.Ціна,
//                                Quantity = subtype.Кількість,
//                                ProductSize = subtype.Розмір
//                            };
//                table.ItemsSource = query.ToList();
//            }
//        }

//        public static void printWorkersShop(DataGrid table)
//        {
//            using (DB_NetworkOfGroceryStoresEntities1 db = new DB_NetworkOfGroceryStoresEntities1())
//            {
//                var query = from worker in db.vTimetableWorkers
//                            select new
//                            {
//                                Surname = worker.Прізвище,
//                                Name = worker.Імя,
//                                MiddleName = worker.По_батькові,
//                                DataOfBirth = worker.Дата_народження,
//                                Salary = worker.Зарплата
//                            };
//                table.ItemsSource = query.ToList();
//            }
//        }

//        public static void printCustomerShop(DataGrid table)
//        {
//            using (DB_NetworkOfGroceryStoresEntities1 db = new DB_NetworkOfGroceryStoresEntities1())
//            {
//                var query = from customer in db.vCustomersShop
//                            select new
//                            {
//                                Surname = customer.Прізвище,
//                                Name = customer.Ім_я,
//                                MiddleName = customer.По_батькові,
//                                DateOfBirth = customer.Дата_народження,
//                                PhoneNumber = customer.Мобільний,
//                                NumberCard = customer.Номер_карти,
//                                Discount = customer.Знижка
//                            };
//                table.ItemsSource = query.ToList();
//            }
//        }
//    }
//}
