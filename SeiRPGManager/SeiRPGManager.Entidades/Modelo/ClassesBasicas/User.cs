using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeiRPGManager.Entidades.Modelo.ClassesBasicas
{
    public class User : Entidade
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string MobilePhone { get; set; }
    }
}
