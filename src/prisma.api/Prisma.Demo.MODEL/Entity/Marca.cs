using Leonardo.Moreno.CORE.Contract.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prisma.Demo.MODEL.Entity
{
    [Table("Marcas", Schema = "Prisma")]
    public class Marca : IEntity
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
    }
}
