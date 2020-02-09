using Domain;
using Domain.Persistencia.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository
{
    public class PeopleRepository : BaseRepository<PeopleModel>
    {

        public PeopleRepository(SageBackendContext context) : base(context) { }

        public async Task<PeopleModel> GetByDocument(Guid id, string document)
        {
            return await _context.Peoples.Where(people => !people.Id.Equals(id) && people.Document.Equals(document)).SingleOrDefaultAsync();
        }

        public async Task<IList<PeopleModel>> GetAll()
        {
            return await _context.Peoples.ToListAsync();
        }

        public async Task<PeopleModel> GetById(Guid id)
        {
            return await _context.Peoples.Where(people => people.Id.Equals(id)).SingleOrDefaultAsync();
        }

        public async Task<PeopleModel> GetByEmail(Guid id, string email)
        {
            return await _context.Peoples.Where(people => !people.Id.Equals(id) && people.Email.Equals(email)).SingleOrDefaultAsync();
        }
        
    }
}