using Leonardo.Moreno.CORE.Response;
using System.Threading.Tasks;

namespace Pandora.NetStandard.Core.Interfaces
{
    public interface ICrudOperations<TDto>
    {
        Task<SvcListResponse<TDto>> GetAllAsync();
        Task<SvcSingleResponse<TDto>> GetByIdAsync(int pId);
        Task<SvcSingleResponse<TDto>> CreateAsync(TDto pDto);
        Task<SvcSingleResponse<bool>> UpdateAsync(TDto pDto);
        Task<SvcSingleResponse<bool>> DeleteAsync(TDto pDto);
    }
}
