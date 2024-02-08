using Autofac;

namespace DotNetCoreWeb.AdminLTE.ProjectTemplates.Core;

public class AutofacModuleRegister : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        // 掃描並且註冊所有 Service
        builder.RegisterAssemblyTypes(typeof(Program).Assembly)
            .Where(t => t.Name.EndsWith("Service"))
            .AsImplementedInterfaces();
    }
}