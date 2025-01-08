using WebAPI.Utilities.AutoMapper.Formatters;

namespace WebAPI.Extensions
{
    public static class MvcBuilderExtensions
    {
        public static IMvcBuilder AddCustomCsvFormatter(this IMvcBuilder builder) =>
            builder.AddMvcOptions(config =>
            config.OutputFormatters
            .Add(new CsvOutputFormatter()));
    }
}
