namespace AtlasConnectionApiCode.Dto
{
    public class GenericResponse
    {
        public bool Success { get; set; } = false;
        public string Message { get; set; } = string.Empty;
    }

    public class GenericResponse<T> where T : class, new()
    {
        public bool Success { get; set; } = false;
        public string Message { get; set; } = string.Empty;
        public T Data { get; set; } = new();
    }
}
