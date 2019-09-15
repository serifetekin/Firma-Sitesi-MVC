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

        [Required(ErrorMessage = "Proje Ad�n� giriniz!")]
        [StringLength(50, ErrorMessage = "Proje ad� 3 ile 50 karakter aras�nda olmal�",
                         ErrorMessageResourceName = "",
                         ErrorMessageResourceType = null,
                         MinimumLength = 3)]
        [Display(Name ="Proje Ad�")]
        public string PROJE_ADI { get; set; }

        [Required(ErrorMessage = "Bir resim se�iniz")]
        [StringLength(50)]
        [Display(Name = "Resim")]
        public string RESIM { get; set; }

        [Required(ErrorMessage = "A��klama giriniz!")]
        [StringLength(1000, ErrorMessage = "A��klama 3 ile 50 karakter aras�nda olmal�",
                         ErrorMessageResourceName = "",
                         ErrorMessageResourceType = null,
                         MinimumLength = 3)]
        [Display(Name = "A��klama")]
        public string ACIKLAMA { get; set; }
    }
}
