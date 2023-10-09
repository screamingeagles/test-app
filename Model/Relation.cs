using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace test_app.Model
{
    public class Relation
    {
        [Key, Column("RelationshipId")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RelationshipId { get; set; }

        [Required]
        [MaxLength(250)]
        public string RelationshipName { get; set; } = string.Empty;
    }
}
