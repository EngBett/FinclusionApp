using System;
using Microsoft.AspNetCore.Identity;

namespace IdentityServer.Data.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
        public bool Active { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}