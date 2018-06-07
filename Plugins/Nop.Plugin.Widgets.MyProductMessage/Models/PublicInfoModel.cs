using System.Collections.Generic;
using Nop.Web.Framework.Mvc;
using Nop.Web.Framework.Mvc.Models;

namespace Nop.Plugin.Widgets.MyProductMessage.Models
{
    public class PublicInfoModel : BaseNopModel
    {
        public PublicInfoModel()
        {
            EmbedMessageRecordModels=new List<EmbedMessageModel>();
        }
        public int ProductId { get; set; }

        public IList<EmbedMessageModel> EmbedMessageRecordModels { get; set; }

        public class EmbedMessageModel
        {
            public int Id { get; set; }
            public string MessageHtmlCode { get; set; }

        }
    }
}