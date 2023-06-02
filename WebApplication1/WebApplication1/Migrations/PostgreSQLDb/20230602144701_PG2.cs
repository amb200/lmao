using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Npgsql;
using WebApplication1;
using WebApplication1.Data;

#nullable disable

namespace WebApplication1.Migrations.PostgreSQLDb
{
    /// <inheritdoc />
    public partial class PG2 : Migration
    {


    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
        {
         
            migrationBuilder.UpdateData(
                table: "Models", // Replace with the name of the table in the other context
                keyColumn: "EventId", // Replace with the name of the primary key column
                keyValue: 1, // Replace with the specific primary key value you want to update
                column: "TenantId", // Replace with the name of the column you want to update
                value: "Nyaaaaaa" // Replace with the new value you want to set
            );



        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
