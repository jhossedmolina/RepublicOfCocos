using RepublicOfCocos.Core.Entities;
using RepublicOfCocos.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RepublicOfCocos.Core.Services
{
    public class SurgeryService : ISurgeryService
    {
        private readonly ISurgeryRepository _surgeryRepository;

        public SurgeryService(ISurgeryRepository surgeryRepository)
        {
            _surgeryRepository = surgeryRepository;
        }

        public async Task<IEnumerable<Surgery>> GetSurgerys()
        {
            return await _surgeryRepository.GetSurgerys();
        }

        public async Task<Surgery> GetSurgery(int id)
        {
            return await _surgeryRepository.GetSurgery(id);
        }

        public async Task InsertSurgerys(Surgery surgerys)
        {
            await _surgeryRepository.InsertSurgerys(surgerys);
        }

        public async Task<bool> UpdateSurgery(Surgery surgery)
        {
            return await _surgeryRepository.UpdateSurgery(surgery);
        }

        public async Task<bool> DeleteSurgery(int id)
        {
            return await _surgeryRepository.DeleteSurgery(id);
        }
    }
}
