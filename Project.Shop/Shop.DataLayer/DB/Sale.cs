namespace Shop.DataLayer.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sale")]
    public partial class Sale
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sale()
        {
            SalePos = new HashSet<SalePos>();
        }

        public int SaleId { get; set; }

        public int NumberSale { get; set; }

        [Required]
        [StringLength(10)]
        public string UserPhone { get; set; }

        [Required]
        [StringLength(80)]
        public string UserEmail { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateSale { get; set; }

        [Column(TypeName = "money")]
        public decimal Summa { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SalePos> SalePos { get; set; }
    }
}
