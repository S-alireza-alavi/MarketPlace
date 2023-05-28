﻿namespace App.Domain.Core.Entities;

public partial class AspNetUser
{
    public int Id { get; set; }

    public string? UserName { get; set; }

    public string? NormalizedUserName { get; set; }

    public string? Email { get; set; }

    public string? NormalizedEmail { get; set; }

    public bool EmailConfirmed { get; set; }

    public string? PasswordHash { get; set; }

    public string? SecurityStamp { get; set; }

    public string? ConcurrencyStamp { get; set; }

    public string? PhoneNumber { get; set; }

    public bool PhoneNumberConfirmed { get; set; }

    public bool TwoFactorEnabled { get; set; }

    public DateTimeOffset? LockoutEnd { get; set; }

    public bool LockoutEnabled { get; set; }

    public int AccessFailedCount { get; set; }

    public virtual ICollection<AspNetUserClaim> AspNetUserClaims { get; set; } = new List<AspNetUserClaim>();

    public virtual ICollection<AspNetUserLogin> AspNetUserLogins { get; set; } = new List<AspNetUserLogin>();

    public virtual ICollection<AspNetUserToken> AspNetUserTokens { get; set; } = new List<AspNetUserToken>();

    public virtual ICollection<Auction> Auctions { get; set; } = new List<Auction>();

    public virtual ICollection<Bid> Bids { get; set; } = new List<Bid>();

    public virtual ICollection<CustomerAddress> CustomerAddresses { get; set; } = new List<CustomerAddress>();

    public virtual ICollection<Order> OrderCustomers { get; set; } = new List<Order>();

    public virtual ICollection<Order> OrderSellers { get; set; } = new List<Order>();

    public virtual ICollection<ProductComment> ProductComments { get; set; } = new List<ProductComment>();

    public virtual ICollection<StoreComment> StoreComments { get; set; } = new List<StoreComment>();

    public virtual ICollection<Store> Stores { get; set; } = new List<Store>();

    public virtual ICollection<AspNetRole> Roles { get; set; } = new List<AspNetRole>();
}
