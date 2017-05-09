using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Corcam.Scp.Infra.Contexto;

namespace Corcam.Scp.Infra.Transacoes
{
    public class Uow : IUow
    {
        private readonly ScpDataContext _context;

        public Uow(ScpDataContext context)
        {
            _context = context;
        }


        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Rollback()
        {
            // Do nothing ;)
        }
    }
}
