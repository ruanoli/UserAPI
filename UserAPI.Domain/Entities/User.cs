using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserAPI.Domain.Entities
{/// <summary>
/// Modelo de Entidade
/// </summary>
    public class User
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
    }
}
