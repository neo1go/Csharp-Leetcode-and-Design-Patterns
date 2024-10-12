using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContactsAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        /// 
        /// Die Struktur für die Datenbankfelder mit den Relationennamen als gesamtes Relationenschema basierend auf 
        protected override void Up(MigrationBuilder migrationBuilder) //erzeugt neue Table in sql DB
        {
            migrationBuilder.CreateTable(
                name: "Contacts",    //hardcoded
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)   //löscht Table aus SQL DB
        {
            migrationBuilder.DropTable(
                name: "Contacts");  //hardcoded
        }
    }
}
