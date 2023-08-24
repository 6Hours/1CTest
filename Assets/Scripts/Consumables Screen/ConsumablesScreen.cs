using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Consumables
{
    public class ConsumablesScreen : MonoBehaviour
    {
        [SerializeField] private Button closeBtn;
        [SerializeField] private ConsumableVisualizator medpackVisualizator;
        [SerializeField] private ConsumableVisualizator armorVisualizator;

        public static ConsumablesScreen Create(Transform _parent)
        {
            var content = Instantiate(
                Resources.Load<GameObject>("Screens/ConsumablesScreen"), _parent).GetComponent<ConsumablesScreen>();

            content.Initialize();
            return content;
        }

        public void Initialize()
        {
            closeBtn.onClick.AddListener(Close);

            medpackVisualizator.Initialize(
                GameModel.ConsumableTypes.Medpack, 
                GameModel.ConsumablesPrice[GameModel.ConsumableTypes.Medpack].CoinPrice, 
                BuyMedpack);

            armorVisualizator.Initialize(
                GameModel.ConsumableTypes.ArmorPlate, 
                GameModel.ConsumablesPrice[GameModel.ConsumableTypes.ArmorPlate].CreditPrice, 
                BuyArmor);

            GameModel.OperationComplete += OnOperationComplete;

            UpdateView();
        }

        private void OnOperationComplete(GameModel.OperationResult _result)
        {
            if (_result.IsSuccess)
            {
                UpdateView();
            }
        }

        private void UpdateView()
        {
            medpackVisualizator.UpdateView();
            armorVisualizator.UpdateView();
        }

        private void BuyMedpack()
        {
            GameModel.BuyConsumableForGold(GameModel.ConsumableTypes.Medpack);
        }

        private void BuyArmor()
        {
            GameModel.BuyConsumableForSilver(GameModel.ConsumableTypes.ArmorPlate);
        }

        private void Close()
        {
            Dispose();
            Destroy(gameObject);
        }

        private void Dispose()
        {
            GameModel.OperationComplete -= OnOperationComplete;
        }
    }
}