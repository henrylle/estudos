using Casando.Core.Modelos;

namespace Casando.Web.ViewModels.Presente
{
    public class NovaCotacaoVM
    {
        public int PresenteId { get; set; }
        public string NomePresente { get; set; }
        public CotacaoPresente CotacaoPresente { get; set; }
    }
}