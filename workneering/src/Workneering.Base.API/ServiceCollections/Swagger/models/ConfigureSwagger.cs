using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using Workneering.Base.API.ServiceCollections.Swagger.Extensions;
using Workneering.Base.API.Variables;

namespace Workneering.Base.API.ServiceCollections.Swagger.models;
public class ConfigureSwagger : IConfigureNamedOptions<SwaggerGenOptions>
{
    private readonly IApiVersionDescriptionProvider _provider;
    private readonly SwaggerOptions _config;

    public ConfigureSwagger(IApiVersionDescriptionProvider provider, IConfiguration configuration)
    {
        _config = configuration.GetSwaggerConfig();
        _provider = provider;
    }

    public void Configure(string name, SwaggerGenOptions options)
    {
        Configure(options);
        if (_config.DocumentationEnabled)
        {
            var xmlFilename = $"Swagger-Documentation.xml";
            options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
        }
    }

    public void Configure(SwaggerGenOptions options)
    {
        // add swagger document for every API version discovered
        foreach (var description in _provider.ApiVersionDescriptions)
        {
            options.SwaggerDoc(description.GroupName, CreateVersionInfo(description));
        }
    }
    private OpenApiInfo CreateVersionInfo(ApiVersionDescription description)
    {
        var info = new OpenApiInfo()
        {
            Title = $"{_config.Title} ({EnvVariables.ENVIRONMENT_NAME})",
            Version = description.ApiVersion.ToString()
        };

        if (description.IsDeprecated)
        {
            info.Description += " This API version has been deprecated.";
        }

        return info;
    }
}