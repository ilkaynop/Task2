namespace Nop.Core.Domain.Catalog
{
    public partial class ProductAuthor : BaseEntity
    {

        /// <summary>
        /// Gets or sets the product identifier
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Gets or sets the author identifier
        /// </summary>
        public int AuthorId { get; set; }


        /// <summary>
        /// Gets or sets the author
        /// </summary>
        public virtual Author Author { get; set; }

        /// <summary>
        /// Gets or sets the product
        /// </summary>
        public virtual Product Product { get; set; }


    }
}
