using Microsoft.Extensions.Logging;

namespace Playground.Infrastructure.Base.Repositories
{
    public class PlaygroundRepository<T> where T : class
    {
        private ILogger<T> _logger { get; }

        protected PlaygroundRepository(ILogger<T> logger)
        {
            this._logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        protected ILogger<T> Logger
        {
            get { return _logger; }
        }
    }
}
