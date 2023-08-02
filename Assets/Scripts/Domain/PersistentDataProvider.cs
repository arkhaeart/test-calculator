using System.Collections.Generic;
using Common;
using Cysharp.Threading.Tasks;
using Data;
using Data.Persistence;
using Domain.Boundaries;
using UnityEngine;

namespace Domain
{
    public class PersistentDataProvider : IPersistentDataProvider
    {
        public async UniTask<CalculatorPersistentData> GetEntries()
        {
            if (!DataHandler.FileExists())
                return new CalculatorPersistentData(new List<CalculatorEntry>());
            var data = await DataHandler.GetAsync<CalculatorPersistentData>();
            if (data == null)
                return new CalculatorPersistentData(new List<CalculatorEntry>());
            return data;
        }

        public async UniTask SaveEntries(CalculatorPersistentData data)
        {
            var collection = new CalculatorPersistentData(data.entries, data.input);
            var success = await DataHandler.SaveAsync(collection);
            if (!success)
                Debug.LogError("Failed to save calculator persistent data");
        }
    }
}