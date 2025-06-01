namespace APIRestFull.Models
{
    public class Model_Generic<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
}
