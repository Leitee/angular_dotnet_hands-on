using Leonardo.Moreno.CORE.Contract.Model;
using Prisma.Demo.MODEL.Entity;
using Reinforced.Typings.Attributes;

namespace Prisma.Demo.MODEL.Dto
{
    [TsInterface(AutoI = false, Name = "Marca")]
    public class MarcaDto : IDto<Marca>
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
    }
}
