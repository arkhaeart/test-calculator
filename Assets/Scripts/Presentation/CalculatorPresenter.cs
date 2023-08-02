using Cysharp.Threading.Tasks;
using Data;
using Data.Persistence;
using Domain.Boundaries;
using Presentation.Boundaries;
using Zenject;

namespace Presentation
{
    public class CalculatorPresenter : ICalculatorPresenter, ICalculatorStarter
    {
        private readonly ICalculatorEntryProcessor calculatorEntryProcessor;
        private readonly IPersistentDataProvider persistentDataProvider;
        private readonly ICalculatorModel calculatorModel;
        private ICalculatorView calculatorView;

        [Inject]
        public CalculatorPresenter(IAppStateListener appStateListener,
            ICalculatorEntryProcessor calculatorEntryProcessor,
            IPersistentDataProvider persistentDataProvider)
        {
            appStateListener.OnPotentialQuit += End;
            this.calculatorEntryProcessor = calculatorEntryProcessor;
            this.persistentDataProvider = persistentDataProvider;
            calculatorModel = new CalculatorModel();
        }

        public void OnUserInput(string input)
        {
            var newEntry = calculatorEntryProcessor.Process(input);
            ProcessEntry(newEntry);
        }

        public void SetView(ICalculatorView view)
        {
            calculatorView = view;
        }

        public async UniTaskVoid Start()
        {
            var data = await persistentDataProvider.GetEntries();
            for (var i = 0; i < data.entries.Count; i++)
            {
                var entry = data.entries[i];
                ProcessEntry(entry);
            }
            calculatorView.SetCurrentInput(data.input);
        }

        private void ProcessEntry(CalculatorEntry newEntry)
        {
            calculatorModel.AddItem(newEntry);
            var item = calculatorModel.GetLastProcessedItem();
            calculatorView.AddItem(item);
        }


        private void End()
        {
            var entries = calculatorModel.GetAllEntries;
            var input = calculatorView.GetCurrentInput();
            persistentDataProvider.SaveEntries(new CalculatorPersistentData(entries, input)).Forget();
        }
    }
}