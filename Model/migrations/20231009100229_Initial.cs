using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace test_app.Model.migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FamilyMembers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NationalityId = table.Column<int>(type: "int", nullable: true),
                    RelationshipId = table.Column<int>(type: "int", nullable: false),
                    StudentID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyMembers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Nationalities",
                columns: table => new
                {
                    NationalityID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nationalities", x => x.NationalityID);
                });

            migrationBuilder.CreateTable(
                name: "Relations",
                columns: table => new
                {
                    RelationshipId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RelationshipName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relations", x => x.RelationshipId);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NationalityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Nationalities",
                columns: new[] { "NationalityID", "CountryName" },
                values: new object[,]
                {
                    { 1, "Afghanistan" },
                    { 2, "Åland Islands" },
                    { 3, "Albania" },
                    { 4, "Algeria" },
                    { 5, "American Samoa" },
                    { 6, "AndorrA" },
                    { 7, "Angola" },
                    { 8, "Anguilla" },
                    { 9, "Antarctica" },
                    { 10, "Antigua and Barbuda" },
                    { 11, "Argentina" },
                    { 12, "Armenia" },
                    { 13, "Aruba" },
                    { 14, "Australia" },
                    { 15, "Austria" },
                    { 16, "Azerbaijan" },
                    { 17, "Bahamas" },
                    { 18, "Bahrain" },
                    { 19, "Bangladesh" },
                    { 20, "Barbados" },
                    { 21, "Belarus" },
                    { 22, "Belgium" },
                    { 23, "Belize" },
                    { 24, "Benin" },
                    { 25, "Bermuda" },
                    { 26, "Bhutan" },
                    { 27, "Bolivia" },
                    { 28, "Bosnia and Herzegovina" },
                    { 29, "Botswana" },
                    { 30, "Bouvet Island" },
                    { 31, "Brazil" },
                    { 32, "British Indian Ocean Territory" },
                    { 33, "Brunei Darussalam" },
                    { 34, "Bulgaria" },
                    { 35, "Burkina Faso" },
                    { 36, "Burundi" },
                    { 37, "Cambodia" },
                    { 38, "Cameroon" },
                    { 39, "Canada" },
                    { 40, "Cape Verde" },
                    { 41, "Cayman Islands" },
                    { 42, "Central African Republic" },
                    { 43, "Chad" },
                    { 44, "Chile" },
                    { 45, "China" },
                    { 46, "Christmas Island" },
                    { 47, "Cocos (Keeling) Islands" },
                    { 48, "Colombia" },
                    { 49, "Comoros" },
                    { 50, "Congo" },
                    { 51, "Congo, The Democratic Republic of the" },
                    { 52, "Cook Islands" },
                    { 53, "Costa Rica" },
                    { 54, "Cote D`Ivoire" },
                    { 55, "Croatia" },
                    { 56, "Cuba" },
                    { 57, "Cyprus" },
                    { 58, "Czech Republic" },
                    { 59, "Denmark" },
                    { 60, "Djibouti" },
                    { 61, "Dominica" },
                    { 62, "Dominican Republic" },
                    { 63, "Ecuador" },
                    { 64, "Egypt" },
                    { 65, "El Salvador" },
                    { 66, "Equatorial Guinea" },
                    { 67, "Eritrea" },
                    { 68, "Estonia" },
                    { 69, "Ethiopia" },
                    { 70, "Falkland Islands (Malvinas)" },
                    { 71, "Faroe Islands" },
                    { 72, "Fiji" },
                    { 73, "Finland" },
                    { 74, "France" },
                    { 75, "French Guiana" },
                    { 76, "French Polynesia" },
                    { 77, "French Southern Territories" },
                    { 78, "Gabon" },
                    { 79, "Gambia" },
                    { 80, "Georgia" },
                    { 81, "Germany" },
                    { 82, "Ghana" },
                    { 83, "Gibraltar" },
                    { 84, "Greece" },
                    { 85, "Greenland" },
                    { 86, "Grenada" },
                    { 87, "Guadeloupe" },
                    { 88, "Guam" },
                    { 89, "Guatemala" },
                    { 90, "Guernsey" },
                    { 91, "Guinea" },
                    { 92, "Guinea-Bissau" },
                    { 93, "Guyana" },
                    { 94, "Haiti" },
                    { 95, "Heard Island and Mcdonald Islands" },
                    { 96, "Holy See (Vatican City State)" },
                    { 97, "Honduras" },
                    { 98, "Hong Kong" },
                    { 99, "Hungary" },
                    { 100, "Iceland" },
                    { 101, "India" },
                    { 102, "Indonesia" },
                    { 103, "Iran, Islamic Republic Of" },
                    { 104, "Iraq" },
                    { 105, "Ireland" },
                    { 106, "Isle of Man" },
                    { 107, "Israel" },
                    { 108, "Italy" },
                    { 109, "Jamaica" },
                    { 110, "Japan" },
                    { 111, "Jersey" },
                    { 112, "Jordan" },
                    { 113, "Kazakhstan" },
                    { 114, "Kenya" },
                    { 115, "Kiribati" },
                    { 116, "Korea, Democratic Peoples Republic of" },
                    { 117, "Korea, Republic of" },
                    { 118, "Kuwait" },
                    { 119, "Kyrgyzstan" },
                    { 120, "Lao Peoples Democratic Republic" },
                    { 121, "Latvia" },
                    { 122, "Lebanon" },
                    { 123, "Lesotho" },
                    { 124, "Liberia" },
                    { 125, "Libyan Arab Jamahiriya" },
                    { 126, "Liechtenstein" },
                    { 127, "Lithuania" },
                    { 128, "Luxembourg" },
                    { 129, "Macao" },
                    { 130, "Macedonia, The Former Yugoslav Republic of" },
                    { 131, "Madagascar" },
                    { 132, "Malawi" },
                    { 133, "Malaysia" },
                    { 134, "Maldives" },
                    { 135, "Mali" },
                    { 136, "Malta" },
                    { 137, "Marshall Islands" },
                    { 138, "Martinique" },
                    { 139, "Mauritania" },
                    { 140, "Mauritius" },
                    { 141, "Mayotte" },
                    { 142, "Mexico" },
                    { 143, "Micronesia, Federated States of" },
                    { 144, "Moldova, Republic of" },
                    { 145, "Monaco" },
                    { 146, "Mongolia" },
                    { 147, "Montserrat" },
                    { 148, "Morocco" },
                    { 149, "Mozambique" },
                    { 150, "Myanmar" },
                    { 151, "Namibia" },
                    { 152, "Nauru" },
                    { 153, "Nepal" },
                    { 154, "Netherlands" },
                    { 155, "Netherlands Antilles" },
                    { 156, "New Caledonia" },
                    { 157, "New Zealand" },
                    { 158, "Nicaragua" },
                    { 159, "Niger" },
                    { 160, "Nigeria" },
                    { 161, "Niue" },
                    { 162, "Norfolk Island" },
                    { 163, "Northern Mariana Islands" },
                    { 164, "Norway" },
                    { 165, "Oman" },
                    { 166, "Pakistan" },
                    { 167, "Palau" },
                    { 168, "Palestinian Territory, Occupied" },
                    { 169, "Panama" },
                    { 170, "Papua New Guinea" },
                    { 171, "Paraguay" },
                    { 172, "Peru" },
                    { 173, "Philippines" },
                    { 174, "Pitcairn" },
                    { 175, "Poland" },
                    { 176, "Portugal" },
                    { 177, "Puerto Rico" },
                    { 178, "Qatar" },
                    { 179, "Reunion" },
                    { 180, "Romania" },
                    { 181, "Russian Federation" },
                    { 182, "RWANDA" },
                    { 183, "Saint Helena" },
                    { 184, "Saint Kitts and Nevis" },
                    { 185, "Saint Lucia" },
                    { 186, "Saint Pierre and Miquelon" },
                    { 187, "Saint Vincent and the Grenadines" },
                    { 188, "Samoa" },
                    { 189, "San Marino" },
                    { 190, "Sao Tome and Principe" },
                    { 191, "Saudi Arabia" },
                    { 192, "Senegal" },
                    { 193, "Serbia and Montenegro" },
                    { 194, "Seychelles" },
                    { 195, "Sierra Leone" },
                    { 196, "Singapore" },
                    { 197, "Slovakia" },
                    { 198, "Slovenia" },
                    { 199, "Solomon Islands" },
                    { 200, "Somalia" },
                    { 201, "South Africa" },
                    { 202, "South Georgia and the South Sandwich Islands" },
                    { 203, "Spain" },
                    { 204, "Sri Lanka" },
                    { 205, "Sudan" },
                    { 206, "Suriname" },
                    { 207, "Svalbard and Jan Mayen" },
                    { 208, "Swaziland" },
                    { 209, "Sweden" },
                    { 210, "Switzerland" },
                    { 211, "Syrian Arab Republic" },
                    { 212, "Taiwan, Province of China" },
                    { 213, "Tajikistan" },
                    { 214, "Tanzania, United Republic of" },
                    { 215, "Thailand" },
                    { 216, "Timor-Leste" },
                    { 217, "Togo" },
                    { 218, "Tokelau" },
                    { 219, "Tonga" },
                    { 220, "Trinidad and Tobago" },
                    { 221, "Tunisia" },
                    { 222, "Turkey" },
                    { 223, "Turkmenistan" },
                    { 224, "Turks and Caicos Islands" },
                    { 225, "Tuvalu" },
                    { 226, "Uganda" },
                    { 227, "Ukraine" },
                    { 228, "United Arab Emirates" },
                    { 229, "United Kingdom" },
                    { 230, "United States" },
                    { 231, "United States Minor Outlying Islands" },
                    { 232, "Uruguay" },
                    { 233, "Uzbekistan" },
                    { 234, "Vanuatu" },
                    { 235, "Venezuela" },
                    { 236, "Viet Nam" },
                    { 237, "Virgin Islands, British" },
                    { 238, "Virgin Islands, U.S." },
                    { 239, "Wallis and Futuna" },
                    { 240, "Western Sahara" },
                    { 241, "Yemen" },
                    { 242, "Zambia" },
                    { 243, "Zimbabwe" }
                });

            migrationBuilder.InsertData(
                table: "Relations",
                columns: new[] { "RelationshipId", "RelationshipName" },
                values: new object[,]
                {
                    { 1, "Grand Parents" },
                    { 2, "Parents" },
                    { 3, "Siblings" },
                    { 4, "Spouse" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FamilyMembers");

            migrationBuilder.DropTable(
                name: "Nationalities");

            migrationBuilder.DropTable(
                name: "Relations");

            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
