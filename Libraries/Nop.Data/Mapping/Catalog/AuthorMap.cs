using Nop.Core.Domain.Catalog;

namespace Nop.Data.Mapping.Catalog
{
    /// <summary>
    /// Added for Task #1
    /// Mapping class
    /// </summary>
    public partial class AuthorMap : NopEntityTypeConfiguration<Author>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public AuthorMap()
        {
            this.ToTable("Author");
            this.HasKey(m => m.Id);
            this.Property(m => m.FirstName).IsRequired().HasMaxLength(100);
            this.Property(m => m.LastName).IsRequired().HasMaxLength(100);
            this.Property(m => m.Description).HasMaxLength(500);
            this.Property(m => m.PictureId).IsRequired();
        }


    }
}
