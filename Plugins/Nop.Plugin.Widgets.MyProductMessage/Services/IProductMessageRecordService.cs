using System.Collections.Generic;
using Nop.Plugin.Widgets.MyProductMessage.Domain;
using Nop.Core;

namespace Nop.Plugin.Widgets.MyProductMessage.Services
{
    public partial interface IProductMessageRecordService
    {
        void DeleteProductMessageRecord(ProductMessageRecord productMessageRecord);

        IList<ProductMessageRecord> GetAll();

        /// <summary>
        /// Gets ProductMessageRecord
        /// </summary>
        /// <param name="productAttributeId">Product attribute identifier</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <returns>Products</returns>
        IPagedList<ProductMessageRecord> GetProductMessageRecords(
            int pageIndex = 0, int pageSize = int.MaxValue, int productId = 0);
        ProductMessageRecord GetById(int googleProductRecordId);

        IList<ProductMessageRecord> GetByProductId(int productId);

        void InsertProductMessageRecord(ProductMessageRecord productMessageRecord);

        void UpdateProductMessageRecord(ProductMessageRecord productMessageRecord);
    }
}
