using System.Collections.Generic;

namespace DevConsole
{
    public interface IMenu
    {
        IReadOnlyDictionary<byte, string> GetOptions();
    }
}
