using Newtonsoft.Json;

namespace AktifTech.CustomerOrderRestApi.Services
{
    public class ApiResult : ApiResult<object>
    {
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    public class ApiResult<T> where T : class
    {
        public bool Success { get; set; }
        public int Code { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public List<ApiError> Errors { get; set; }
    }
}