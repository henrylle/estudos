using System.Collections.Generic;
using System.Linq;
using Casando.Core.Enums;
using Casando.Core.Modelos;

namespace Casando.Data.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<CasandoContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(CasandoContext context)
        {
            if(context.Convidados.Any()) return;

            var convidados = new List<Convidado>
            {
                new Convidado
                {
                    Endereco = "Rua Renato Braga, 200, Vicente Pinzon",
                    Nome = "Vitor",
                    Sobrenome = "Benevides Botelho",
                    NumeroConvites = 2,
                    TipoConvidado = TipoConvidado.FamiliarNoivo
                },
                new Convidado
                {
                    Endereco = "Rua Solon Onofre, 10, Papicú",
                    Nome = "Eduardo",
                    Sobrenome = "Benevides Couto",
                    NumeroConvites = 3,
                    TipoConvidado = TipoConvidado.FamiliarNoivo
                },
                new Convidado
                {
                    Endereco = "Rua Renato Braga, 200, Vicente Pinzon",
                    Nome = "Mauro",
                    Sobrenome = "Barbosa Botelho Neto",
                    NumeroConvites = 2,
                    TipoConvidado = TipoConvidado.FamiliarNoivo
                },
                new Convidado
                {
                    Endereco = "Rua Coronel Antonio, Limoeiro",
                    Nome = "Maximiliano",
                    Sobrenome = "Rodrigues Coura",
                    NumeroConvites = 4,
                    TipoConvidado = TipoConvidado.FamiliarNoiva
                },
                new Convidado
                {
                    Endereco = "SEM ENDEREÇO",
                    Nome = "Miguel",
                    Sobrenome = "Rodrigues Coura",
                    NumeroConvites = 2,
                    TipoConvidado = TipoConvidado.FamiliarNoivo
                },
                new Convidado
                {
                    Endereco = "SEM ENDEREÇO",
                    Nome = "Felipe",
                    Sobrenome = "Macêdo Rangel",
                    NumeroConvites = 2,
                    TipoConvidado = TipoConvidado.AmigosNoivo
                }
            };

            convidados.ForEach(c => context.Convidados.Add(c));

            base.Seed(context);
        }
    }
}
