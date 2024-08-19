using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Artsofte.Host.Migrations
{
    /// <inheritdoc />
    public partial class seedDepartment : Migration
    {
        private List<(string, int)> departments = new List<(string, int)>
        {
            new ValueTuple<string, int>("Pro", 1),
            new ValueTuple<string, int>("Nike Pro", 2),
            new ValueTuple<string, int>("KFC Pro", 3),
            new ValueTuple<string, int>("WTF", -1),
            new ValueTuple<string, int>("Copy & Paste", -2)
        };
        
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            foreach (var (name, floor) in departments)
            {
                migrationBuilder.Sql($"INSERT INTO \"Department\" (\"Name\", \"Floor\") VALUES ('{name}', '{floor}')");
            }
            
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            foreach (var (name, floor) in departments)
            {
                migrationBuilder.Sql($"DELETE FROM \"Department\" WHERE \"Name\" = '{name}'");
            }
        }
    }
}
