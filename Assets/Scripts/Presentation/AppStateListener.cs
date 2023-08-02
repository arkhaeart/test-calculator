using System;
using Presentation.Boundaries;
using UnityEngine;

namespace Presentation
{
    public class AppStateListener : MonoBehaviour, IAppStateListener
    {
        private void OnDestroy()
        {
            OnPotentialQuit?.Invoke();
        }

        private void OnApplicationQuit()
        {
            OnPotentialQuit?.Invoke();
        }

        public event Action OnPotentialQuit;
    }
}