using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using People.Core.Models;
using People.Core.Services.Interfaces;
using Playground.Web.Base.Controllers;
using System.Net;

namespace People.API.Controllers
{
    [Authorize("ClientIdPolicy")]
    [EnableCors("SiteCorsPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : PlaygroundController<PeopleController>
    {
        private readonly IPeopleService _service;
        public PeopleController(ILogger<PeopleController> logger, IPeopleService service) : base(logger)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult Get()
        {
            try
            {
                var retVal = _service.Get();

                if (retVal != null)
                {
                    return Ok(retVal);
                }
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                this.Logger.LogError("Error happened on GetPeople", ex);
                return StatusCode((int)HttpStatusCode.InternalServerError, "A problem happened while handling your request.");
            }
        }

        [HttpGet("{personId}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult Get(Guid? personId)
        {
            try
            {
                var retVal = _service.Get(personId);

                if (retVal != null)
                {
                    return Ok(retVal);
                }
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                this.Logger.LogError("Error happened on GetPerson by ID", ex);
                return StatusCode((int)HttpStatusCode.InternalServerError, "A problem happened while handling your request.");
            }
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult Save([FromBody] PersonModel person)
        {
            var errorList = new List<string>();

            try
            {
                errorList = _service.Save(person);
                if (errorList.Count > 0)
                {
                    return BadRequest(errorList);
                }
            }
            catch (Exception ex)
            {
                errorList = new List<string>() { "Error in saving" };
                this.Logger.LogError("Error happened on Save", ex);
                return BadRequest(errorList);
            }

            return Ok(errorList);
        }

        [HttpPost("search")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult Search([FromBody] PersonSearchModel searchRequest)
        {
            try
            {
                var searchResults = _service.Search(searchRequest);

                return Ok(searchResults);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "A problem happened while handling your request.");
            }

        }

        [HttpDelete("{personId}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult Delete(Guid? personId)
        {
            try
            {
                var isDeleted = _service.Delete(personId);

                if (isDeleted)
                {
                    return Ok(isDeleted);
                }
                else
                    return StatusCode((int)HttpStatusCode.InternalServerError, "Unable to delete the Person.");
            }
            catch (Exception ex)
            {
                this.Logger.LogError("Error happened on GetPerson by ID", ex);
                return StatusCode((int)HttpStatusCode.InternalServerError, "A problem happened while handling your request.");
            }
        }

    }
}
