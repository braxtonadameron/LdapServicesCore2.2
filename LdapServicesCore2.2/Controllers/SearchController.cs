using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LdapServices.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LdapServicesCore2._2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly LdapDatabaseContext _context;

        public SearchController(LdapDatabaseContext context) {
            _context = context;
        }

        // GET: api/Search/
        [HttpGet]
        public ActionResult<List<User>> Search(
            string firstName,
            string lastName,
            string email,
            string address
            ) {

            var users = _context.Users
                .Include(u => u.AssignedTags)
                    .ThenInclude(t => t.Tag)
                .Where(u => firstName != null ? u.FirstName == firstName : true
                    && lastName != null ? u.LastName == lastName : true
                    && email != null ? u.Email == email : true
                    && address != null ? u.BusinessAddress == address : true)
                .ToList()
                ;

            if (users == null) {
                return NotFound();
            }

            return users;
        }
    }
}