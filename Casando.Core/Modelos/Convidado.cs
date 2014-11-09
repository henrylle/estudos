using Casando.Core.Enums;

namespace Casando.Core.Modelos
{
    public class Convidado : Pessoa
    {
        public int NumeroDeExibiveis { get; set; }
        public string Endereco { get; set; }
        public Presente Presente { get; set; }
        public TipoConvidado TipoConvidado { get; set; }
        public bool ComConvite { get; set; }
    }
}
