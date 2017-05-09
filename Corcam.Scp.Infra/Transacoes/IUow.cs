using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corcam.Scp.Infra.Transacoes
{
   public interface IUow
   {
       void Commit();
       void Rollback();
   }
}
