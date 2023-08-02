using System;
using System.Collections.Generic;

namespace Data.State
{
    [Serializable]
    public class OperationsHistory
    {
        public List<CalculatorEntry> entries = new();
    }
}