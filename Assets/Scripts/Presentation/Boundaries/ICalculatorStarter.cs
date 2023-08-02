using Cysharp.Threading.Tasks;

namespace Presentation.Boundaries
{
    public interface ICalculatorStarter
    {
        UniTaskVoid Start();
    }
}