using System;
using System.Collections.Generic;

namespace UsersAPI.Models;

public partial class Userstate
{
    public int Userstateid { get; set; }

    public int? Code { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
