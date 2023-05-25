namespace RefaccionariaBackendApi.Models.Response
{
    public class Response<T>
    {
        public bool success { get; set; }
        public string message { get; set; }
        public T data { get; set; }
    }
}
