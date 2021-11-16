using RepublicOfCocos.Core.Entities;
using System.Threading.Tasks;

namespace RepublicOfCocos.Core.Interfaces
{
    public interface ISecurityRepository 
    {
        Task RegisterUser(Security security);
        Task<Security> GetLoginByCredentials(UserLogin login);
    }
}
