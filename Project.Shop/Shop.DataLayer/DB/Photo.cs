namespace Shop.DataLayer.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Photo")]
    public partial class Photo
    {
        public int PhotoId { get; set; }

        public int? GoodId { get; set; }

        [Required]
        [StringLength(200)]
        public string PhotoPath { get; set; }
    }
}
