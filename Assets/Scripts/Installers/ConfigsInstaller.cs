using Data.Configs;
using Presentation;
using UnityEngine;
using Zenject;

namespace Installers
{
    [CreateAssetMenu(fileName = "ConfigsInstaller", menuName = "Installers/ConfigsInstaller")]
    public class ConfigsInstaller : ScriptableObjectInstaller<ConfigsInstaller>
    {
        public CalculatorConfig calculatorConfig;
        public CalculatorEntryView entryPrefab;

        public override void InstallBindings()
        {
            Container.BindInstance(calculatorConfig);
            Container.BindInstance(entryPrefab);
        }
    }
}