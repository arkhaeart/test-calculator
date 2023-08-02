using TMPro;
using UnityEngine;

namespace Presentation
{
    public class CalculatorEntryView : MonoBehaviour
    {
        [SerializeField] public TMP_Text textField;

        public void SetText(string text)
        {
            textField.text = text;
        }
    }
}