using Nop.Data.Mapping;
using Nop.Plugin.Widgets.MyProductMessage.Domain;

namespace Nop.Plugin.Widgets.MyProductMessage.Data
{
    public partial class ProductMessageRecordMap : NopEntityTypeConfiguration<ProductMessageRecord>
    {
        public ProductMessageRecordMap()
        {
            this.ToTable("ProductMessageRecord");
            this.HasKey(x => x.Id);
        }
    }
}