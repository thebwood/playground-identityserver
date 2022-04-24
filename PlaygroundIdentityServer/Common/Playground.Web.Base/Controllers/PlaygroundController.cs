using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Playground.Common.Security;

namespace Playground.Web.Base.Controllers
{
    [ApiController]
    public class PlaygroundController<T> : ControllerBase where T : class
    {
        private ILogger<T> _logger { get; }
        protected PlaygroundController(ILogger<T> logger)
        {
            this._logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        protected internal AuthenticatedUser CurrentUser
        {
            get { return AuthenticatedUser.Get(base.User); }
        }

        protected string GetHeaderValue(string headerKey)
        {
            if (headerKey == null)
                throw new ArgumentNullException(nameof(headerKey));

            return HttpContext.Request.Headers[headerKey].FirstOrDefault();
        }



        protected ILogger<T> Logger
        {
            get { return _logger; }
        }


    }
}
