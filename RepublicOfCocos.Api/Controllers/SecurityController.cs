using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RepublicOfCocos.Api.Responses;
using RepublicOfCocos.Core.DTOs;
using RepublicOfCocos.Core.Entities;
using RepublicOfCocos.Core.Interfaces;
using RepublicOfCocos.Infraestructure.Interfaces;
using System.Threading.Tasks;

namespace RepublicOfCocos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        private readonly ISecurityService _securityService;
        private readonly IMapper _mapper;
        private readonly IPasswordService _passwordService;

        public SecurityController(ISecurityService securityService, IMapper mapper, IPasswordService passwordService)
        {
            _securityService = securityService;
            _mapper = mapper;
            _passwordService = passwordService;
        }

        /// <summary>
        /// Creacion de usuarios para poder acceder a la API
        /// </summary>
        /// <param name="securityDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> PostUser(SecurityDTO securityDto)
        {
            var security = _mapper.Map<Security>(securityDto);

            security.PasswordUser = _passwordService.Hash(security.PasswordUser);

            //security.PasswordUser = _passwordService.Hash(security.PasswordUser);
            await _securityService.RegisterUser(security);

            securityDto = _mapper.Map<SecurityDTO>(security);
            var response = new ApiResponse<SecurityDTO>(securityDto);
            return Ok(response);
        }
    }
}
