using Autofac;
using Microsoft.Extensions.Caching.Memory;
using Pschool.Application.Interfaces.Repository;
using Pschool.Infrastructure.Data.Contexts;
using Pschool.Infrastructure.Repository;
using Pschool.Shared.Results;
using Pschool.Shared.Interfaces;

namespace Pschool.Infrastructure.ModuleContainer
{
    public class PschoolModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<PschoolPersonContext>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>)).InstancePerLifetimeScope();
            builder.RegisterType<MemoryCache>().As<IMemoryCache>().InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(Result<>)).As(typeof(IResult<>)).InstancePerLifetimeScope();
            builder.RegisterType<StudentRepository>().As<IStudentRepository>().InstancePerLifetimeScope();
            base.Load(builder);
        }

    }
}
