using System.Collections.Generic;
using Domain.Boundaries;

namespace Domain
{
    public class CalculatorOperationsController : ICalculatorOperationsController
    {
        private Dictionary<char, ICalculatorOperationProcessor> processorsDict;

        public void Initialize()
        {
            
            processorsDict =
                new Dictionary<char, ICalculatorOperationProcessor>
                {
                    ['+'] = new SumOperationProcessor(),
                    ['-']=new SubstanceOperationProcessor(),
                    ['*']=new MultiplyOperationProcessor(),
                    ['/']=new DivideOperationProcessor()
                };
        }

        public bool IsSupportedOperation(char symbol)
        {
            return processorsDict.ContainsKey(symbol);
        }

        public int Calculate(char symbol, int first, int second)
        {
            if (processorsDict.TryGetValue(symbol, out var processor))
                return processor.Process(first, second);
            throw new OperationNotSupportedException();
        }
    }

    public interface ICalculatorOperationProcessor
    {
        public int Process(int first, int second);
    }

    public class SumOperationProcessor : ICalculatorOperationProcessor
    {
        public int Process(int first, int second)
        {
            return first + second;
        }
    }
    public class SubstanceOperationProcessor : ICalculatorOperationProcessor
    {
        public int Process(int first, int second)
        {
            return first - second;
        }
    }
    public class MultiplyOperationProcessor : ICalculatorOperationProcessor
    {
        public int Process(int first, int second)
        {
            return first * second;
        }
    }
    public class DivideOperationProcessor : ICalculatorOperationProcessor
    {
        public int Process(int first, int second)
        {
            if (second == 0)
                return -1;
            return first / second;
        }
    }
}