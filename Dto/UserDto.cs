namespace UsersAPI.Dto
{
    public class UserDto
    {
        public int Userid { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public DateTime Createddate { get; set; }

        public int Usergroudid { get; set; }

        public int Userstateid { get; set; }
    }
}
