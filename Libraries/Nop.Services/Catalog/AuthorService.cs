using System;
using System.Collections.Generic;
using System.Linq;
using Nop.Core;
using Nop.Core.Caching;
using Nop.Core.Data;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Security;
using Nop.Core.Domain.Stores;
using Nop.Services.Customers;
using Nop.Services.Events;

namespace Nop.Services.Catalog
{

    /// <summary>
    /// Added for Task #1
    /// Author service
    /// </summary>
    public partial class AuthorService : IAuthorService
    {

        #region Fields

        private readonly IRepository<Author> _authorRepository;
        private readonly IRepository<ProductAuthor> _productAuthorRepository;
        private readonly IEventPublisher _eventPublisher;
        private readonly ICacheManager _cacheManager;

        #endregion


        #region Ctor

        public AuthorService(IRepository<Author> authorRepository,
            IRepository<ProductAuthor> productAuthorRepository, IEventPublisher eventPublisher, ICacheManager cacheManager)
        {
            this._authorRepository = authorRepository;
            this._productAuthorRepository = productAuthorRepository;
            this._eventPublisher = eventPublisher;
            this._cacheManager = cacheManager;
        }

        #endregion


        public void DeleteAuthor(Author author)
        {
            if (author == null)
                throw new ArgumentNullException("author");

            author.Deleted = true;
            UpdateAuthor(author);

            //event notification
            _eventPublisher.EntityDeleted(author);
        }

        public IPagedList<Author> GetAllAuthors(string authorFirstName = "", string authorLastName = "", int pageIndex = 0, int pageSize = int.MaxValue, bool showHidden = false)
        {
            var query = _authorRepository.Table;

            if (!String.IsNullOrEmpty(authorFirstName))
            {
                query = query.Where(x => x.FirstName.Contains(authorFirstName));
            }

            if (!String.IsNullOrEmpty(authorLastName))
            {
                query = query.Where(x => x.LastName.Contains(authorLastName));
            }

            query = query.Where(m => !m.Deleted);

            query = query.OrderBy(x => x.Id);

            var authors = new PagedList<Author>(query, pageIndex, pageSize);
            return authors;
        }

        public Author GetAuthorById(int authorId)
        {
            if (authorId == 0)
                return null;

            return _authorRepository.GetById(authorId);
        }

        public void InsertAuthor(Author author)
        {
            if (author == null)
                throw new ArgumentNullException("author");

            _authorRepository.Insert(author);

            //event notification
            _eventPublisher.EntityInserted(author);
        }

        public void UpdateAuthor(Author author)
        {
            if (author == null)
                throw new ArgumentNullException("author");

            _authorRepository.Update(author);

            //event notification
            _eventPublisher.EntityUpdated(author);
        }




        /// <summary>
        /// Gets a product manufacturer mapping collection
        /// </summary>
        /// <param name="productId">Product identifier</param>
        /// <param name="showHidden">A value indicating whether to show hidden records</param>
        /// <returns>Product author mapping collection</returns>
        public virtual IList<ProductAuthor> GetProductAuthorsByProductId(int productId, bool showHidden = false)
        {
            if (productId == 0)
                return new List<ProductAuthor>();

                var query = from pm in _productAuthorRepository.Table
                            join m in _authorRepository.Table on pm.AuthorId equals m.Id
                            where pm.ProductId == productId &&
                                !m.Deleted &&
                                (showHidden)
                            orderby pm.AuthorId, pm.Id
                            select pm;


            var productAuthors = query.ToList();
                return productAuthors;

        }



        /// <summary>
        /// Deletes a product author mapping
        /// </summary>
        /// <param name="productAuthor">Product author mapping</param>
        public virtual void DeleteProductAuthor(ProductAuthor productAuthor)
        {
            if (productAuthor == null)
                throw new ArgumentNullException(nameof(productAuthor));

            _productAuthorRepository.Delete(productAuthor);

            //event notification
            _eventPublisher.EntityDeleted(productAuthor);
        }


        /// <summary>
        /// Inserts a product author mapping
        /// </summary>
        /// <param name="productAuthor">Product author mapping</param>
        public virtual void InsertProductAuthor(ProductAuthor productAuthor)
        {
            if (productAuthor == null)
                throw new ArgumentNullException(nameof(productAuthor));

            _productAuthorRepository.Insert(productAuthor);


            //event notification
            _eventPublisher.EntityInserted(productAuthor);
        }




    }
}
