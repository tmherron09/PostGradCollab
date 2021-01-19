using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReactNetDemo.Models;
using ReactNetDemo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactNetDemo.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileExampleController : ControllerBase
    {

        private readonly ProfileService _profileService;

        public ProfileExampleController(ProfileService profileService)
        {
            _profileService = profileService;
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [HttpGet]
        public ActionResult<List<Profile>> Get()
        {
            return _profileService.Get();
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id:length(24)}", Name = "GetProfile")]
        public ActionResult<Profile> Get(string id)
        {
            var profile = _profileService.Get(id);

            if (profile == null)
            {
                return NotFound();
            }

            return profile;
        }

        [HttpPost]
        public ActionResult<Profile> Create(Profile profile)
        {
            profile = _profileService.Create(profile);

            return CreatedAtRoute("GetProfile", new { id = profile.Id.ToString() }, profile);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Profile profileUpdate)
        {
            var profile = _profileService.Get(id);
            if (profile == null)
            {
                return NotFound();
            }
            _profileService.Update(id, profileUpdate);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var profile = _profileService.Get(id);
            if (profile == null)
            {
                return NotFound();
            }
            _profileService.Remove(profile.Id);

            return NoContent();
        }

    }
}
