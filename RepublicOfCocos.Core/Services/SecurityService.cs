using RepublicOfCocos.Core.Entities;
using RepublicOfCocos.Core.Interfaces;
using System.Threading.Tasks;

namespace RepublicOfCocos.Core.Services
{
    public class SecurityService: ISecurityService
    {
        private readonly ISecurityRepository _securityRepository;

        public SecurityService(ISecurityRepository securityRepository)
        {
            _securityRepository = securityRepository;
        }
        public async Task<Security> GetLoginByCredentials(UserLogin userLogin)
        {
            return await _securityRepository.GetLoginByCredentials(userLogin);
        }

        public async Task RegisterUser(Security security)
        {
            await _securityRepository.RegisterUser(security);
        }
    }
}
