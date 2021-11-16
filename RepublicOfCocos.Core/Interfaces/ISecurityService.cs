using RepublicOfCocos.Core.Entities;
using System.Threading.Tasks;

namespace RepublicOfCocos.Core.Interfaces
{
    public interface ISecurityService
    {
        Task<Security> GetLoginByCredentials(UserLogin userLogin);
        Task RegisterUser(Security security);
    }
}
