using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.API.Data;
using DatingApp.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Controllers {
    [Route ("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase {
        private readonly DataContext _context;
        public ValuesController (DataContext context) {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetValues () {
            var values = _context.Values.ToList ();
            return Ok (values);
        }

        [HttpGet ("{id}")]
        public async Task<IActionResult> GetValue (int? id) {
            if (id == null) {
                return Ok ( await _context.Values.ToListAsync());
            }
            return Ok (_context.Values.Where (x => x.Id == id).ToList ());
        }
        // // GET api/values/5
        // [HttpGet ("{id}")]
        // public ActionResult<string> Get (int id) {
        //     return "value";
        // }

        // POST api/values
        [HttpPost]
        public IActionResult PostValues ([FromBody] string value) {
            if (string.IsNullOrEmpty (value)) {
                return Ok ("Invalid data");
            }
            var newValue = new Value () {
                Name = value
            };
            _context.Values.Add (newValue);
            _context.SaveChanges ();
            return Ok (newValue);
        }

        // PUT api/values/5
        [HttpPut ("{id}")]
        public void Put (int id, [FromBody] string value) { }

        // DELETE api/values/5
        [HttpDelete ("{id}")]
        public void Delete (int id) { }
    }
}