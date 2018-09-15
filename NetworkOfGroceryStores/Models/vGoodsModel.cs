using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkOfGroceryStores.Models
{
    public class vGoodsModel
    {
        public int ID_product { get; set; }
        public string Name { get; set; }
        public string Firm { get; set; }
        public string BarCode { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }
        public int ProductSize { get; set; }
        public string NameSubtypes { get; set; }

        public vGoodsModel(int id, string name, string firm, string barcode, float price, int quantity, int product_size, string nameSubtypes)
        {
            ID_product = id;
            Name = name;
            Firm = firm;
            BarCode = barcode;
            Price = price;
            Quantity = quantity;
            ProductSize = product_size;
            NameSubtypes = nameSubtypes;
        }
    }
}



// Goods model pr
//public List<vGoodsModel> GetCustomerList()
//{
//    List<vGoodsModel> custList = new List<vGoodsModel>();

//    const string command = "SELECT * FROM vProductOfSubtypes";
//    SqlCommand sqlCommand = new SqlCommand(command, conn);


//    using (var reader = sqlCommand.ExecuteReader())
//    {
//        while (reader.Read())
//        {
//            custList.Add(new vGoodsModel((int)reader.GetValue(0), (string)reader.GetValue(1), (string)reader.GetValue(2),
//                (decimal)reader.GetValue(3), (int)reader.GetValue(4), (double)reader.GetValue(5), (string)reader.GetValue(6)));

//        }
//    }
//    return custList;
//}

// Get Goods List
//public void GoodsListView()
//{
//    List<vGoodsModel> gList = GetCustomerList();

//    foreach (var goodslist in gList)
//    {

//        Console.WriteLine(goodslist);
//        var item = new ListViewItem(new string[]
//       {
//          goodslist.Name, goodslist.Firm, goodslist.Price.ToString(), goodslist.Quantity.ToString(),
//          goodslist.ProductSize.ToString(),goodslist.NameSubtypes
//       })
//        { Tag = goodslist.ID_product };

//        ProductOfSubtypes_dataGrid.Items.Add(item);
//    }

//    //for (var i = 0; i < customerListView.Columns.Count; i++)
//    //{
//    //    customerListView.AutoResizeColumn(i, ColumnHeaderAutoResizeStyle.HeaderSize);
//    // }
//}
