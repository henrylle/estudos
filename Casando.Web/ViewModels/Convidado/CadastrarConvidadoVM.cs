using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Casando.Core.Enums;

namespace Casando.Web.ViewModels.Convidado
{
    public class CadastrarConvidadoVM : Core.Modelos.Convidado
    {
        public IEnumerable<SelectListItem> PreencheNumeroDeExibiveis
        {
            get
            {
                var numeros = new List<SelectListItem>(10);

                for (var i = 1; i <= 10; i++)
                {
                    var num = i.ToString();
                    numeros.Add(new SelectListItem {Value = num, Text = num});
                }

                return numeros;
            } 
        }
        
        public IEnumerable<SelectListItem> TiposConvidado
        {
            get
            {
                var listaTipos = new List<SelectListItem>()
                {
                    new SelectListItem { Value = TipoConvidado.AmigosNoiva.ToString(), Text = "Amigo(a) da Noiva"},
                    new SelectListItem { Value = TipoConvidado.AmigosNoivo.ToString(), Text = "Amigo(a) do Noivo"},
                    new SelectListItem { Value = TipoConvidado.FamiliarNoiva.ToString(), Text = "Familiares da Noiva"},
                    new SelectListItem { Value = TipoConvidado.FamiliarNoivo.ToString(), Text = "Familiares do Noivo"},
                };
                    
                return listaTipos;
            }
        }
    }
}