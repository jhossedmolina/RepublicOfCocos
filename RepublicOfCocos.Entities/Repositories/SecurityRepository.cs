using Microsoft.EntityFrameworkCore;
using RepublicOfCocos.Core.Entities;
using RepublicOfCocos.Core.Interfaces;
using RepublicOfCocos.Infraestructure.Data;
using System.Threading.Tasks;

namespace RepublicOfCocos.Infraestructure.Repositories
{
    public class SecurityRepository : ISecurityRepository
    {
        private readonly RepublicOfCocosDBContext _context;

        public SecurityRepository(RepublicOfCocosDBContext context)
        {
            _context = context;
        }

        public async Task<Security> GetLoginByCredentials(UserLogin login)
        {
            return await _context.Security.FirstOrDefaultAsync(x => x.UserSecurity == login.User);
        }

        public async Task RegisterUser(Security security)
        {
            _context.Security.Add(security);
            await _context.SaveChangesAsync();
        }
    }
}
