using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ExchangeScreen : MonoBehaviour
    {
        [SerializeField] private TMP_Text convertRateLable;

        [SerializeField] private TMP_Text coinsCountLable;
        [SerializeField] private TMP_Text creditsCountLable;
        [SerializeField] private TMP_InputField convertInput;
        [SerializeField] private TMP_Text convertResultLable;

        [SerializeField] private Button exchangeBtn;
        [SerializeField] private Button closeBtn;

        public static ExchangeScreen Create(Transform _parent)
        {
            var content = Instantiate(
                Resources.Load<GameObject>("Screens/ExchangeScreen"), _parent).GetComponent<ExchangeScreen>();

            content.Initialize();
            return content;
        }

        public void Initialize()
        {
            convertInput.onValueChanged.AddListener(OnConvertValueEdit);
            exchangeBtn.onClick.AddListener(ExchangeCoinToCredit);
            closeBtn.onClick.AddListener(Close);

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
            convertRateLable.text = GameModel.CoinToCreditRate.ToString();
            coinsCountLable.text = GameModel.CoinCount.ToString();
            creditsCountLable.text= GameModel.CreditCount.ToString();

            OnConvertValueEdit("update");
        }

        private void OnConvertValueEdit(string _input)
        {
            if(int.TryParse(_input, out int result))
            {
                convertInput.SetTextWithoutNotify(Mathf.Clamp(result, 0, GameModel.CoinCount).ToString());
            }
            else
            {
                convertInput.SetTextWithoutNotify("0");
            }

            convertResultLable.text = (result * GameModel.CoinToCreditRate).ToString();
        }

        private void ExchangeCoinToCredit()
        {
            GameModel.ConvertCoinToCredit(int.Parse(convertInput.text));
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