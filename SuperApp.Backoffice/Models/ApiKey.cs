using System;

namespace SuperApp.Backoffice.Models
{
    public class ApiKey
    {
        public int Id { get; set; }

        public virtual ApplicationUser User { get; set; }

        public Guid Key { get; set; }

    }
}