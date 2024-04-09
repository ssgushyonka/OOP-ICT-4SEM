using HelpHub.Application.Contracts.ServiceInterfaces;
using HelpHub.Application.Models.Organizator;
using Microsoft.AspNetCore.Mvc;

namespace HelpHub.Presentation.Http.Controllers;

[ApiController]
[Route("[controller]")]
public class OrganizatorController : ControllerBase
    {
        private readonly IOrganizatorService _organizatorService;

        public OrganizatorController(IOrganizatorService organizatorService)
        {
            _organizatorService = organizatorService;
        }

        [HttpGet("{organizatorId}")]
        public async Task<ActionResult<OrganizatorModel>> Get(string organizatorId)
        {
            var organizator = await _organizatorService.FindById(organizatorId)!;
            if (organizator == null)
            {
                return NotFound();
            }

            return Ok(organizator);
        }

        [HttpPost]
        public async Task<ActionResult<OrganizatorModel>> Post(OrganizatorModel organizatorModel)
        {
            await _organizatorService.Create(organizatorModel);
            return CreatedAtAction(nameof(Get), new { organizatorId = organizatorModel.OrganizatorId }, organizatorModel);
        }

        [HttpPut("{organizatorId}/name")]
        public async Task<ActionResult> UpdateName(string organizatorId, [FromBody] string newName)
        {
            var organizator = await _organizatorService.FindById(organizatorId)!;
            if (organizator == null)
            {
                return NotFound();
            }

            await _organizatorService.UpdateName(organizatorId, newName);
            return NoContent();
        }

        [HttpDelete("{organizatorId}")]
        public async Task<ActionResult> Delete(string organizatorId)
        {
            var organizator = await _organizatorService.FindById(organizatorId)!;
            if (organizator == null)
            {
                return NotFound();
            }

            await _organizatorService.Delete(organizatorId);
            return NoContent();
        }
    }
