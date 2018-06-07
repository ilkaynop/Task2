using System.Collections.Generic;
using System.IO;
using System.Linq;
using Nop.Core;
using Nop.Core.Plugins;
using Nop.Services.Cms;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using Nop.Services.Media;
using Nop.Plugin.Widgets.MyProductMessage.Data;
using Nop.Web.Framework.Menu;

namespace Nop.Plugin.Widgets.MyProductMessage
{
    /// <summary>
    /// PLugin
    /// </summary>
    public class ProductMessagePlugin : BasePlugin, IWidgetPlugin, IAdminMenuPlugin
    {
        private readonly IPictureService _pictureService;
        private readonly ISettingService _settingService;
        private readonly IWebHelper _webHelper;
        private readonly ProductMessageObjectContext _objectContext;

        public ProductMessagePlugin(IPictureService pictureService,
            ISettingService settingService, IWebHelper webHelper, ProductMessageObjectContext objectContext)
        {
            this._pictureService = pictureService;
            this._settingService = settingService;
            this._webHelper = webHelper;
            this._objectContext = objectContext;
        }



        /// <summary>
        /// Gets widget zones where this widget should be rendered
        /// </summary>
        /// <returns>Widget zones</returns>
        public IList<string> GetWidgetZones()
        {
            return new List<string> { "productdetails_top" };
        }


        /// <summary>
        /// Gets a configuration page URL
        /// </summary>
        public override string GetConfigurationPageUrl()
        {
            return _webHelper.GetStoreLocation() + "Admin/ProductMessage/Configure";
        }

        /// <summary>
        /// Gets a view component for displaying plugin in public store
        /// </summary>
        /// <param name="widgetZone">Name of the widget zone</param>
        /// <param name="viewComponentName">View component name</param>
        public void GetPublicViewComponent(string widgetZone, out string viewComponentName)
        {
            viewComponentName = "WidgetsProductMessage";
        }
       

       
        /// <summary>
        /// Install plugin
        /// </summary>
        public override void Install()
        {
            //save settings
            
            //_settingService.SaveSetting(settings);


            this.AddOrUpdatePluginLocaleResource("Nop.Plugin.Widgets.MyProductMessage.Button.AddMessage", "Add Message");
            this.AddOrUpdatePluginLocaleResource("Plugin.Widgets.MyProductMessage.ProductId", "Product Id");

            this.AddOrUpdatePluginLocaleResource("Plugin.Widgets.MyProductMessage.ProductName", "Product Name");
            this.AddOrUpdatePluginLocaleResource("Plugin.Widgets.MyProductMessage.MessageHtmlCode", "Message Html Code");
            this.AddOrUpdatePluginLocaleResource("Plugin.Widgets.MyProductMessage.Picture", "Thumbnail");
            this.AddOrUpdatePluginLocaleResource("Plugin.Widgets.MyProductMessage.DisplayOrder", "Display Order");
            
               //data
            _objectContext.Install();


            base.Install();


           
        }

        /// <summary>
        /// Uninstall plugin
        /// </summary>
        public override void Uninstall()
        {
            //settings
            //_settingService.DeleteSetting<SettingsName>();

            //locales
            this.DeletePluginLocaleResource("key");

            this.DeletePluginLocaleResource("Nop.Plugin.Widgets.MyProductMessage.Button.AddMessage");
            this.DeletePluginLocaleResource("Plugin.Widgets.MyProductMessage.ProductId");

            this.DeletePluginLocaleResource("Plugin.Widgets.MyProductMessage.ProductName");
            this.DeletePluginLocaleResource("Plugin.Widgets.MyProductMessage.MessageHtmlCode");
            this.DeletePluginLocaleResource("Plugin.Widgets.MyProductMessage.Picture");
            this.DeletePluginLocaleResource("Plugin.Widgets.MyProductMessage.DisplayOrder");
            
           //data
            _objectContext.Uninstall();

            base.Uninstall();
        }

        public void ManageSiteMap(SiteMapNode rootNode)
        {

           

            var menuItem = new SiteMapNode()
            {
                Visible = true,
                Title = "Product Message",
                Url = ""
            };

            var menuItemProductList = new SiteMapNode()
            {
                Visible = true,
                Title = "Configure",
                Url = "/Admin/ProductMessage/List"
                
            };

            menuItem.ChildNodes.Add(menuItemProductList);

            var pluginNode = rootNode.ChildNodes.FirstOrDefault(x => x.SystemName == "nopAyas");
            if (pluginNode != null)
                pluginNode.ChildNodes.Add(menuItem);
            else
            {
                var ayas = new SiteMapNode()
                {
                    Visible = true,
                    Title = "AyasPlugins",
                    Url = "",
                    SystemName = "nopAyas",
                    IconClass= "fa fa - bars"
                };
                ayas.ChildNodes.Add(menuItem);

                rootNode.ChildNodes.Add(ayas);
            }

           // rootNode.ChildNodes.Add(menuItemBuilder);
            
        }
    }
}
