namespace PlanetSalvator.Web.Server.Models;

using Microsoft.AspNetCore.Identity;

public class ApplicationUser
    : IdentityUser
{
    public int Points { get; set; }

    public double Latitude { get; set; }

    public double Longitude { get; set; }
}
