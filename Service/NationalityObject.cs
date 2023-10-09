using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace test_app.Service
{
    public class NationalityObject
    {
        public int NationalityId { get; set; }

        public string CountryName { get; set; } = string.Empty;
    }
}
