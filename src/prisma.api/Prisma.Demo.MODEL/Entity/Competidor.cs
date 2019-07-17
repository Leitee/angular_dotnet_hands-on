using Leonardo.Moreno.CORE.Contract.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prisma.Demo.MODEL.Entity
{
    [Table("Competidores", Schema = "Prisma")]
    public class Competidor : IEntity
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Calle { get; set; }
        public decimal Latitud { get; set; }
        public decimal Longitud { get; set; }
        public bool Marcador { get; set; }
        public bool Observar { get; set; }
        public int MarcaId { get; set; }
        public int ZonaDePrecioId { get; set; }

        //EF Navigation properties
        public virtual Marca Marca { get; set; }
        public virtual ZonaDePrecio ZonaDePrecio { get; set; }
    }
}
