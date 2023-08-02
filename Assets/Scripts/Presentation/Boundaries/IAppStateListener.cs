using System;

namespace Presentation.Boundaries
{
    public interface IAppStateListener
    {
        event Action OnPotentialQuit;
    }
}