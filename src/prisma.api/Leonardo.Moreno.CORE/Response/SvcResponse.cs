using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Leonardo.Moreno.CORE.Response
{
    public class SvcResponse
    {
        public List<string> Errors { get; set; }

        public bool HasError { get { return Errors.Any(); } }

        public int ErrorsCount { get { return Errors.Count; } }

        public HttpStatusCode ResponseCode { get; set; }

        public SvcResponse()
        {
            Errors = new List<string>();
        }

        public static SvcResponse GetVoidResponse(HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            return new SvcResponse { ResponseCode = statusCode };
        }
    }

    public class SvcSingleResponse<TDto> : SvcResponse
    {
        public TDto Data { get; set; }
    }

    public class SvcListResponse<TDto> : SvcResponse
    {
        public IEnumerable<TDto> Data { get; set; }
    }

    public class SvcPagedResponse<TDto> : SvcListResponse<TDto>
    {
        public int CurrentPage { get; set; }

        public int RowsPerPage { get; set; }

        public int CollectionLength { get; set; }

        public double TotalPages { get; set; }
    }
}
