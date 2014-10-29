using System.Collections.Generic;

namespace Casando.Core.Modelos
{
    public class Perfil : EntidadeBase
    {
        public string Nome { get; set; }
        public virtual IEnumerable<Usuario> Usuarios { get; set; }
    }
}
