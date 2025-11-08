using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;


namespace SEJA_WebApp.Models
{
    public class AccountModelView
    {
        [Required (ErrorMessage = "Nome não pode ser vazio")]
        public string Name { get; set; }
        [Required (ErrorMessage = "Email não pode ser vazio")]
        public string Email { get; set; }
        
        public string? ProfilePictureUrl { get; set; }
        public List<Claim>? AllClaims { get; set; }
    }
}