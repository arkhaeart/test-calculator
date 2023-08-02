using Cysharp.Threading.Tasks;
using Data.Persistence;

namespace Domain.Boundaries
{
    public interface IPersistentDataProvider
    {
        UniTask<CalculatorPersistentData> GetEntries();
        UniTask SaveEntries(CalculatorPersistentData data);
    }
}