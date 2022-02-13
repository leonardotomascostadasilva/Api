namespace Api.Models.Request.User
{
    public class CreateUserRequest
    {
        public string Document { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string UserNameLogin { get; set; }
        public string Password { get; set; }

        public static implicit operator Domain.Entities.User(CreateUserRequest request)
        {
            if (request is null) return null;

            return new Domain.Entities.User
            {
                Document = request.Document,
                Name = request.Name,
                Email = request.Email,
                UserNameLogin = request.UserNameLogin,
                Password = request.Password
            };
        }
    }
}