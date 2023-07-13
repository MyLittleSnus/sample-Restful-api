using System;
using GoodsApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoodsApi.Context
{
    public class GoodsShopContextConfiguration : IEntityTypeConfiguration<Good>
    {
        public void Configure(EntityTypeBuilder<Good> builder)
        {
            builder.HasData(
                new Good() { Id = Guid.NewGuid().ToString(), Name = "TV LG 520", Category = 0, Cost = 20000 },
                new Good() { Id = Guid.NewGuid().ToString(), Name = "IPhone 11", Category = 0, Cost = 18000 },
                new Good() { Id = Guid.NewGuid().ToString(), Name = "MacBook Air M1", Category = 0, Cost = 30000 },
                new Good() { Id = Guid.NewGuid().ToString(), Name = "MacBook Air M2", Category = 0, Cost = 45000 },
                new Good() { Id = Guid.NewGuid().ToString(), Name = "Samsumg S20 Ultra", Category = 0, Cost = 25000 }
            );
        }
    }
}

