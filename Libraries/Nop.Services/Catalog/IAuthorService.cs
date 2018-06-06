using System.Collections.Generic;
using Nop.Core;
using Nop.Core.Domain.Catalog;

namespace Nop.Services.Catalog
{
    /// <summary>
    /// Added for Task #1
    /// Author service
    /// </summary>
    public partial interface IAuthorService
    {

        /// <summary>
        /// Deletes an Author
        /// </summary>
        /// <param name="author">Author</param>
        void DeleteAuthor(Author author);


        /// <summary>
        /// Gets all authors
        /// </summary>
        /// <param name="authorFirstName">Author firstname</param>
        /// <param name="authorLastName">Author lastname</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="showHidden">A value indicating whether to show hidden records</param>
        /// <returns>Authors</returns>
        IPagedList<Author> GetAllAuthors(string authorFirstName = "",
            string authorLastName = "",
            int pageIndex = 0,
            int pageSize = int.MaxValue,
            bool showHidden = false);

        /// <summary>
        /// Gets an author
        /// </summary>
        /// <param name="authorId">Author identifier</param>
        /// <returns>Author</returns>
        Author GetAuthorById(int authorId);


        /// <summary>
        /// Inserts an author
        /// </summary>
        /// <param name="author">Author</param>
        void InsertAuthor(Author author);


        /// <summary>
        /// Updates the author
        /// </summary>
        /// <param name="author">Author</param>
        void UpdateAuthor(Author author);


        IList<ProductAuthor> GetProductAuthorsByProductId(int productId, bool showHidden = false);


        void DeleteProductAuthor(ProductAuthor productAuthor);

        void InsertProductAuthor(ProductAuthor productAuthor);


    }
}
