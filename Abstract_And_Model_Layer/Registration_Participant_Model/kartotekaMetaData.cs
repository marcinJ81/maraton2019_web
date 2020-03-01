using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_And_Model_Layer.Registration_Participant_Model
{
    [MetadataType(typeof(kartotekaMetaData))]
    public partial class kartoteka2
    {

    }

    public class kartotekaMetaData
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Pole nie może być puste")]
        [Display(Name = "Wymagane")]
        [StringLength(50, ErrorMessage = "Minimum 3 znaki, nie więcej niż 50", MinimumLength = 3)]
        public string kart_imie { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Pole nie może być puste")]
        [Display(Name = "Wymagane")]
        [StringLength(50, ErrorMessage = "Minimum 3 znaki, nie więcej niż 50", MinimumLength = 3)]
        public string kart_nazwisko { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Pole nie może być puste")]
        [StringLength(50, ErrorMessage = "Minimum 5 znaki", MinimumLength = 5)]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Adres email wymagany")]
        public string kart_email { get; set; }

        [Required(ErrorMessage = "Pole nie może być puste")]
        // [maratonMszana_v3.Models.kartoteka2Ext.MustBeTrue(ErrorMessage = "Akceptacja regulaminu wymagana")]
        public Nullable<bool> kart_wpis_rejestacja { get; set; }

        [Required(ErrorMessage = "Wymagane minimum dziewięć cyfr")]
        [StringLength(11, ErrorMessage = "dziewięć cyfr", MinimumLength = 9)]
        public string kart_telefon { get; set; }

        [Required(ErrorMessage = "Wymagane")]
        //[Range(typeof(DateTime), "1950-01-01", "2001-06-01", ErrorMessage = "Data urodzenia musi być pomiędzy {1} i {2}")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-mm-DD}")]
        public Nullable<System.DateTime> kart_dataUr { get; set; }

        [Range(1, 100, ErrorMessage = "Wymagane")]
        [Required(ErrorMessage = "Wybierz grupę")]
        public int? grup_id { get; set; }

        [Required(ErrorMessage = "Wybierz dystans.")]
        [Range(1, 9, ErrorMessage = "Wymagane")]
        public int dys_id { get; set; }

        [Range(1, 2, ErrorMessage = "Wymagane")]
        [Required(ErrorMessage = "Wymagane")]
        public int plec_id { get; set; }

        public string kart_uwagi { get; set; }
    }
}
