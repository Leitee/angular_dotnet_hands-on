using Leonardo.Moreno.CORE.Contract.Model;
using Prisma.Demo.MODEL.Entity;
using Reinforced.Typings.Attributes;

namespace Prisma.Demo.MODEL.Dto
{
    [TsInterface(AutoI = false, Name = "ZonaDePrecio")]
    public class ZonaDePrecioDto : IDto<ZonaDePrecio>
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
    }
}
