using Domain.Dto.Models.Exemplo;
using Domain.Persistencia.Dominio;
using Repository;
using Services.CustomException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services
{
    public class AddressService
    {
        private readonly AddressRepository _repository;

        public AddressService(AddressRepository repository)
        {
            _repository = repository;
        }

        private void ValidateUpsert(AddressModel model)
        {
            if (string.IsNullOrEmpty(model.Address))
                throw new ValidationException("Logradouro é obrigatório.");

            if (string.IsNullOrEmpty(model.City))
                throw new ValidationException("Cidade é obrigatório.");

            if (string.IsNullOrEmpty(model.Neighborhood))
                throw new ValidationException("Bairo é obrigatório.");

            if (string.IsNullOrEmpty(model.State))
                throw new ValidationException("Estado é obrigatório.");

        }

        public async Task<Guid> Insert(AddressUpsertDto dto, Guid peopleId)
        {
            var model = dto.ToModel();
            model.Id = Guid.NewGuid();
            model.PeopleId = peopleId;
            ValidateUpsert(model);
            await _repository.Insert(model);
            return model.Id;
        }

        public async Task<Guid> Update(AddressUpsertDto dto, Guid peopleId)
        {
            var model = dto.ToModel();
            model.PeopleId = peopleId;
            ValidateUpsert(model);
            await _repository.Update(model);
            return model.Id;
        }


        public async Task Delete(AddressModel model)
        {
            await _repository.Delete(model);
        }

        public async Task<AddressModel> GetMainByPeople(Guid id)
        {
            var list = await _repository.GetByPeople(id);
            if (list.Count > 0)
                return list[0];
            else
                return null;
        }
        // se algum dia houver + de 1 endereco por pessoa
        public async Task<IList<AddressModel>> GetAllByPeople(Guid id)
        {
            var list = await _repository.GetByPeople(id);
            return list;
        }



    }
}
