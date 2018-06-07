using System;
using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Core.Caching;
using Nop.Services.Configuration;
using Nop.Services.Logging;
using Nop.Services.Media;
using Nop.Web.Framework.Components;
using Nop.Plugin.Widgets.MyProductMessage.Models;
using Nop.Services.Catalog;
using Nop.Plugin.Widgets.MyProductMessage.Services;
using System.Linq;
using Nop.Core.Domain.Media;

namespace Nop.Plugin.Widgets.MyProductMessage.Components
{
    [ViewComponent(Name = "WidgetsProductMessage")]
    public class WidgetsProductVideoViewComponent : NopViewComponent
    {
        private readonly IStoreContext _storeContext;
        private readonly IStaticCacheManager _cacheManager;
        private readonly ISettingService _settingService;
        private readonly IPictureService _pictureService;
        private readonly ILogger _logger;
        private readonly IProductService _productService;
        private readonly IProductMessageRecordService _productMessageRecordService;
        private readonly MediaSettings _mediaSettings;

        public WidgetsProductVideoViewComponent(IStoreContext storeContext, 
            IStaticCacheManager cacheManager, 
            ISettingService settingService, 
            IPictureService pictureService, 
            ILogger logger,
            IProductService productService,
            IProductMessageRecordService productMessageRecordService,
            MediaSettings mediaSettings)
        {
            this._storeContext = storeContext;
            this._cacheManager = cacheManager;
            this._settingService = settingService;
            this._pictureService = pictureService;
            _logger = logger;
            _productService = productService;
            _productMessageRecordService = productMessageRecordService;
            _mediaSettings = mediaSettings;
        }

        public IViewComponentResult Invoke(string widgetZone, object additionalData)
        {

            var wZone = widgetZone;

            if (wZone == "productdetails_top" && additionalData != null)
            {
                var product = _productService.GetProductById((int)additionalData);
                var model = new PublicInfoModel()
                {
                    ProductId = product.Id
                };
                var productMessageRecords = _productMessageRecordService.GetByProductId(product.Id);
                if (productMessageRecords.Count == 0)
                    return Content("");

                var firstproductMessageRecord = productMessageRecords.First();

                PublicInfoModel.EmbedMessageModel embedMessageModel = new PublicInfoModel.EmbedMessageModel();

                embedMessageModel.Id = firstproductMessageRecord.Id;
                embedMessageModel.MessageHtmlCode = firstproductMessageRecord.MessageHtmlCode;

                model.EmbedMessageRecordModels.Add(embedMessageModel);


                return View("~/Plugins/Widgets.MyProductMessage/Views/ProductMessage/PublicInfo.cshtml", model);
            }

            return Content("");
        }

        

       
    }
}
