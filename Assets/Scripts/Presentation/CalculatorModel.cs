using System.Collections.Generic;
using Data;
using Presentation.Boundaries;

namespace Presentation
{
    public class CalculatorModel : ICalculatorModel
    {
        public void AddItem(CalculatorEntry item)
        {
            GetAllEntries.Add(item);
        }

        public string GetLastProcessedItem()
        {
            var item = GetAllEntries[^1];
            return $"{item.input}={item.result}";
        }

        public List<CalculatorEntry> GetAllEntries { get; } = new();
    }
}