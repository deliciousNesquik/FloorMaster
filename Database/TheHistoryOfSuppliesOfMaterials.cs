//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FloorMaster.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class TheHistoryOfSuppliesOfMaterials
    {
        public int ID { get; set; }
        public string Article { get; set; }
        public int Supplier { get; set; }
        public System.DateTime Date { get; set; }
        public int Count { get; set; }
        public int Master { get; set; }
    
        public virtual Employee Employee { get; set; }
        public virtual Materials Materials { get; set; }
        public virtual Suppliers Suppliers { get; set; }
    }
}