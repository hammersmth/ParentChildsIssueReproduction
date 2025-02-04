using Insight.Database;
using Insight.Database.Structure;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

using ParentChildsIssueReproduction.Models;

namespace ParentChildsIssueReproduction.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class PrioritiesController : ControllerBase
    {
        private readonly string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\LocalDB.mdf;Integrated Security=True;Connect Timeout=30";

        [HttpGet]
        public IActionResult GetPriorities(bool showOnlyTopLevel, bool showAllLanguages, string language = "en")
        {
            using var cnn = new SqlConnection(connectionString);

            // This code works, but it didn't create nested JSON

            List<PriorityModel> result = [.. cnn.Query<PriorityModel>("dbo.GetPriorities", new { showOnlyTopLevel, showAllLanguages, language })];

            // This code doesn't works :(

            //var result = cnn.Query("dbo.GetPriorities", new { showOnlyTopLevel, showAllLanguages, language = "en" },
            //    Query.Returns(Together<PriorityModel, PriorityModel>.Records));

            return Ok(result);
        }
    }
}
