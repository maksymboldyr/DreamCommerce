using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities;

/// <summary>
/// Represents an address entity in the database. Inherits from <see cref="BaseEntity"/>.
/// </summary>
public class Address : BaseEntity
{
    /// <summary>
    /// Gets or sets the country name for address.
    /// </summary>
    public string Country { get; set; }

    /// <summary>
    /// Gets or sets the region name for address.
    /// </summary>
    public string Region { get; set; }

    /// <summary>
    /// Gets or sets the city name for address. Is required.
    /// </summary>
    [Required]
    public string City { get; set; }

    /// <summary>
    /// Gets or sets the street name for address. Is required.
    /// </summary>
    [Required]
    public string Street { get; set; }

    /// <summary>
    /// Gets or sets the building number for address. Is required.
    /// </summary>
    [Required]
    public string Building { get; set; }

    /// <summary>
    /// Gets or sets the apartment number for address.
    /// </summary>
    public string Apartment { get; set; }

    /// <summary>
    /// Gets or sets the zip code for address.
    /// </summary>
    public string ZipCode { get; set; }
}
