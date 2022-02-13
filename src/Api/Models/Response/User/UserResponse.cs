namespace Api.Models.Response.User
{
    public class UserResponse
    {
        public string Document { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string UserNameLogin { get; set; }
        public string Id { get; set; }

        public static implicit operator UserResponse(Domain.Entities.User user)
        {
            if (user is null) return null;

            return new UserResponse
            {
                Document = user.Document,
                Name = user.Name,
                Email = user.Email,
                UserNameLogin = user.UserNameLogin,
                Id = user.Id
            };
        }
    }
}