using Microsoft.AspNetCore.Mvc.Filters;

namespace APIcatalogo.Filters
{
    public class ApiLoggingFilter : IActionFilter
    {
        private readonly ILogger<ApiLoggingFilter> _logger;

        public ApiLoggingFilter(ILogger<ApiLoggingFilter> logger) 
        {
        _logger = logger;
        }

        public void OnActionExecuted(ActionExecutedContext context) //antes da action
        {
            _logger.LogInformation("### Executando -> OnActionExcuted");
            _logger.LogInformation("##################################");
            _logger.LogInformation($"{DateTime.Now.ToLongTimeString()}");
            _logger.LogInformation($"ModelState : {context.ModelState.IsValid}");
            _logger.LogInformation("##################################");


        }

        public void OnActionExecuting(ActionExecutingContext context) //após action
        {
            _logger.LogInformation("### Executando -> OnActionExcuting");
            _logger.LogInformation("##################################");
            _logger.LogInformation($"{DateTime.Now.ToLongTimeString()}");
            _logger.LogInformation($"Status Code : {context.HttpContext.Response.StatusCode}");
            _logger.LogInformation("##################################");
        }
    }
}
