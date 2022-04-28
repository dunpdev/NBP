using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NBP2022.Api.DTOs
{
    public class SaveAuthorDTO
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        public ContactDTO Contact { get; set; }
    }
    public class ContactDTO
    {
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Town { get; set; }
    }
}
