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
                    },
                    new User()
                    {
                        Username = "Phillie",
                        Password = "Phillie123",
                        Role = "User"
                    },
                    new User()
                    {
                        Username = "Cosmo",
                        Password = "Kramer123",
                        Role = "User"
                    },
                    new User()
                    {
                        Username = "Jimmy",
                        Password = "Phillie123",
                        Role = "User"
                    }
            };
    }
}
