using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeiRPGManager.Entidades.Modelo.ClassesBasicas
{
    public class ExternalUser: Entidade
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string Link { get; set; }
        public bool? Verified { get; set; }
    }
}
