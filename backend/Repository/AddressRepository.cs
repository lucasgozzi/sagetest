using Domain.Persistencia.Context;
using Domain.Persistencia.Dominio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository
{
    public class AddressRepository : BaseRepository<AddressModel>
    {
        public AddressRepository(SageBackendContext context) : base(context) { }

        public async Task<AddressModel> GetById(Guid id)
        {
            return await _context.Addresses.Where(adr => adr.Id.Equals(id)).SingleOrDefaultAsync();
        }
        public async Task<IList<AddressModel>> GetByPeople(Guid id)
        {
            return await _context.Addresses.Where(adr => adr.PeopleId.Equals(id)).ToListAsync();
        }

    }
}