using Newtonsoft.Json;
using System;

namespace Domain.Dto.Models.Exemplo
{
    public class PeopleUpsertDto
    {
        [JsonProperty("id")]
        public Guid? Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("document")]
        public string Document { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("mother")]
        public string MotherName { get; set; }

        [JsonProperty("father")]
        public string FatherName { get; set; }

        [JsonProperty("cellphone")]
        public string Cellphone { get; set; }

        [JsonProperty("homeNumber")]
        public string HomeNumber { get; set; }

        [JsonProperty("address")]
        public AddressUpsertDto Address { get; set; }


    }
}
