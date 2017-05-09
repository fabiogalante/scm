using System;
using FluentValidator;

namespace Corcam.Scp.Compartilhado
{
    public abstract class Entidade : Notifiable
    {
        protected Entidade()
        {
            Id = Guid.NewGuid();
        }


        public Guid Id { get; set; }
    }
}
