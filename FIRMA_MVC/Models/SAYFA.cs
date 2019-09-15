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

        [Required(ErrorMessage = "Ba�l�k giriniz!")]
        [StringLength(100, ErrorMessage = "Ba�l�k 3 ile 100 karakter aras�nda olmal�",
                         ErrorMessageResourceName = "",
                         ErrorMessageResourceType = null,
                         MinimumLength = 3)]
        public string BASLIK { get; set; }

        [Required(ErrorMessage = "��erik giriniz!")]
        public string ICERIK { get; set; }
    }
}
