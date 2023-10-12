using System.ComponentModel.DataAnnotations;

namespace test_app.Service
{
    public class FamilyObject
    {
        public int ID { get; set; }
        public string firstName { get; set; } = string.Empty;
        public string lastName { get; set; } = string.Empty;
        public DateTime dateOfBirth { get; set; }
        public int? nationalityId { get; set; }
        public string countryName { get; set; } = string.Empty;
        public int relationshipId { get; set; }
        public string relationshipName { get; set; } = string.Empty;
        public int studentID { get; set; }
    }
}
