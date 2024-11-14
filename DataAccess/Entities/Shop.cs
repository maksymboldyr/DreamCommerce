using DataAccess.Entities.Users;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities;

/// <summary>
/// Represents a shop entity. Represents data of a shop that uploaded product to a marketplace.
/// </summary>
public class Shop : BaseEntity
{
    //TODO: Update entity to have one-to-many relationship with users
    [ForeignKey("User")]
    public string UserId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    [ForeignKey("Address")]
    public string AddressId { get; set; }

    public User User { get; set; }
    public Address Address { get; set; }
    public List<Product> Products { get; set; }
}
