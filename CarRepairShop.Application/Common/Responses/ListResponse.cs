namespace CarRepairShop.Application.Common.Responses
{
    public class ListResponse<T> : BaseResponse
    {
        public IEnumerable<T> Data { get; set; }

        public int Total { get; set; }
    }
}