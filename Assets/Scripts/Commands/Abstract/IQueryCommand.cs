using System;

namespace Redactor.Commands.Abstract
{
    public interface IQueryCommand
    {
        event Action<bool> CompleteEvent;
        void Execute();
    }
}
