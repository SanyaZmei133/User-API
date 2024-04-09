using System;
using System.Collections.Generic;

namespace UsersAPI.Models;

public partial class User
{
    public int Userid { get; set; }

    public string Login { get; set; }

    public string Password { get; set; }

    public DateTime Createddate { get; set; }

    public int Usergroudid { get; set; }

    public int Userstateid { get; set; }

    public virtual Usergroup? Usergroud { get; set; }

    public virtual Userstate? Userstate { get; set; }
}
