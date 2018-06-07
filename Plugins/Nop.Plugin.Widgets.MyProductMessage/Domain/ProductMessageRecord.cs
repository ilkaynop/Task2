using Nop.Core;

namespace Nop.Plugin.Widgets.MyProductMessage.Domain
{
    /// <summary>
    /// Represents a Google product record
    /// </summary>
    public partial class ProductMessageRecord : BaseEntity
    {
        public int ProductId { get; set; }
        public string MessageHtmlCode { get; set; }
        public int DisplayOrder { get; set; }
    }
}