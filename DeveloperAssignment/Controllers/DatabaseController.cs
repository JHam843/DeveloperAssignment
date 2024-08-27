using DeveloperAssignment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DeveloperAssignment.Controllers
{
    public class DatabaseController : Controller
    {
        private readonly DatabaseAContext _contextA;
        private readonly DatabaseBContext _contextB;

        public DatabaseController(DatabaseAContext contextA, DatabaseBContext contextB)
        {
            _contextA = contextA;
            _contextB = contextB;
        }

        public IActionResult CompareTables()
        {
            // First query against DatabaseA
            string queryA = @"
                SELECT * FROM Children
                EXCEPT
                SELECT * FROM DatabaseB.dbo.Children;";

            var differencesA = _contextA.Children.FromSqlRaw(queryA).ToList();

            // Second query against DatabaseB
            string queryB = @"
                SELECT * FROM Children
                EXCEPT
                SELECT * FROM Children;";

            var differencesB = _contextB.Children.FromSqlRaw(queryB).ToList();

            // Combine the results
            var differences = differencesA.Concat(differencesB).ToList();

            return View(differences);
        }
    }
}
