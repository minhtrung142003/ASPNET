using System;
using System.Collections.Generic;

namespace CallApiweb.Entitites;

public partial class User
{
    public int Id { get; set; }

    public string? Username { get; set; }

    public string? Address { get; set; }

    public int? Phone { get; set; }

    public string? Password { get; set; }
}
