using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace IdentityService.Common
{
    [AttributeUsage(AttributeTargets.Property)]
    public class BasicAuthAttribute : Attribute { }

    public class SwaggerBasicAuthFilter : IOperationFilter
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SwaggerBasicAuthFilter(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var requestHeaders = _httpContextAccessor.HttpContext?.Request?.Headers;

            if (requestHeaders != null && requestHeaders.ContainsKey("Authorization"))
            {
                operation.Parameters ??= new List<OpenApiParameter>();
                operation.Parameters.Add(new OpenApiParameter
                {
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Required = true,
                    Description = "Basic authentication header in the form of 'Basic {base64encodedusernameandpassword}'",
                    Schema = new OpenApiSchema { Type = "string" },
                    Example = new OpenApiString("Basic QWxhZGRpbjpPcGVuU2VzYW1l")
                });

                // Set the "security" property of the operation to require the "basicAuth" scheme.
                operation.Security ??= new List<OpenApiSecurityRequirement>();
                operation.Security.Add(new OpenApiSecurityRequirement
                {
                    { new OpenApiSecurityScheme { Reference = new OpenApiReference
                        {
                            Id = "basicAuth",
                            Type = ReferenceType.SecurityScheme
                        } }, new List<string>() }
                });
            }
        }
    }
}
