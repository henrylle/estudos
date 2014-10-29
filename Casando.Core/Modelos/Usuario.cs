using System;

namespace Casando.Core.Modelos
{
    public class Usuario : EntidadeBase
    {
        public string Login { get; set; }
        public Guid Guid { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
