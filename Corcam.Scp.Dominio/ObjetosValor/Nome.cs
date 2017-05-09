using FluentValidator;

namespace Corcam.Scp.Dominio.ObjetosValor
{
    public class Nome :  Notifiable
    {
        protected Nome() { }

        public Nome(string primeiroNome, string sobreNome)
        {
            PrimeiroNome = primeiroNome;
            SobreNome = sobreNome;
        }

        public string PrimeiroNome { get; private set; }
        public string SobreNome { get; private set; }

        public override string ToString()
        {
            return $"{PrimeiroNome} {SobreNome}";
        }
    }
}
