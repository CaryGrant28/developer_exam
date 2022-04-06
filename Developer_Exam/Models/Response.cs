namespace Developer_Exam.Models
{
    public class APIResponse
    {
        public string? Status { get; set; }
        public string? Message { get; set; }
        public string? Data { get; set; }
    }
    public class AuthResponse
    {
        public string? Message { get; set; }
        public string? Token { get; set; }
    }

}
