namespace FIRMA_MVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PROJE")]
    public partial class PROJE
    {
        [Key]
        [Display(Name = "Proje Refno")]
        public int PROJE_REFNO { get; set; }

        [Required(ErrorMessage = "Proje Adýný giriniz!")]
        [StringLength(50, ErrorMessage = "Proje adý 3 ile 50 karakter arasýnda olmalý",
                         ErrorMessageResourceName = "",
                         ErrorMessageResourceType = null,
                         MinimumLength = 3)]
        [Display(Name ="Proje Adý")]
        public string PROJE_ADI { get; set; }

        [Required(ErrorMessage = "Bir resim seçiniz")]
        [StringLength(50)]
        [Display(Name = "Resim")]
        public string RESIM { get; set; }

        [Required(ErrorMessage = "Açýklama giriniz!")]
        [StringLength(1000, ErrorMessage = "Açýklama 3 ile 50 karakter arasýnda olmalý",
                         ErrorMessageResourceName = "",
                         ErrorMessageResourceType = null,
                         MinimumLength = 3)]
        [Display(Name = "Açýklama")]
        public string ACIKLAMA { get; set; }
    }
}
