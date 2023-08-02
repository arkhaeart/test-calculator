using System.Collections.Generic;
using Data;

namespace Presentation.Boundaries
{
    public interface ICalculatorModel
    {
        List<CalculatorEntry> GetAllEntries { get; }
        void AddItem(CalculatorEntry item);
        string GetLastProcessedItem();
    }
}