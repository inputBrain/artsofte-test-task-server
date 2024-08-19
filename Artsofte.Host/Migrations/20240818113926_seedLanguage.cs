using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Artsofte.Host.Migrations
{
    /// <inheritdoc />
    public partial class seedLanguage : Migration
    {
        /// <inheritdoc />
        private List<string> languages = new List<string>()
        {
            "A# (Axiom)","C#","PHP","Python","A++","ABC","ABC ALGOL","ABLE","ABSET","ABSYS","ACC","Accent","Ace DASL","ACL2","ACT-III","Action!",
            "ActionScript","Ada","Adenine","Agda","Agilent VEE","Agora","AIMMS","Alef","ALF","ALGOL 58","ALGOL 60","ALGOL 68","ALGOL W","Alice","Alma-0",
        };
        
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            foreach (var language in languages)
            {
                migrationBuilder.Sql($"INSERT INTO \"Language\" (\"Language\") VALUES ('{language}')");
            }
            
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            foreach (var language in languages)
            {
                migrationBuilder.Sql($"DELETE FROM \"Language\" WHERE \"Language\" = '{language}'");
            }
        }
    }
}
