using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Persistencia.Dominio
{
    [Table("Address")]
    public class AddressModel 
    {
        [Required()]
        public Guid Id { get; set; }

        [Required()]
        public string ZipCode { get; set; }
        
        public string Address { get; set; }

        public string Neighborhood { get; set; }

        public string Complement { get; set; }

        public string Number { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        [ForeignKey("PeopleId")]
        public PeopleModel People { get; set; }

        public Guid PeopleId { get; set; }

    }
}
