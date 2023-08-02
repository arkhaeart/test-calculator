namespace Domain.Boundaries
{
    public interface ICalculatorOperationsController
    {
        void Initialize();
        bool IsSupportedOperation(char symbol);
        int Calculate(char symbol, int first, int second);
    }
}