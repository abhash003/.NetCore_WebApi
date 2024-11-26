namespace Data.Model
{
    public class User_Roles
    {
        public int UserId { get; set; }
        public Users User { get; set; }

        public int RolesId { get; set; }
        public Roles Role { get; set; }
    }
}
