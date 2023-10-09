using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace test_app.Model
{
    public class Nationality
    {
        [Key, Column("NationalityID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NationalityId { get; set; }

        [Required]
        [MaxLength(250)]
        public string CountryName { get; set; } = string.Empty;

    }
}
