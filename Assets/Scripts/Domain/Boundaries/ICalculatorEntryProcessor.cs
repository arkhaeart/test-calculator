using Data;

namespace Domain.Boundaries
{
    public interface ICalculatorEntryProcessor
    {
        CalculatorEntry Process(string input);
    }
}