using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RepublicOfCocos.Api.Responses;
using RepublicOfCocos.Core.DTOs;
using RepublicOfCocos.Core.Entities;
using RepublicOfCocos.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RepublicOfCocos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurgeryController : ControllerBase
    {
        private readonly ISurgeryService _surgeryService;
        private readonly IMapper _mapper;
        public SurgeryController(ISurgeryService surgeryService, IMapper mapper)
        {
            _surgeryService = surgeryService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetSurgerys()
        {
            var surgerys = await _surgeryService.GetSurgerys();
            var surgerysDTO = _mapper.Map<IEnumerable<SurgeryDTO>>(surgerys);
            var response = new ApiResponse<IEnumerable<SurgeryDTO>>(surgerysDTO);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSurgery(int id)
        {
            var surgery = await _surgeryService.GetSurgery(id);
            var surgeryDTO = _mapper.Map<SurgeryDTO>(surgery);
            var response = new ApiResponse<SurgeryDTO>(surgeryDTO);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> InsertSurgerys(SurgeryDTO surgeryDTO)
        {
            var surgery = _mapper.Map<Surgery>(surgeryDTO);

            await _surgeryService.InsertSurgerys(surgery);

            surgeryDTO = _mapper.Map<SurgeryDTO>(surgery);
            var response = new ApiResponse<SurgeryDTO>(surgeryDTO);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSurgery(int id, SurgeryDTO surgeryDTO)
        {
            var surgery = _mapper.Map<Surgery>(surgeryDTO);
            surgery.SurgeryId = id;

            var result = await _surgeryService.UpdateSurgery(surgery);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSurgery(int id)
        {
            var result = await _surgeryService.DeleteSurgery(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
    }
}
