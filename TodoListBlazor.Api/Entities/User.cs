using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TodoListBlazor.Api.Entities
{
    public class User : IdentityUser<Guid>
    {
        [MaxLength(250)]
        [Required]
        public string FirtName { get; set; }
        [MaxLength(250)]
        [Required]
        public string LastName { get; set; }
    }
}
