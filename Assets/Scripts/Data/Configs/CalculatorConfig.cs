using UnityEngine;

namespace Data.Configs
{
    [CreateAssetMenu(menuName = "Configs/Main")]
    public class CalculatorConfig : ScriptableObject
    {
        public string wrongInputMessage = "ERROR";
    }
}