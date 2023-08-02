using System.Collections.Generic;
using Presentation.Boundaries;
using TMPro;
using UnityEngine;
using Zenject;

namespace Presentation
{
    public class CalculatorView : MonoBehaviour, ICalculatorView
    {
        [SerializeField] private TMP_InputField inputField;
        [SerializeField] private RectTransform scrollViewContents;
        private ICalculatorPresenter calculatorPresenter;
        private CalculatorEntryView entryPrefab;

        public void SetItems(List<string> items, string inputText)
        {
            inputField.text = inputText;
            for (var i = 0; i < items.Count; i++) AddItem(items[i]);
        }

        public void AddItem(string item)
        {
            var newItem = Instantiate(entryPrefab, scrollViewContents);
            newItem.SetText(item);
        }

        public string GetCurrentInput()
        {
            return inputField.text;
        }
        public void SetCurrentInput(string text)
        {
            inputField.text = text;
        }

        [Inject]
        public void Construct(ICalculatorPresenter calculatorPresenter, CalculatorEntryView entryPrefab)
        {
            this.calculatorPresenter = calculatorPresenter;
            this.calculatorPresenter.SetView(this);
            this.entryPrefab = entryPrefab;
        }

        public void Submit()
        {
            if (string.IsNullOrEmpty(inputField.text.Trim()))
                return;
            calculatorPresenter.OnUserInput(inputField.text);
            inputField.text = "";
        }
    }
}