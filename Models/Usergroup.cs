using System;
using System.Collections.Generic;

namespace UsersAPI.Models;

public partial class Usergroup
{
    public int Usergroupid { get; set; }

    public int? Code { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
