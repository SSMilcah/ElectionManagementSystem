using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace ElectionManagementSystem.Controllers
{
    public class EmSampleController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public EmSampleController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        [HttpGet("EmSampleScreen", Name = "EmSampleScreen")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("api/EmSample/GetPartyDetails")]
        public IActionResult GetPartyDetails()
        {
            string jsonFilePath = Path.Combine(_webHostEnvironment.ContentRootPath, "Data", "Parties.json");

            if (!System.IO.File.Exists(jsonFilePath))
            {
                return NotFound();
            }

            string jsonContent = System.IO.File.ReadAllText(jsonFilePath);
            return Content(jsonContent, "application/json");
        }

        [HttpGet("api/EmSample/GetVoterDetails")]
        public IEnumerable<string> GetVoterDetails()
        {
            return new string[] { "Voter 1", "Voter 2", "Voter 3" };
        }

        [HttpGet("api/EmSample/GetVotingData")]
        public IEnumerable<string> GetVotingData()
        {
            return new string[] { "Vote 1", "Vote 2", "Vote 3" };
        }

        [HttpGet("api/EmSample/GetElectionResult")]
        public IEnumerable<string> GetElectionResult()
        {
            return new string[] { "Result 1", "Result 2", "Result 3" };
        }
    }
}
