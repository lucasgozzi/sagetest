namespace Domain.Dto.Models.Exemplo
{
    public static class PeopleDtoExtensions
    {
        /**
         * Transforma o Insert/ Update dto em model
         */
        public static PeopleModel ToModel(this PeopleUpsertDto value)
        {
            if (value == null)
                return null;

            return new PeopleModel()
            {
                Id = value.Id.GetValueOrDefault(),
                Cellphone = "(xx)"+ value.Cellphone,
                Document = value.Document,
                Email = value.Email,
                FatherName = value.FatherName,
                HomeNumber = value.HomeNumber,
                Name = value.Name,
                MotherName = value.MotherName
            };
        }

        /**
         * Transforma o model em List DTO
         */
        public static PeopleListDto ToListDto(this PeopleModel value)
        {
            if (value == null)
                return null;

            return new PeopleListDto()
            {
                Id = value.Id,
                Document = value.Document,
                Email = value.Email,
                Name = value.Name
            };
        }

        /**
         * Transforma o model em Upsert DTO
         */
        public static PeopleUpsertDto ToUpsertDto(this PeopleModel value)
        {
            if (value == null)
                return null;

            return new PeopleUpsertDto()
            {
                Id = value.Id,
                Cellphone = value.Cellphone,
                Document = value.Document,
                Email = value.Email,
                FatherName = value.FatherName,
                HomeNumber = value.HomeNumber,
                Name = value.Name,
                MotherName = value.MotherName
            };
        }

    }
}
