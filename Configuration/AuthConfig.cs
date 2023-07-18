using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkflowBddFramework.Configuration
{
    public class AuthConfig
    {
        public string? BaseTokenURI { get; set; }
        public string? Client { get; set; }
        public string? Password { get; set; }
        public string? Scope { get; set; }
        public string? ClientId { get; set; }
        public Guid ClientSecret { get; set; }
    }
}