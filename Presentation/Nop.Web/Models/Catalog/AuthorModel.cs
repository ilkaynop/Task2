using System.Collections.Generic;
using Nop.Web.Framework.Mvc.Models;
using Nop.Web.Models.Media;

namespace Nop.Web.Models.Catalog
{
    public partial class AuthorModel : BaseNopEntityModel
    {
        public AuthorModel()
        {
            PictureModel = new PictureModel();
            Products = new List<ProductOverviewModel>();
            PagingFilteringContext = new CatalogPagingFilteringModel();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; }
        public string SeName { get; set; }

        public PictureModel PictureModel { get; set; }

        public CatalogPagingFilteringModel PagingFilteringContext { get; set; }

        public IList<ProductOverviewModel> Products { get; set; }
    }
}
