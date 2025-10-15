using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;


namespace SEJA_WebApp.Models
{
    public class AccountModelView
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string? ProfilePictureUrl { get; set; }
        public List<Claim>? AllClaims { get; set; }
    }
}