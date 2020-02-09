using Newtonsoft.Json;
using System;

namespace Domain.Dto.Models.Exemplo
{
    public class PeopleListDto
    {
        [JsonProperty("id")]
        public Guid? Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("document")]
        public string Document { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }
        
    }
}
