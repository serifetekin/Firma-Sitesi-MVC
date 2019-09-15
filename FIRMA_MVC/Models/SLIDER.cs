namespace FIRMA_MVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SLIDER")]
    public partial class SLIDER
    {
        [Key]
        public int SLIDER_REFNO { get; set; }

        [Required(ErrorMessage = "Baþlýk giriniz!")]
        [StringLength(150, ErrorMessage = "Baþlýk 3 ile 150 karakter arasýnda olmalý",
                         ErrorMessageResourceName = "",
                         ErrorMessageResourceType = null,
                         MinimumLength = 3)]
        public string BASLIK { get; set; }

        [Required(ErrorMessage = "Bir link ekleyiniz.")]
        [StringLength(50)]
        public string LINK { get; set; }

        [Required(ErrorMessage = "Bir resim seçiniz")]
        [StringLength(50)]
        public string RESIM { get; set; }

        public bool DURUMU { get; set; }
    }
}
