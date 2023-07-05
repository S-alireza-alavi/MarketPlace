using MarketPlace.Entities;
using Microsoft.AspNetCore.Identity;

namespace App.Domain.Core.Entities
{
    public class ApplicationUser : IdentityUser<int>
    {
        public string? FullName { get; set; }

        public virtual ICollection<Auction> Auctions { get; set; } = new List<Auction>();

        public virtual ICollection<Bid> Bids { get; set; } = new List<Bid>();

        public virtual ICollection<CustomerAddress> CustomerAddresses { get; set; } = new List<CustomerAddress>();

        public virtual ICollection<Order> OrderCustomers { get; set; } = new List<Order>();

        public virtual ICollection<Order> OrderSellers { get; set; } = new List<Order>();

        public virtual ICollection<ProductComment> ProductComments { get; set; } = new List<ProductComment>();

        public virtual ICollection<OrderComment> OrderComments { get; set; } = new List<OrderComment>();

        public virtual ICollection<StoreComment> StoreComments { get; set; } = new List<StoreComment>();

        public virtual ICollection<Store> Stores { get; set; } = new List<Store>();

        public virtual Medal? Medal { get; set; }
    }
}
