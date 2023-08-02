using System.Collections.Generic;

namespace Presentation.Boundaries
{
    public interface ICalculatorView
    {
        void SetItems(List<string> items, string inputText);
        void AddItem(string item);
        string GetCurrentInput();
        void SetCurrentInput(string text);
    }
}