using Autofac;
using Autofac.Core;
using Nop.Core.Configuration;
using Nop.Core.Data;
using Nop.Core.Infrastructure;
using Nop.Core.Infrastructure.DependencyManagement;
using Nop.Data;
using Nop.Plugin.Widgets.MyProductMessage.Data;
using Nop.Plugin.Widgets.MyProductMessage.Domain;
using Nop.Plugin.Widgets.MyProductMessage.Services;
using Nop.Web.Framework.Infrastructure;
using Nop.Web.Framework.Mvc;

namespace Nop.Plugin.Widgets.MyProductMessage.Infrastructure
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
        public virtual void Register(ContainerBuilder builder, ITypeFinder typeFinder, NopConfig config)
        {
           const string  context= "nop_object_context_Bs_product_video";
            builder.RegisterType<ProductMessageRecordService>().As<IProductMessageRecordService>().InstancePerLifetimeScope();

            //data context
            this.RegisterPluginDataContext<ProductMessageObjectContext>(builder, context);

            //override required repository with our custom context
            builder.RegisterType<EfRepository<ProductMessageRecord>>()
                .As<IRepository<ProductMessageRecord>>()
                .WithParameter(ResolvedParameter.ForNamed<IDbContext>(context))
                .InstancePerLifetimeScope();
        }

        public int Order
        {
            get { return 1; }
        }


       
    }
}
