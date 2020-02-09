using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    [Table("People")]
    public class PeopleModel
    {
        [Required()]
        public Guid Id { get; set; }

        [Required()]
        public string Name { get; set; }

        [Required()]
        public string Document { get; set; }

        [Required()]
        public string Email { get; set; }

        public string MotherName { get; set; }

        public string FatherName { get; set; }

        [Required()]
        public string Cellphone { get; set; }

        public string HomeNumber { get; set; }

    }
}
