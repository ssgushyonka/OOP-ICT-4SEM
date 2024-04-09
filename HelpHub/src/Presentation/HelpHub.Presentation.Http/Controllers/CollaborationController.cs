using HelpHub.Application.Contracts.ServiceInterfaces;
using HelpHub.Application.Models.Collaboration;
using Microsoft.AspNetCore.Mvc;

namespace HelpHub.Presentation.Http.Controllers;

[ApiController]
[Route("[controller]")]
public class CollaborationController : ControllerBase
    {
        private readonly ICollaborationService _collaborationService;

        public CollaborationController(ICollaborationService collaborationService)
        {
            _collaborationService = collaborationService;
        }

        [HttpPost]
        public async Task<ActionResult> Add(CollaborationModel collaborationModel)
        {
            await _collaborationService.Add(collaborationModel);
            return Ok("Collaboration added successfully");
        }

        [HttpGet("{collaborationId}")]
        public ActionResult<CollaborationModel> FindById(string collaborationId)
        {
            var collaboration = _collaborationService.FindById(collaborationId);
            if (collaboration == null)
            {
                return NotFound();
            }

            return Ok(collaboration);
        }

        [HttpDelete("{collaborationId}")]
        public async Task<ActionResult> Delete(string collaborationId)
        {
            var collaboration = await _collaborationService.FindById(collaborationId);
            if (collaboration == null)
            {
                return NotFound();
            }

            await _collaborationService.Delete(collaborationId);
            return NoContent();
        }
    }
