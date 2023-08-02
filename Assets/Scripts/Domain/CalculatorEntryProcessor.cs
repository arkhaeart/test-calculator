using Data;
using Data.Configs;
using Domain.Boundaries;
using Zenject;

namespace Domain
{
    public class CalculatorEntryProcessor : ICalculatorEntryProcessor
    {
        private readonly CalculatorConfig calculatorConfig;
        private readonly ICalculatorOperationsController calculatorOperationsController;

        [Inject]
        public CalculatorEntryProcessor(CalculatorConfig calculatorConfig,
            ICalculatorOperationsController calculatorOperationsController)
        {
            this.calculatorConfig = calculatorConfig;
            this.calculatorOperationsController = calculatorOperationsController;
        }

        public CalculatorEntry Process(string input)
        {
            input = input.Trim();
            if (!IsInputLengthValid(input))
                return GetWrongEntry(input);
            var operatorPosition = -1;
            var firstNumber = -1;
            for (var i = 0; i < input.Length; i++)
            {
                if (char.IsDigit(input[i]))
                    continue;
                if (!calculatorOperationsController.IsSupportedOperation(input[i]) || operatorPosition != -1)
                    return GetWrongEntry(input);
                firstNumber = CalculateNumberFromSubstring(input, 0, i);
                if (firstNumber == -1)
                    return GetWrongEntry(input);
                operatorPosition = i;
            }

            if (operatorPosition == -1)
                return GetWrongEntry(input);
            var remainingLength = input.Length - (operatorPosition + 1);
            if (remainingLength <= 0)
                return GetWrongEntry(input);
            var secondNumber = CalculateNumberFromSubstring(input, operatorPosition + 1, remainingLength);
            if (secondNumber == -1)
                return GetWrongEntry(input);
            var result = calculatorOperationsController.Calculate(input[operatorPosition], firstNumber, secondNumber);
            return new CalculatorEntry { result = result.ToString(), input = input };
        }

        private CalculatorEntry GetWrongEntry(string input)
        {
            return new CalculatorEntry { result = calculatorConfig.wrongInputMessage, input = input };
        }

        private int CalculateNumberFromSubstring(string input, int start, int length)
        {
            var substring = input.Substring(start, length);
            if (int.TryParse(substring, out var result))
                return result;
            return -1;
        }

        private bool IsInputLengthValid(string input)
        {
            return input.Length >= 3;
        }
    }
}