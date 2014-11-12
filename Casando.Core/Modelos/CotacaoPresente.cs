using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace Casando.Core.Modelos
{
    public class CotacaoPresente : EntidadeBase
    {
        public string SiteNome { get; set; }
        public string Url { get; set; }
        public decimal Valor { get; set; }

        [ForeignKey("Presente")]
        public int PresenteId { get; set; }
        public virtual Presente Presente{ get; set; }
    }
}
