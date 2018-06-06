using System.Collections.Generic;
using Nop.Core.Domain.Catalog;

namespace Nop.Services.Catalog
{
    /// <summary>
    /// Extensions
    /// </summary>
    public static class AuthorExtensions
    {
        /// <summary>
        /// Returns a ProductAuthor that has the specified values
        /// </summary>
        /// <param name="source">Source</param>
        /// <param name="productId">Product identifier</param>
        /// <param name="authorId">Author identifier</param>
        /// <returns>A ProductAuthor that has the specified values; otherwise null</returns>
        public static ProductAuthor FindProductAuthor(this IList<ProductAuthor> source,
            int productId, int authorId)
        {
            foreach (var productAuthor in source)
                if (productAuthor.ProductId == productId && productAuthor.AuthorId == authorId)
                    return productAuthor;

            return null;
        }
    }
}
