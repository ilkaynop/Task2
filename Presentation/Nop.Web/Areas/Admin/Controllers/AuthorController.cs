using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nop.Web.Areas.Admin.Extensions;
using Nop.Web.Areas.Admin.Helpers;
using Nop.Web.Areas.Admin.Models.Catalog;
using Nop.Core;
using Nop.Core.Caching;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Discounts;
using Nop.Services;
using Nop.Services.Catalog;
using Nop.Services.Customers;
using Nop.Services.Discounts;
using Nop.Services.ExportImport;
using Nop.Services.Localization;
using Nop.Services.Logging;
using Nop.Services.Media;
using Nop.Services.Security;
using Nop.Services.Seo;
using Nop.Services.Stores;
using Nop.Services.Vendors;
using Nop.Web.Framework.Controllers;
using Nop.Web.Framework.Kendoui;
using Nop.Web.Framework.Mvc;
using Nop.Web.Framework.Mvc.Filters;

namespace Nop.Web.Areas.Admin.Controllers
{

    /// <summary>
    /// Added for Task #1
    /// Author controller
    /// </summary>
    public partial class AuthorController : BaseAdminController
    {

        #region Fields

        private readonly ICategoryService _categoryService;
        private readonly IAuthorService _authorService;
        private readonly IProductService _productService;
        private readonly ICustomerService _customerService;
        private readonly IStoreService _storeService;
        private readonly IStoreMappingService _storeMappingService;
        private readonly IUrlRecordService _urlRecordService;
        private readonly IPictureService _pictureService;
        private readonly ILanguageService _languageService;
        private readonly ILocalizationService _localizationService;
        private readonly ILocalizedEntityService _localizedEntityService;
        private readonly IExportManager _exportManager;
        private readonly IDiscountService _discountService;
        private readonly ICustomerActivityService _customerActivityService;
        private readonly IVendorService _vendorService;
        private readonly IAclService _aclService;
        private readonly IPermissionService _permissionService;
        private readonly CatalogSettings _catalogSettings;
        private readonly IWorkContext _workContext;
        private readonly IImportManager _importManager;
        private readonly IStaticCacheManager _cacheManager;

        #endregion

        #region Ctor

        public AuthorController(ICategoryService categoryService,
            IAuthorService authorService,
            IProductService productService,
            ICustomerService customerService,
            IStoreService storeService,
            IStoreMappingService storeMappingService,
            IUrlRecordService urlRecordService,
            IPictureService pictureService,
            ILanguageService languageService,
            ILocalizationService localizationService,
            ILocalizedEntityService localizedEntityService,
            IExportManager exportManager,
            IDiscountService discountService,
            ICustomerActivityService customerActivityService,
            IVendorService vendorService,
            IAclService aclService,
            IPermissionService permissionService,
            CatalogSettings catalogSettings,
            IWorkContext workContext,
            IImportManager importManager,
            IStaticCacheManager cacheManager)
        {
            this._categoryService = categoryService;
            this._authorService = authorService;
            this._productService = productService;
            this._customerService = customerService;
            this._storeService = storeService;
            this._storeMappingService = storeMappingService;
            this._urlRecordService = urlRecordService;
            this._pictureService = pictureService;
            this._languageService = languageService;
            this._localizationService = localizationService;
            this._localizedEntityService = localizedEntityService;
            this._exportManager = exportManager;
            this._discountService = discountService;
            this._customerActivityService = customerActivityService;
            this._vendorService = vendorService;
            this._aclService = aclService;
            this._permissionService = permissionService;
            this._catalogSettings = catalogSettings;
            this._workContext = workContext;
            this._importManager = importManager;
            this._cacheManager = cacheManager;
        }

        #endregion


        // GET: CanliEgitim
        public virtual IActionResult Index()
        {
            return RedirectToAction("List");
        }


        public virtual IActionResult List()
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageAuthors))
                return AccessDeniedView();

            return View();
        }

        [HttpPost]
        public virtual IActionResult List(DataSourceRequest command, AuthorListModel model)
        {

            if (!_permissionService.Authorize(StandardPermissionProvider.ManageAuthors))
                return AccessDeniedKendoGridJson();


            var authorsModels = _authorService.GetAllAuthors(authorFirstName: model.SearchFirstName, authorLastName: model.SearchLastName, pageIndex: command.Page - 1, pageSize: command.PageSize, showHidden: true)
                .Select(x => x.ToModel())
                .ToList();

            var gridModel = new DataSourceResult
            {
                Data = authorsModels,
                Total = authorsModels.Count
            };

            return Json(gridModel);
        }


        #region Create / Edit / Delete

        public virtual IActionResult Create()
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageAuthors))
                return AccessDeniedView();

            var model = new AuthorModel();

            return View(model);
        }


        [HttpPost, ParameterBasedOnFormName("save-continue", "continueEditing")]
        public virtual IActionResult Create(AuthorModel model, bool continueEditing)
        {

            if (!_permissionService.Authorize(StandardPermissionProvider.ManageAuthors))
                return AccessDeniedView();

            if (ModelState.IsValid)
            {

                var author = model.ToEntity();
                author.CreatedOnUtc = DateTime.UtcNow;
                author.UpdatedOnUtc = DateTime.UtcNow;
                author.Deleted = false;
                _authorService.InsertAuthor(author);
                //search engine name
                model.SeName = author.ValidateSeName(model.SeName, author.FirstName + " " + author.LastName , true);
                _urlRecordService.SaveSlug(author, model.SeName, 0);



                if (continueEditing)
                {
                    //selected tab
                    SaveSelectedTabName();

                    return RedirectToAction("Edit", new { id = author.Id });
                }
                return RedirectToAction("List");

            }

            //If we got this far, something failed, redisplay form
            return View(model);
        }


        public virtual IActionResult Edit(int id)
        {

            if (!_permissionService.Authorize(StandardPermissionProvider.ManageAuthors))
                return AccessDeniedView();

            var author = _authorService.GetAuthorById(id);
            if (author == null)
                //No author found with the specified id
                return RedirectToAction("List");

            var model = author.ToModel();

            return View(model);
        }


        [HttpPost, ParameterBasedOnFormName("save-continue", "continueEditing")]
        public virtual IActionResult Edit(AuthorModel model, bool continueEditing)
        {

            if (!_permissionService.Authorize(StandardPermissionProvider.ManageAuthors))
                return AccessDeniedView();


            var author = _authorService.GetAuthorById(model.Id);
            if (author == null)
                //No author found with the specified id
                return RedirectToAction("List");

            if (ModelState.IsValid)
            {
                author = model.ToEntity(author);
                _authorService.UpdateAuthor(author);

                //search engine name
                model.SeName = author.ValidateSeName(model.SeName, author.FirstName + " " + author.LastName, true);
                _urlRecordService.SaveSlug(author, model.SeName, 0);

                SuccessNotification(_localizationService.GetResource("Admin.ContentManagement.Author.Updated"));

                //activity log
                _customerActivityService.InsertActivity("EditAuthor", _localizationService.GetResource("ActivityLog.EditAuthor"), author.FirstName + author.LastName);

                if (continueEditing)
                {
                    //selected tab
                    SaveSelectedTabName();

                    return RedirectToAction("Edit", new { id = author.Id });
                }
                return RedirectToAction("List");
            }

            return View(model);
        }


        [HttpPost]
        public virtual IActionResult Delete(int id)
        {

            if (!_permissionService.Authorize(StandardPermissionProvider.ManageAuthors))
                return AccessDeniedView();

            var author = _authorService.GetAuthorById(id);
            if (author == null)
                //No author found with the specified id
                return RedirectToAction("List");

            _authorService.DeleteAuthor(author);

            SuccessNotification(_localizationService.GetResource("Admin.ContentManagement.Author.Deleted"));
            return RedirectToAction("List");
        }



        #endregion






    }
}
