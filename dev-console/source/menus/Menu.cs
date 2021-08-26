using System.Collections.Generic;

namespace DevConsole
{
    public class Menu : IMenu
    {
        private readonly Dictionary<byte, string> _options = new()
        {
            { 1, "Character Management" }
        };

        #region IMenu Implementation

        public IReadOnlyDictionary<byte, string> GetOptions() => _options;

        #endregion
    }
}
