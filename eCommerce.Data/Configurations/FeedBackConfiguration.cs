using eCommerce.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Data.Configurations
{
    public class FeedBackConfiguration : IEntityTypeConfiguration<FeedBack>
    {
        public void Configure(EntityTypeBuilder<FeedBack> builder)
        {
            builder.ToTable("FeedBacks");
            builder.HasKey(x => x.ID);
            builder.Property(x => x.ID).UseIdentityColumn();
            builder.Property(x => x.Rating).IsRequired();
            builder.Property(x => x.Title).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Content).IsRequired();
            builder.HasOne(x => x.Product).WithMany(x => x.FeedBacks).HasForeignKey(x => x.ProductId);

        }
    }
}
