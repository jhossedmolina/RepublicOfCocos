using Microsoft.EntityFrameworkCore;
using RepublicOfCocos.Core.Entities;
using RepublicOfCocos.Core.Interfaces;
using RepublicOfCocos.Infraestructure.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepublicOfCocos.Infraestructure.Repositories
{
    public class SurgeryRepository : ISurgeryRepository
    {
        private readonly RepublicOfCocosDBContext _context;

        public SurgeryRepository(RepublicOfCocosDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Surgery>> GetSurgerys()
        {
            var surgerys = await _context.Surgery.ToListAsync();
            return surgerys;
        }

        public async Task<Surgery> GetSurgery(int id)
        {
            var surgery = await _context.Surgery.FirstOrDefaultAsync(x => x.SurgeryId == id);
            return surgery;
        }

        public async Task InsertSurgerys(Surgery surgerys)
        {
            _context.Surgery.Add(surgerys);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateSurgery(Surgery surgery)
        {
            var currentSurgery = await GetSurgery(surgery.SurgeryId);
            currentSurgery.SurgeryId = surgery.SurgeryId;
            currentSurgery.DoctorName = surgery.DoctorName;

            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> DeleteSurgery(int id)
        {
            var result = await GetSurgery(id);
            _context.Surgery.Remove(result);

            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
    }
}
