using System.Collections.Generic;
using System.Security.Claims;


namespace SEJA_WebApp.Models
{
    public class AccountModelView
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string GivenName { get; set; }
        public string SurName { get; set; }
        public string ProfilePictureUrl { get; set; }
        public List<Claim> AllClaims { get; set; }
    }
}