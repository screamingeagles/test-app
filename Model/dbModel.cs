﻿using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;


namespace test_app.Model
{
    public class dbModel : DbContext
    {
        public dbModel(DbContextOptions<dbModel> options): base(options)
        {
        }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

           modelBuilder.Entity<Nationality>().HasData(
                 new Nationality { NationalityId = 1, CountryName = "Afghanistan" },
                 new Nationality { NationalityId = 2, CountryName = "Åland Islands" },
                 new Nationality { NationalityId = 3, CountryName = "Albania" },
                 new Nationality { NationalityId = 4, CountryName = "Algeria" },
                 new Nationality { NationalityId = 5, CountryName = "American Samoa" },
                 new Nationality { NationalityId = 6, CountryName = "AndorrA" },
                 new Nationality { NationalityId = 7, CountryName = "Angola" },
                 new Nationality { NationalityId = 8, CountryName = "Anguilla" },
                 new Nationality { NationalityId = 9, CountryName = "Antarctica" },
                 new Nationality { NationalityId = 10, CountryName = "Antigua and Barbuda" },
                 new Nationality { NationalityId = 11, CountryName = "Argentina" },
                 new Nationality { NationalityId = 12, CountryName = "Armenia" },
                 new Nationality { NationalityId = 13, CountryName = "Aruba" },
                 new Nationality { NationalityId = 14, CountryName = "Australia" },
                 new Nationality { NationalityId = 15, CountryName = "Austria" },
                 new Nationality { NationalityId = 16, CountryName = "Azerbaijan" },
                 new Nationality { NationalityId = 17, CountryName = "Bahamas" },
                 new Nationality { NationalityId = 18, CountryName = "Bahrain" },
                 new Nationality { NationalityId = 19, CountryName = "Bangladesh" },
                 new Nationality { NationalityId = 20, CountryName = "Barbados" },
                 new Nationality { NationalityId = 21, CountryName = "Belarus" },
                 new Nationality { NationalityId = 22, CountryName = "Belgium" },
                 new Nationality { NationalityId = 23, CountryName = "Belize" },
                 new Nationality { NationalityId = 24, CountryName = "Benin" },
                 new Nationality { NationalityId = 25, CountryName = "Bermuda" },
                 new Nationality { NationalityId = 26, CountryName = "Bhutan" },
                 new Nationality { NationalityId = 27, CountryName = "Bolivia" },
                 new Nationality { NationalityId = 28, CountryName = "Bosnia and Herzegovina" },
                 new Nationality { NationalityId = 29, CountryName = "Botswana" },
                 new Nationality { NationalityId = 30, CountryName = "Bouvet Island" },
                 new Nationality { NationalityId = 31, CountryName = "Brazil" },
                 new Nationality { NationalityId = 32, CountryName = "British Indian Ocean Territory" },
                 new Nationality { NationalityId = 33, CountryName = "Brunei Darussalam" },
                 new Nationality { NationalityId = 34, CountryName = "Bulgaria" },
                 new Nationality { NationalityId = 35, CountryName = "Burkina Faso" },
                 new Nationality { NationalityId = 36, CountryName = "Burundi" },
                 new Nationality { NationalityId = 37, CountryName = "Cambodia" },
                 new Nationality { NationalityId = 38, CountryName = "Cameroon" },
                 new Nationality { NationalityId = 39, CountryName = "Canada" },
                 new Nationality { NationalityId = 40, CountryName = "Cape Verde" },
                 new Nationality { NationalityId = 41, CountryName = "Cayman Islands" },
                 new Nationality { NationalityId = 42, CountryName = "Central African Republic" },
                 new Nationality { NationalityId = 43, CountryName = "Chad" },
                 new Nationality { NationalityId = 44, CountryName = "Chile" },
                 new Nationality { NationalityId = 45, CountryName = "China" },
                 new Nationality { NationalityId = 46, CountryName = "Christmas Island" },
                 new Nationality { NationalityId = 47, CountryName = "Cocos (Keeling) Islands" },
                 new Nationality { NationalityId = 48, CountryName = "Colombia" },
                 new Nationality { NationalityId = 49, CountryName = "Comoros" },
                 new Nationality { NationalityId = 50, CountryName = "Congo" },
                 new Nationality { NationalityId = 51, CountryName = "Congo, The Democratic Republic of the" },
                 new Nationality { NationalityId = 52, CountryName = "Cook Islands" },
                 new Nationality { NationalityId = 53, CountryName = "Costa Rica" },
                 new Nationality { NationalityId = 54, CountryName = "Cote D`Ivoire" },
                 new Nationality { NationalityId = 55, CountryName = "Croatia" },
                 new Nationality { NationalityId = 56, CountryName = "Cuba" },
                 new Nationality { NationalityId = 57, CountryName = "Cyprus" },
                 new Nationality { NationalityId = 58, CountryName = "Czech Republic" },
                 new Nationality { NationalityId = 59, CountryName = "Denmark" },
                 new Nationality { NationalityId = 60, CountryName = "Djibouti" },
                 new Nationality { NationalityId = 61, CountryName = "Dominica" },
                 new Nationality { NationalityId = 62, CountryName = "Dominican Republic" },
                 new Nationality { NationalityId = 63, CountryName = "Ecuador" },
                 new Nationality { NationalityId = 64, CountryName = "Egypt" },
                 new Nationality { NationalityId = 65, CountryName = "El Salvador" },
                 new Nationality { NationalityId = 66, CountryName = "Equatorial Guinea" },
                 new Nationality { NationalityId = 67, CountryName = "Eritrea" },
                 new Nationality { NationalityId = 68, CountryName = "Estonia" },
                 new Nationality { NationalityId = 69, CountryName = "Ethiopia" },
                 new Nationality { NationalityId = 70, CountryName = "Falkland Islands (Malvinas)" },
                 new Nationality { NationalityId = 71, CountryName = "Faroe Islands" },
                 new Nationality { NationalityId = 72, CountryName = "Fiji" },
                 new Nationality { NationalityId = 73, CountryName = "Finland" },
                 new Nationality { NationalityId = 74, CountryName = "France" },
                 new Nationality { NationalityId = 75, CountryName = "French Guiana" },
                 new Nationality { NationalityId = 76, CountryName = "French Polynesia" },
                 new Nationality { NationalityId = 77, CountryName = "French Southern Territories" },
                 new Nationality { NationalityId = 78, CountryName = "Gabon" },
                 new Nationality { NationalityId = 79, CountryName = "Gambia" },
                 new Nationality { NationalityId = 80, CountryName = "Georgia" },
                 new Nationality { NationalityId = 81, CountryName = "Germany" },
                 new Nationality { NationalityId = 82, CountryName = "Ghana" },
                 new Nationality { NationalityId = 83, CountryName = "Gibraltar" },
                 new Nationality { NationalityId = 84, CountryName = "Greece" },
                 new Nationality { NationalityId = 85, CountryName = "Greenland" },
                 new Nationality { NationalityId = 86, CountryName = "Grenada" },
                 new Nationality { NationalityId = 87, CountryName = "Guadeloupe" },
                 new Nationality { NationalityId = 88, CountryName = "Guam" },
                 new Nationality { NationalityId = 89, CountryName = "Guatemala" },
                 new Nationality { NationalityId = 90, CountryName = "Guernsey" },
                 new Nationality { NationalityId = 91, CountryName = "Guinea" },
                 new Nationality { NationalityId = 92, CountryName = "Guinea-Bissau" },
                 new Nationality { NationalityId = 93, CountryName = "Guyana" },
                 new Nationality { NationalityId = 94, CountryName = "Haiti" },
                 new Nationality { NationalityId = 95, CountryName = "Heard Island and Mcdonald Islands" },
                 new Nationality { NationalityId = 96, CountryName = "Holy See (Vatican City State)" },
                 new Nationality { NationalityId = 97, CountryName = "Honduras" },
                 new Nationality { NationalityId = 98, CountryName = "Hong Kong" },
                 new Nationality { NationalityId = 99, CountryName = "Hungary" },
                 new Nationality { NationalityId = 100, CountryName = "Iceland" },
                 new Nationality { NationalityId = 101, CountryName = "India" },
                 new Nationality { NationalityId = 102, CountryName = "Indonesia" },
                 new Nationality { NationalityId = 103, CountryName = "Iran, Islamic Republic Of" },
                 new Nationality { NationalityId = 104, CountryName = "Iraq" },
                 new Nationality { NationalityId = 105, CountryName = "Ireland" },
                 new Nationality { NationalityId = 106, CountryName = "Isle of Man" },
                 new Nationality { NationalityId = 107, CountryName = "Israel" },
                 new Nationality { NationalityId = 108, CountryName = "Italy" },
                 new Nationality { NationalityId = 109, CountryName = "Jamaica" },
                 new Nationality { NationalityId = 110, CountryName = "Japan" },
                 new Nationality { NationalityId = 111, CountryName = "Jersey" },
                 new Nationality { NationalityId = 112, CountryName = "Jordan" },
                 new Nationality { NationalityId = 113, CountryName = "Kazakhstan" },
                 new Nationality { NationalityId = 114, CountryName = "Kenya" },
                 new Nationality { NationalityId = 115, CountryName = "Kiribati" },
                 new Nationality { NationalityId = 116, CountryName = "Korea, Democratic Peoples Republic of" },
                 new Nationality { NationalityId = 117, CountryName = "Korea, Republic of" },
                 new Nationality { NationalityId = 118, CountryName = "Kuwait" },
                 new Nationality { NationalityId = 119, CountryName = "Kyrgyzstan" },
                 new Nationality { NationalityId = 120, CountryName = "Lao Peoples Democratic Republic" },
                 new Nationality { NationalityId = 121, CountryName = "Latvia" },
                 new Nationality { NationalityId = 122, CountryName = "Lebanon" },
                 new Nationality { NationalityId = 123, CountryName = "Lesotho" },
                 new Nationality { NationalityId = 124, CountryName = "Liberia" },
                 new Nationality { NationalityId = 125, CountryName = "Libyan Arab Jamahiriya" },
                 new Nationality { NationalityId = 126, CountryName = "Liechtenstein" },
                 new Nationality { NationalityId = 127, CountryName = "Lithuania" },
                 new Nationality { NationalityId = 128, CountryName = "Luxembourg" },
                 new Nationality { NationalityId = 129, CountryName = "Macao" },
                 new Nationality { NationalityId = 130, CountryName = "Macedonia, The Former Yugoslav Republic of" },
                 new Nationality { NationalityId = 131, CountryName = "Madagascar" },
                 new Nationality { NationalityId = 132, CountryName = "Malawi" },
                 new Nationality { NationalityId = 133, CountryName = "Malaysia" },
                 new Nationality { NationalityId = 134, CountryName = "Maldives" },
                 new Nationality { NationalityId = 135, CountryName = "Mali" },
                 new Nationality { NationalityId = 136, CountryName = "Malta" },
                 new Nationality { NationalityId = 137, CountryName = "Marshall Islands" },
                 new Nationality { NationalityId = 138, CountryName = "Martinique" },
                 new Nationality { NationalityId = 139, CountryName = "Mauritania" },
                 new Nationality { NationalityId = 140, CountryName = "Mauritius" },
                 new Nationality { NationalityId = 141, CountryName = "Mayotte" },
                 new Nationality { NationalityId = 142, CountryName = "Mexico" },
                 new Nationality { NationalityId = 143, CountryName = "Micronesia, Federated States of" },
                 new Nationality { NationalityId = 144, CountryName = "Moldova, Republic of" },
                 new Nationality { NationalityId = 145, CountryName = "Monaco" },
                 new Nationality { NationalityId = 146, CountryName = "Mongolia" },
                 new Nationality { NationalityId = 147, CountryName = "Montserrat" },
                 new Nationality { NationalityId = 148, CountryName = "Morocco" },
                 new Nationality { NationalityId = 149, CountryName = "Mozambique" },
                 new Nationality { NationalityId = 150, CountryName = "Myanmar" },
                 new Nationality { NationalityId = 151, CountryName = "Namibia" },
                 new Nationality { NationalityId = 152, CountryName = "Nauru" },
                 new Nationality { NationalityId = 153, CountryName = "Nepal" },
                 new Nationality { NationalityId = 154, CountryName = "Netherlands" },
                 new Nationality { NationalityId = 155, CountryName = "Netherlands Antilles" },
                 new Nationality { NationalityId = 156, CountryName = "New Caledonia" },
                 new Nationality { NationalityId = 157, CountryName = "New Zealand" },
                 new Nationality { NationalityId = 158, CountryName = "Nicaragua" },
                 new Nationality { NationalityId = 159, CountryName = "Niger" },
                 new Nationality { NationalityId = 160, CountryName = "Nigeria" },
                 new Nationality { NationalityId = 161, CountryName = "Niue" },
                 new Nationality { NationalityId = 162, CountryName = "Norfolk Island" },
                 new Nationality { NationalityId = 163, CountryName = "Northern Mariana Islands" },
                 new Nationality { NationalityId = 164, CountryName = "Norway" },
                 new Nationality { NationalityId = 165, CountryName = "Oman" },
                 new Nationality { NationalityId = 166, CountryName = "Pakistan" },
                 new Nationality { NationalityId = 167, CountryName = "Palau" },
                 new Nationality { NationalityId = 168, CountryName = "Palestinian Territory, Occupied" },
                 new Nationality { NationalityId = 169, CountryName = "Panama" },
                 new Nationality { NationalityId = 170, CountryName = "Papua New Guinea" },
                 new Nationality { NationalityId = 171, CountryName = "Paraguay" },
                 new Nationality { NationalityId = 172, CountryName = "Peru" },
                 new Nationality { NationalityId = 173, CountryName = "Philippines" },
                 new Nationality { NationalityId = 174, CountryName = "Pitcairn" },
                 new Nationality { NationalityId = 175, CountryName = "Poland" },
                 new Nationality { NationalityId = 176, CountryName = "Portugal" },
                 new Nationality { NationalityId = 177, CountryName = "Puerto Rico" },
                 new Nationality { NationalityId = 178, CountryName = "Qatar" },
                 new Nationality { NationalityId = 179, CountryName = "Reunion" },
                 new Nationality { NationalityId = 180, CountryName = "Romania" },
                 new Nationality { NationalityId = 181, CountryName = "Russian Federation" },
                 new Nationality { NationalityId = 182, CountryName = "RWANDA" },
                 new Nationality { NationalityId = 183, CountryName = "Saint Helena" },
                 new Nationality { NationalityId = 184, CountryName = "Saint Kitts and Nevis" },
                 new Nationality { NationalityId = 185, CountryName = "Saint Lucia" },
                 new Nationality { NationalityId = 186, CountryName = "Saint Pierre and Miquelon" },
                 new Nationality { NationalityId = 187, CountryName = "Saint Vincent and the Grenadines" },
                 new Nationality { NationalityId = 188, CountryName = "Samoa" },
                 new Nationality { NationalityId = 189, CountryName = "San Marino" },
                 new Nationality { NationalityId = 190, CountryName = "Sao Tome and Principe" },
                 new Nationality { NationalityId = 191, CountryName = "Saudi Arabia" },
                 new Nationality { NationalityId = 192, CountryName = "Senegal" },
                 new Nationality { NationalityId = 193, CountryName = "Serbia and Montenegro" },
                 new Nationality { NationalityId = 194, CountryName = "Seychelles" },
                 new Nationality { NationalityId = 195, CountryName = "Sierra Leone" },
                 new Nationality { NationalityId = 196, CountryName = "Singapore" },
                 new Nationality { NationalityId = 197, CountryName = "Slovakia" },
                 new Nationality { NationalityId = 198, CountryName = "Slovenia" },
                 new Nationality { NationalityId = 199, CountryName = "Solomon Islands" },
                 new Nationality { NationalityId = 200, CountryName = "Somalia" },
                 new Nationality { NationalityId = 201, CountryName = "South Africa" },
                 new Nationality { NationalityId = 202, CountryName = "South Georgia and the South Sandwich Islands" },
                 new Nationality { NationalityId = 203, CountryName = "Spain" },
                 new Nationality { NationalityId = 204, CountryName = "Sri Lanka" },
                 new Nationality { NationalityId = 205, CountryName = "Sudan" },
                 new Nationality { NationalityId = 206, CountryName = "Suriname" },
                 new Nationality { NationalityId = 207, CountryName = "Svalbard and Jan Mayen" },
                 new Nationality { NationalityId = 208, CountryName = "Swaziland" },
                 new Nationality { NationalityId = 209, CountryName = "Sweden" },
                 new Nationality { NationalityId = 210, CountryName = "Switzerland" },
                 new Nationality { NationalityId = 211, CountryName = "Syrian Arab Republic" },
                 new Nationality { NationalityId = 212, CountryName = "Taiwan, Province of China" },
                 new Nationality { NationalityId = 213, CountryName = "Tajikistan" },
                 new Nationality { NationalityId = 214, CountryName = "Tanzania, United Republic of" },
                 new Nationality { NationalityId = 215, CountryName = "Thailand" },
                 new Nationality { NationalityId = 216, CountryName = "Timor-Leste" },
                 new Nationality { NationalityId = 217, CountryName = "Togo" },
                 new Nationality { NationalityId = 218, CountryName = "Tokelau" },
                 new Nationality { NationalityId = 219, CountryName = "Tonga" },
                 new Nationality { NationalityId = 220, CountryName = "Trinidad and Tobago" },
                 new Nationality { NationalityId = 221, CountryName = "Tunisia" },
                 new Nationality { NationalityId = 222, CountryName = "Turkey" },
                 new Nationality { NationalityId = 223, CountryName = "Turkmenistan" },
                 new Nationality { NationalityId = 224, CountryName = "Turks and Caicos Islands" },
                 new Nationality { NationalityId = 225, CountryName = "Tuvalu" },
                 new Nationality { NationalityId = 226, CountryName = "Uganda" },
                 new Nationality { NationalityId = 227, CountryName = "Ukraine" },
                 new Nationality { NationalityId = 228, CountryName = "United Arab Emirates" },
                 new Nationality { NationalityId = 229, CountryName = "United Kingdom" },
                 new Nationality { NationalityId = 230, CountryName = "United States" },
                 new Nationality { NationalityId = 231, CountryName = "United States Minor Outlying Islands" },
                 new Nationality { NationalityId = 232, CountryName = "Uruguay" },
                 new Nationality { NationalityId = 233, CountryName = "Uzbekistan" },
                 new Nationality { NationalityId = 234, CountryName = "Vanuatu" },
                 new Nationality { NationalityId = 235, CountryName = "Venezuela" },
                 new Nationality { NationalityId = 236, CountryName = "Viet Nam" },
                 new Nationality { NationalityId = 237, CountryName = "Virgin Islands, British" },
                 new Nationality { NationalityId = 238, CountryName = "Virgin Islands, U.S." },
                 new Nationality { NationalityId = 239, CountryName = "Wallis and Futuna" },
                 new Nationality { NationalityId = 240, CountryName = "Western Sahara" },
                 new Nationality { NationalityId = 241, CountryName = "Yemen" },
                 new Nationality { NationalityId = 242, CountryName = "Zambia" },
                 new Nationality { NationalityId = 243, CountryName = "Zimbabwe" }
             );

            modelBuilder.Entity<Relation>().HasData(
                new Relation { RelationshipId = 1, RelationshipName = "Grand Parents" },
                new Relation { RelationshipId = 2, RelationshipName = "Parents" },
                new Relation { RelationshipId = 3, RelationshipName = "Siblings" },
                new Relation { RelationshipId = 4, RelationshipName = "Spouse" }
                );
        }
        
        public DbSet<Student> Students { get; set; }
        public DbSet<Relation> Relations { get; set; }        
        public DbSet<Nationality> Nationalities { get; set; }
        public DbSet<FamilyMember> FamilyMembers { get; set; }        
    }
}
