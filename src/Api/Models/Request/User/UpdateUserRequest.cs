namespace Api.Models.Request.User
{
    public class UpdateUserRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string UserNameLogin { get; set; }

        public static implicit operator Domain.Entities.User(UpdateUserRequest request)
        {
            if (request is null) return null;

            return new Domain.Entities.User
            {
                Name = request.Name,
                Email = request.Email,
                UserNameLogin = request.UserNameLogin,
            };
        }
    }
}