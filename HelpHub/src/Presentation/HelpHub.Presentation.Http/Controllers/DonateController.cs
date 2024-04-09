using HelpHub.Application.Contracts.ServiceInterfaces;
using HelpHub.Application.Models.Donate;
using Microsoft.AspNetCore.Mvc;

namespace HelpHub.Presentation.Http.Controllers;

[ApiController]
[Route("[controller]")]
public class DonateController : ControllerBase
    {
        private readonly IDonateService _donateService;

        public DonateController(IDonateService donateService)
        {
            _donateService = donateService;
        }

        [HttpPost]
        public async Task<ActionResult> Create(DonateModel donateModel)
        {
            await _donateService.Create(donateModel);
            return Ok("Donate created successfully");
        }

        [HttpGet]
        public ActionResult<List<DonateModel>> GetAll()
        {
            var allDonates = _donateService.FindAll();
            return Ok(allDonates);
        }
    }
