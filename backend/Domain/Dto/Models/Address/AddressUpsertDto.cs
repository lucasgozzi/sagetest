using Newtonsoft.Json;
using System;

namespace Domain.Dto.Models.Exemplo
{
    public class AddressUpsertDto
    {
        [JsonProperty("id")]
        public Guid? Id { get; set; }
        
        [JsonProperty("zipcode")]
        public string ZipCode { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("neighborhood")]
        public string Neighborhood { get; set; }

        [JsonProperty("complement")]
        public string Complement { get; set; }

        [JsonProperty("number")]
        public string Number { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }
    }
}
