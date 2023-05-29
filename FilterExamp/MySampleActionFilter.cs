using Microsoft.AspNetCore.Mvc.Filters;

namespace Filters.FilterExamp
{
    public class MySampleActionFilter : Attribute, IActionFilter
    {
        private readonly ILogger<MySampleActionFilter> _logger;
        private readonly string _name;
        private readonly Guid _randomId;

        public MySampleActionFilter(ILogger<MySampleActionFilter> logger, string name = "Global")
        {
            this._logger = logger;
            this._name = name;
            _randomId = Guid.NewGuid();
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            _logger.LogInformation($"Action Filter - After - {_randomId} - Name : {_name}");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            _logger.LogInformation($"Action Filter - Before {_randomId} - Name : {_name}");
        }
    }
}
