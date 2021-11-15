using RepublicOfCocos.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RepublicOfCocos.Core.Interfaces
{
    public interface ISurgeryService
    {
        Task<IEnumerable<Surgery>> GetSurgerys();
        Task<Surgery> GetSurgery(int id);
        Task InsertSurgerys(Surgery surgerys);
        Task<bool> UpdateSurgery(Surgery surgery);
        Task<bool> DeleteSurgery(int id);
    }
}
