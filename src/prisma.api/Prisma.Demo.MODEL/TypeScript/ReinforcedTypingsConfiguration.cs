using Reinforced.Typings.Fluent;

namespace Prisma.Demo.MODEL
{
    public static class ReinforcedTypingsConfiguration
    {
        public static void Configure(ConfigurationBuilder builder)
        {
            builder.Global(config =>
            {
                config.CamelCaseForProperties(true);
                config.UseModules(true);
                config.AutoOptionalProperties(true);
                config.ExportPureTypings(true);
            });
        }
    }
}