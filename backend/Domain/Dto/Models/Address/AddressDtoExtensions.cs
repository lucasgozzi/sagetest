using Domain.Persistencia.Dominio;

namespace Domain.Dto.Models.Exemplo
{
    public static class AddressDtoExtensions
    {
        /**
         * Transforma o Upadte/Insert dto em model
         */
        public static AddressModel ToModel(this AddressUpsertDto value)
        {
            if (value == null)
                return null;

            return new AddressModel()
            {
                Id = value.Id.GetValueOrDefault(),
                Address = value.Address,
                City = value.City,
                Complement = value.Complement,
                Neighborhood = value.Neighborhood,
                Number = value.Number,
                State = value.State,
                ZipCode = value.ZipCode
            };
        }

        /**
         * Transforma o model em Upadte/Insert dto 
         */
        public static AddressUpsertDto ToUpsertDto(this AddressModel value)
        {
            if (value == null)
                return null;

            return new AddressUpsertDto()
            {
                Id = value.Id,
                Address = value.Address,
                City = value.City,
                Complement = value.Complement,
                Neighborhood = value.Neighborhood,
                Number = value.Number,
                State = value.State,
                ZipCode = value.ZipCode
            };
        }

    }
}
