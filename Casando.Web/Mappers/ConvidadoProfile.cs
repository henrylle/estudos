using System.Linq;
using AutoMapper;
using Casando.Core.Modelos;
using Casando.Web.ViewModels.Convidado;

namespace Casando.Web.Mappers
{
    public class ConvidadoProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<CadastrarConvidadoVM, Convidado>()
                .ForMember(vm => vm.Sobrenome, expression => expression.ResolveUsing(Sobrenome));

            base.Configure();
        }

        private static object Sobrenome(CadastrarConvidadoVM model)
        {
            var partesNome = model.Nome.Split(' ');
            var sobreNome = string.Empty;

            if (partesNome.Length % 2 == 0)
            {
                return string.Join(" ", partesNome.Skip(partesNome.Length / 2));
            }
            else
            {
                return string.Join(" ", partesNome.Skip(1));
            }
        }
    }
}