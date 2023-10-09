using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace test_app.Model
{
    public class Student
    {
        [Key, Column("ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [MaxLength(250)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MaxLength(250)]
        public string LastName { get; set; } = string.Empty;

        public DateTime DateOfBirth { get; set; }      
        public int? NationalityId { get; set; }

    }
}
