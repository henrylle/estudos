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
            var nomeSobrenome = model.Nome.Split(' ');
            var sobreNome = string.Empty;

            foreach (var sn in nomeSobrenome)
            {
                if(nomeSobrenome.First().Equals(sn)) continue;

                sobreNome = string.Format("{0} {1}", sobreNome, sn);
            }

            return sobreNome;
        }
    }
}