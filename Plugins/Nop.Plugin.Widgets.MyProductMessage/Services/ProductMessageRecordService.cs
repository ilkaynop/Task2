using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Nop.Core.Data;
using Nop.Plugin.Widgets.MyProductMessage.Domain;
using Nop.Core;

namespace Nop.Plugin.Widgets.MyProductMessage.Services
{
    public partial class ProductMessageRecordService : IProductMessageRecordService
    {
        #region Fields

        private readonly IRepository<ProductMessageRecord> _productMessageRecordRepository;

        #endregion

        #region Ctor

        public ProductMessageRecordService(IRepository<ProductMessageRecord> productMessageRecordRepository)
        {
            this._productMessageRecordRepository = productMessageRecordRepository;
        }

        #endregion

        #region Utilties

        private string GetEmbeddedFileContent(string resourceName)
        {
            string fullResourceName = string.Format("Nop.Plugin.Feed.Froogle.Files.{0}", resourceName);
            var assem = this.GetType().Assembly;
            using (var stream = assem.GetManifestResourceStream(fullResourceName))
            using (var reader = new StreamReader(stream))
                return reader.ReadToEnd();
        }

        #endregion

        #region Methods

        public virtual void DeleteProductMessageRecord(ProductMessageRecord productMessageRecord)
        {
            if (productMessageRecord == null)
                throw new ArgumentNullException("productVideoRecord");

            _productMessageRecordRepository.Delete(productMessageRecord);
        }

        public virtual IList<ProductMessageRecord> GetAll()
        {
            var query = from gp in _productMessageRecordRepository.Table
                        orderby gp.Id
                        select gp;
            query = query.OrderBy(x => x.DisplayOrder);
            var records = query.ToList();
            return records;
        }
        public virtual IPagedList<ProductMessageRecord> GetProductMessageRecords(
           int pageIndex = 0, int pageSize = int.MaxValue, int productId = 0)
        {
            var query = _productMessageRecordRepository.Table;
            query = query.OrderBy(x => x.Id);

            if (productId > 0)
            {
                query = query.Where(x => x.ProductId.Equals(productId));
            }
            query = query.OrderBy(x => x.DisplayOrder);
            var products = new PagedList<ProductMessageRecord>(query, pageIndex, pageSize);
            return products;
        }
        public virtual ProductMessageRecord GetById(int productMessageRecordId)
        {
            if (productMessageRecordId == 0)
                return null;

            return _productMessageRecordRepository.GetById(productMessageRecordId);
        }

        public virtual IList<ProductMessageRecord> GetByProductId(int productId)
        {
            if (productId == 0)
                return new List<ProductMessageRecord>();

            var query = from gp in _productMessageRecordRepository.Table
                        where gp.ProductId == productId
                        orderby gp.Id
                        select gp;
            query = query.OrderBy(x => x.DisplayOrder);
            return query.ToList();
        }

        public virtual void InsertProductMessageRecord(ProductMessageRecord productMessageRecord)
        {
            if (productMessageRecord == null)
                throw new ArgumentNullException("productMessageRecord");

            _productMessageRecordRepository.Insert(productMessageRecord);
        }

        public virtual void UpdateProductMessageRecord(ProductMessageRecord productMessageRecord)
        {
            if (productMessageRecord == null)
                throw new ArgumentNullException("productMessageRecord");

            _productMessageRecordRepository.Update(productMessageRecord);
        }


        #endregion
    }
}
