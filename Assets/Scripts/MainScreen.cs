using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class MainScreen : MonoBehaviour
    {
        [SerializeField] private Button exchangeOpenBtn;
        [SerializeField] private TMP_Text coinsLable;
        [SerializeField] private TMP_Text creditsLable;

        [SerializeField] private ConsumableVisualizator medpackVisualizator;
        [SerializeField] private ConsumableVisualizator armorVisualizator;

        public void Initialize()
        {
            GameModel.ModelChanged += OnModelChange;

            exchangeOpenBtn.onClick.AddListener(ShowCurrencyExchangeScreen);
            medpackVisualizator.Initialize(GameModel.ConsumableTypes.Medpack, ShowConsumablesScreen);
            armorVisualizator.Initialize(GameModel.ConsumableTypes.ArmorPlate, ShowConsumablesScreen);

            UpdateView();
        }

        private void OnModelChange() => UpdateView();

        private void UpdateView()
        {
            coinsLable.text = GameModel.CoinCount.ToString();
            creditsLable.text = GameModel.CreditCount.ToString();

            medpackVisualizator.UpdateView();
            armorVisualizator.UpdateView();
        }

        private void ShowCurrencyExchangeScreen()
        {

        }

        private void ShowConsumablesScreen()
        {

        }
    }
}
