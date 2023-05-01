namespace IdentityService.Models
{
    public class UserConstants
    {
        public static List<User> Users = new()
            {
                    new User()
                    { 
                        Username = "Caspian",
                        Password = "Caspian123",
                        Role = "Admin"
                    }
            };
    }
}
