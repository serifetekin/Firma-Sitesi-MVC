namespace FIRMA_MVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SAYFA")]
    public partial class SAYFA
    {
        [Key]
        public int SAYFA_REFNO { get; set; }

        [Required(ErrorMessage = "Baþlýk giriniz!")]
        [StringLength(100, ErrorMessage = "Baþlýk 3 ile 100 karakter arasýnda olmalý",
                         ErrorMessageResourceName = "",
                         ErrorMessageResourceType = null,
                         MinimumLength = 3)]
        public string BASLIK { get; set; }

        [Required(ErrorMessage = "Ýçerik giriniz!")]
        public string ICERIK { get; set; }
    }
}
