namespace Presentation.Boundaries
{
    public interface ICalculatorPresenter
    {
        void OnUserInput(string input);
        void SetView(ICalculatorView view);
    }
}