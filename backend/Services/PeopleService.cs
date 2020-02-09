using Domain;
using Domain.Dto.Models.Exemplo;
using Repository;
using Services.CustomException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Transactions;

namespace Services
{
    public class PeopleService
    {
        private readonly PeopleRepository _repository;
        private readonly AddressService _addressService;

        public PeopleService(PeopleRepository repository, AddressService addressService)
        {
            _addressService = addressService;
            _repository = repository;
        }

        private async Task ValidateUpsert(PeopleModel model)
        {
            if (string.IsNullOrEmpty(model.Name))
                throw new ValidationException("Nome é obrigatório.");

            if (string.IsNullOrEmpty(model.Document))
                throw new ValidationException("Documento é obrigatório.");

            if (string.IsNullOrEmpty(model.Email))
                throw new ValidationException("E-mail é obrigatório.");

            try
            {
                MailAddress m = new MailAddress(model.Email);
            }
            catch (FormatException)
            {
                throw new ValidationException("E-mail não é um endereço válido.");
            }

            // somente numeros
            Regex regex = new Regex(@"^\d*$");
            if (!regex.IsMatch(model.Document))
                throw new ValidationException("Documento é inválido.");

            var sameEmail = await _repository.GetByEmail(model.Id, model.Email);
            if (sameEmail != null)
                throw new ValidationException("E-mail já está sendo utilizado por outra pessoa.");

            var sameDocument = await _repository.GetByDocument(model.Id, model.Document);
            if (sameDocument != null)
                throw new ValidationException("Documento já está sendo utilizado por outra pessoa.");


        }

        public async Task<Guid> Insert(PeopleUpsertDto dto)
        {
            using (var scope =
                new TransactionScope(TransactionScopeOption.Required, TransactionScopeAsyncFlowOption.Enabled))
            {
                var model = dto.ToModel();
                model.Id = Guid.NewGuid();
                await ValidateUpsert(model);
                var inserted = await _repository.Insert(model);

                await _addressService.Insert(dto.Address, inserted.Id);

                scope.Complete();
                return model.Id;
            }
        }

        public async Task<Guid> Update(PeopleUpsertDto dto)
        {
            using (var scope =
                new TransactionScope(TransactionScopeOption.Required, TransactionScopeAsyncFlowOption.Enabled))
            {
                var model = dto.ToModel();
                await ValidateUpsert(model);
                await _repository.Update(model);

                await _addressService.Update(dto.Address, model.Id);

                scope.Complete();
                return model.Id;
            }
        }

        public async Task Delete(Guid id)
        {
            using (var scope =
                new TransactionScope(TransactionScopeOption.Required, TransactionScopeAsyncFlowOption.Enabled))
            {
                var model = await _repository.GetById(id);
                if (model != null)
                {
                    var address = await _addressService.GetMainByPeople(id);
                    await _addressService.Delete(address);
                    await _repository.Delete(model);
                    scope.Complete();
                }
            }
        }
        public async Task<IList<PeopleListDto>> GetAll()
        {
            var list = await _repository.GetAll();
            return list.Select(x => x.ToListDto()).ToList();
        }

        public async Task<PeopleUpsertDto> GetById(Guid id)
        {
            var model = await _repository.GetById(id);
            var dto = model.ToUpsertDto();

            var address = await _addressService.GetMainByPeople(id);
            dto.Address = address.ToUpsertDto();
            return dto;
        }



    }
}
