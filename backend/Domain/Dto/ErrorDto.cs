﻿using Newtonsoft.Json;

namespace Domain.Dto
{
    public class ErrorDto
    {
        [JsonProperty("message")]
        public string Message { get; set; }

        public ErrorDto(string message)
        {
            Message = message;
        }
    }
}
