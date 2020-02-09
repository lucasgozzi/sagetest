using Newtonsoft.Json;
using System;

namespace Domain.Dto
{
    public class InsertedDto
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        public InsertedDto(Guid id)
        {
            Id = id;
        }
    }
}
