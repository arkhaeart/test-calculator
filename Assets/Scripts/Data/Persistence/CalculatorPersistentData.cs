using System;
using System.Collections.Generic;

namespace Data.Persistence
{
    [Serializable]
    public class CalculatorPersistentData
    {
        public string input;
        public List<CalculatorEntry> entries;

        public CalculatorPersistentData(List<CalculatorEntry> entries, string input = "")
        {
            this.input = input;
            this.entries = entries;
        }

        public CalculatorPersistentData()
        {
        }
    }
}