using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Loja_Games.Util;
using Newtonsoft.Json;

namespace Loja_Games.Model
{
    public class Produto 
    {
        [Key] // Primary Key (Id)
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // IDENTITY (1,1)
        public long Id { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(255)]
        public string Nome { get; set; } = string.Empty;

        [Column(TypeName = "varchar")]
        [StringLength(1000)]
        public string Descricao { get; set; } = string.Empty;

        [Column(TypeName = "varchar")]
        [StringLength(255)]
        public string Console { get; set; } = string.Empty;

        [Column(TypeName = "date")]
        [JsonConverter(typeof(DateOnlyJsonConverter))]
        public DateTime dataLancamento { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Preco{ get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(1000)]
        public string Foto { get; set; } = string.Empty;
        public virtual Categoria? Categoria { get; set; }
    }
}
