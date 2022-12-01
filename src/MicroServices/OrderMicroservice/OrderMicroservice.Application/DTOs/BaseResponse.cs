namespace OrderMicroservice.Application.DTOs
{
    public class BaseResponse<T>
    {
        public T Data { get; set; }
        public bool Success { get; set; }
        public List<string> Errors { get; set; }
    }
}
