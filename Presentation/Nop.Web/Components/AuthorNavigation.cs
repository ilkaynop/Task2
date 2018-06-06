using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Nop.Core.Domain.Catalog;
using Nop.Web.Factories;
using Nop.Web.Framework.Components;

namespace Nop.Web.Components
{
    public class AuthorNavigationViewComponent : NopViewComponent
    {
        private readonly ICatalogModelFactory _catalogModelFactory;
        private readonly CatalogSettings _catalogSettings;

        public AuthorNavigationViewComponent(ICatalogModelFactory catalogModelFactory,
            CatalogSettings catalogSettings)
        {
            this._catalogModelFactory = catalogModelFactory;
            this._catalogSettings = catalogSettings;
        }

        public IViewComponentResult Invoke(int currentAuthorId)
        {

            var model = _catalogModelFactory.PrepareAuthorNavigationModel(currentAuthorId);
            if (!model.Authors.Any())
                return Content("");

            return View(model);
        }
    }
}
