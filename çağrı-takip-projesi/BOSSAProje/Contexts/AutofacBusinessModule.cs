using Autofac;
using Autofac.Extras.DynamicProxy;
using BOSSAProje.Contexts.Abstract;
using BOSSAProje.Views.Contexts;
using Castle.DynamicProxy;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;

namespace BOSSAProje.Contexts
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EfCihazDal>().As<ICihazDal>();
           


            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
