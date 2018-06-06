using Nop.Core.Domain.Catalog;

namespace Nop.Data.Mapping.Catalog
{
    /// <summary>
    /// Added for Task #1
    /// Mapping class
    /// </summary>
    public partial class ProductAuthorMap : NopEntityTypeConfiguration<ProductAuthor>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public ProductAuthorMap()
        {
            this.ToTable("Product_Author_Mapping");
            this.HasKey(pm => pm.Id);

            this.HasRequired(pm => pm.Author)
                .WithMany()
                .HasForeignKey(pm => pm.AuthorId);


            this.HasRequired(pm => pm.Product)
                .WithMany(p => p.ProductAuthors)
                .HasForeignKey(pm => pm.ProductId);
        }


    }
}
