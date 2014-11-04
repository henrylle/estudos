using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Casando.Core.Modelos;

namespace Casando.Data.Interfaces
{
    public interface ICasandoContext
    {
        DbSet<Convidado> Convidados { get; set; }
        DbSet<Presente> Presentes { get; set; }
        DbSet<Usuario> Usuarios { get; set; }
        DbSet<Perfil> Perfis { get; set; }
        DbSet<CotacaoPresente> CotacaoPresentes { get; set; }
    }
}
