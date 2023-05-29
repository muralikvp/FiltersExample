using Microsoft.AspNetCore.Mvc.Filters;

namespace Filters.FilterExamp
{
    public class ResourceFileAttribute : Attribute, IResourceFilter
    {
        private readonly string _name;
        private readonly ILogger<ResourceFileAttribute> _logger;


        public ResourceFileAttribute(ILogger<ResourceFileAttribute> logger,string name="Res Global")
        {
            this._logger = logger;
            this._name = name;
        }
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            _logger.LogInformation($"Resource Filter - After - Name : {_name}");
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            _logger.LogInformation($"Resource Filter - Before - Name : {_name}");
        }
    }
}
