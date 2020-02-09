using Domain.Persistencia.Context;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class BaseRepository<E>
        where E : class
    {
        [JsonIgnore]
        public SageBackendContext _context { get; set; }

        public BaseRepository(SageBackendContext context)
        {
            this._context = context;
        }

        public virtual async Task<E> Insert(E obj)
        {
            this._context.Add(obj);
            await this._context.SaveChangesAsync();
            this._context.Entry(obj).State = EntityState.Detached;
            return obj;
        }

        public virtual async Task Update(E obj)
        {
            this._context.Entry(obj).State = EntityState.Modified;
            this._context.Update(obj);
            await this._context.SaveChangesAsync();
            this._context.Entry(obj).State = EntityState.Detached;
        }

        public virtual async Task Delete(E obj)
        {
            this._context.Set<E>().Remove(obj);
            await this._context.SaveChangesAsync();
        }

    }
}
