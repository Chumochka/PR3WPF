//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WPFPR3.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Orders
    {
        public int ID_Order { get; set; }
        public int ID_Master { get; set; }
        public int ID_Part { get; set; }
        public int ID_Warehouse_employee { get; set; }
        public int ID_Supplier { get; set; }
    
        public virtual Masters Masters { get; set; }
        public virtual Parts Parts { get; set; }
        public virtual Suppliers Suppliers { get; set; }
        public virtual Warehouse_employees Warehouse_employees { get; set; }
    }
}