using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PostGradCollabHub.Models;
using PostGradCollabHub.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostGradCollabHub.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly ProfileService _profileService;

        public ProfileController(ProfileService profileService)
        {
            _profileService = profileService;
        }

        /// <summary>
        /// Returns all Profiles
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET /Profile
        ///     {
        ///         "Id": "5fff2ed0d44198a59c2dd0b2",
        ///         "firstName": "Tim",
        ///         "lastName": "Herron",
        ///         "Email": "tmherron09@gmail.com",
        ///         "githubLink": "Link",
        ///         "linkedinLink": "Link"
        ///      }
        ///      
        /// </remarks>
        /// <returns>A list of profiles.</returns>
        /// <response code="201">Returns list of all profiles.</response>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [HttpGet]
        public ActionResult<List<Profile>> Get()
        {
            return _profileService.Get();
        }

        /// <summary>
        /// Gets a specific Profile by Id
        /// </summary>
        /// <param name="id">Id of profile</param>
        /// <returns>Specific Profile by Id</returns>
        /// <response code="201">Returns matching Profile</response>
        /// <response code="404">No matching profile found.</response>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id:length(24)}", Name = "GetProfile")]
        public ActionResult<Profile> Get(string id)
        {
            var profile = _profileService.Get(id);
            
            if(profile == null)
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
