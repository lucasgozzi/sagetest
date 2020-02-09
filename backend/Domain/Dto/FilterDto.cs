using Newtonsoft.Json;
using System;

namespace Domain.Dto
{
    public class FilterDto
    {
        public int PerPage { get; set; }
        public int PageNumber { get; set; }
        // order se tiver tempo
    }
}
