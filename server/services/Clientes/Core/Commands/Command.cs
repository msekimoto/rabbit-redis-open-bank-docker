using System;
using Core.Events;

namespace Core.Commands
{
    public abstract class Command : Message
    {
        protected DateTime Timestamp { get; private set; }

        public Command()
        {
            Timestamp = DateTime.UtcNow;
        }
    }
}
