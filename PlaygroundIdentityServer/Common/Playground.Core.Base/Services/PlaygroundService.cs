
using Microsoft.Extensions.Logging;

namespace Playground.Core.Base.Services
{
    public class PlaygroundService<T> where T : class
    {
        private ILogger<T> _logger { get; }

        protected PlaygroundService(ILogger<T> logger)
        {
            this._logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        protected ILogger<T> Logger
        {
            get { return _logger; }
        }
    }
}
