using System;
using Microsoft.AspNetCore.Identity;

namespace BookFlow.Models;

public class ApplicationUser : IdentityUser
{
    public bool RequirePasswordChange { get; set; } = true;

}
