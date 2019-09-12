namespace FIRMA_MVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MARKA")]
    public partial class MARKA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MARKA()
        {
            URUNs = new HashSet<URUN>();
        }

        [Key]
        public int MARKA_REFNO { get; set; }

        [Required(ErrorMessage = "Marka Ad�n� giriniz!")]
        [StringLength(20, ErrorMessage = "�r�n ad� 3 ile 20 karakter aras�nda olmal�",
                         ErrorMessageResourceName = "",
                         ErrorMessageResourceType = null,
                         MinimumLength = 3)]
        public string MARKA_ADI { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<URUN> URUNs { get; set; }
    }
}
