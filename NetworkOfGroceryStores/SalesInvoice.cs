//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NetworkOfGroceryStores
{
    using System;
    using System.Collections.Generic;
    
    public partial class SalesInvoice
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SalesInvoice()
        {
            this.Sales_Reserve_Invoice = new HashSet<Sales_Reserve_Invoice>();
        }
    
        public int ID_SalersInvoice { get; set; }
        public int ID_invoice { get; set; }
        public int ID_workers { get; set; }
        public Nullable<System.DateTime> DeliveryDate { get; set; }
    
        public virtual InvoiceForGoods InvoiceForGoods { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sales_Reserve_Invoice> Sales_Reserve_Invoice { get; set; }
        public virtual Workers Workers { get; set; }
    }
}
