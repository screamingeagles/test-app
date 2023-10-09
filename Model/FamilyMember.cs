using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace test_app.Model
{
    public class FamilyMember
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

        [Required]
        public DateTime DateOfBirth { get; set; }

        public int? NationalityId { get; set; }

        [Required]
        public int RelationshipId { get; set; }

        [Required]
        [ForeignKey("Student")]
        public int StudentID { get; set; }
    }
}
