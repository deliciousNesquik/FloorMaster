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
    
    public partial class Materials
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Materials()
        {
            this.HistoryOfChangesInTheAmountOfMaterialInStock = new HashSet<HistoryOfChangesInTheAmountOfMaterialInStock>();
            this.TheHistoryOfSuppliesOfMaterials = new HashSet<TheHistoryOfSuppliesOfMaterials>();
            this.Products = new HashSet<Products>();
        }
    
        public string Article { get; set; }
        public int TypeOfProduct { get; set; }
        public string NameProduct { get; set; }
        public int Supplier { get; set; }
        public int CountInPackage { get; set; }
        public int UnitsOfMeasurement { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public decimal Cost { get; set; }
        public int CountInStorage { get; set; }
        public int MinimumAllowableQuantity { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HistoryOfChangesInTheAmountOfMaterialInStock> HistoryOfChangesInTheAmountOfMaterialInStock { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TheHistoryOfSuppliesOfMaterials> TheHistoryOfSuppliesOfMaterials { get; set; }
        public virtual UnitsOfMeasurement UnitsOfMeasurement1 { get; set; }
        public virtual Suppliers Suppliers { get; set; }
        public virtual TypeOfMaterials TypeOfMaterials { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Products> Products { get; set; }
    }
}
