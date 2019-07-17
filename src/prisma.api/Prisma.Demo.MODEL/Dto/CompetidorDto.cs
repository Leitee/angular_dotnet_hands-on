using Leonardo.Moreno.CORE.Contract.Model;
using Prisma.Demo.MODEL.Entity;
using Reinforced.Typings.Attributes;

namespace Prisma.Demo.MODEL.Dto
{
    [TsInterface(AutoI = false, Name = "Competidor")]
    public class CompetidorDto : IDto<Competidor>
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
        public virtual MarcaDto Marca { get; set; }
        public virtual ZonaDePrecioDto ZonaDePrecio { get; set; }
    }
}
