using System;

namespace DevConsole
{
    public interface IApplicationState
    {
        IApplicationState Process(ConsoleKey command);
        ConsoleKey Prompt();
        IApplicationState WriteView();
    }
}
