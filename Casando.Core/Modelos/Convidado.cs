using System.Collections.Generic;
using Casando.Core.Enums;

namespace Casando.Core.Modelos
{
    public class Convidado : Pessoa
    {
        public int NumeroDeExibiveis { get; set; }
        public string Endereco { get; set; }
        public TipoConvidado TipoConvidado { get; set; }
        public bool ComConvite { get; set; }
        public virtual IList<Presente> Presentes { get; set; }
    }
}
