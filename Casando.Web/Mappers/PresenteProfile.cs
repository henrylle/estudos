using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Casando.Core.Modelos;
using Casando.Web.ViewModels.Presente;

namespace Casando.Web.Mappers
{
    public class PresenteProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<CadastrarPresenteVM, Presente>()
                .ForMember(p => p.Nome, expression => expression.MapFrom(vm => vm.PresenteNome))
                .ForMember(p => p.Cotacoes, expression => expression.ResolveUsing(cotacao));

            Mapper.CreateMap<NovaCotacaoVM, CotacaoPresente>()
                .ForMember(c => c.SiteNome, expression => expression.MapFrom(vm => vm.CotacaoPresente.SiteNome))
                .ForMember(c => c.Url, expression => expression.MapFrom(vm => vm.CotacaoPresente.Url))
                .ForMember(c => c.Valor, expression => expression.MapFrom(vm => vm.CotacaoPresente.Valor));

            Mapper.CreateMap<CotacaoPresente, NovaCotacaoVM>()
                .ForMember(vm => vm.PresenteId, expression => expression.MapFrom(c => c.Id))
                .ForMember(vm => vm.NomePresente, expression => expression.MapFrom(c => c.Presente.Nome));

            base.Configure();
        }

        private static object cotacao(CadastrarPresenteVM model)
        {
            return new List<CotacaoPresente>
            {
                new CotacaoPresente
                {
                    SiteNome = model.SiteNome,
                    Url = model.Url,
                    Valor = model.Valor
                }
            };
        }
    }
}