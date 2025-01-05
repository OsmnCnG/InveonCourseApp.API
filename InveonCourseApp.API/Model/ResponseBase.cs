
using InveonCourseApp.API.Security;

namespace InveonCourseApp.API.Model
{
    public class ResponseBase<T>
        where T : class, new()
    {
        public bool IsSuccess { get; set; } = false;
        public string Message { get; set; } = "";
        public Token Token { get; set; }
        public T Data { get; set; }
        public string SystemMessage { get; set; }
    }
}
