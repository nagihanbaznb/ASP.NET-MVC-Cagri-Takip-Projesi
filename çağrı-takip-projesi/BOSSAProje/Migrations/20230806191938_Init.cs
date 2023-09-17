using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BOSSAProje.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cihaz",
                columns: table => new
                {
                    SERI_NO = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FABRIKA_KOD = table.Column<float>(type: "real", nullable: true),
                    FABRIKA_ADI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CIHAZ_NO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CIHAZ_GRUBU = table.Column<float>(type: "real", nullable: true),
                    CIHAZ_GRUBU_ADI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CIHAZ_ALT_GRUBU = table.Column<float>(type: "real", nullable: true),
                    CIHAZ_ALT_GRUP_ADI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Markası = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CIHAZ_MODELI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MODEL_ADI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PROCESSOR_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PROCESSOR_ADI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SIRKET_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SIRKET_ADI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ISY_KODU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KULLANICI_SICIL_NO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KULLANICI_AD_SOYAD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CALISIYOR_MU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DEPARTMAN_KODU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DEPARTMAN_ADI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PERT_MI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BULUNDUGU_YER = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cihaz", x => x.SERI_NO);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cihaz");
        }
    }
}
