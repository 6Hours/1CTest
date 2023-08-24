using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI
{
    public class ConsumableVisualizator : MonoBehaviour
    {
        [SerializeField] private Button showMoreBtn;
        [SerializeField] private TMP_Text countLable;

        GameModel.ConsumableTypes type;

        public void Initialize(GameModel.ConsumableTypes _type, UnityAction _showMoreAction)
        {
            type = _type;
            showMoreBtn.onClick.AddListener(_showMoreAction);
        }

        public void UpdateView()
        {
            countLable.text = GameModel.GetConsumableCount(type).ToString();
        }
    }
}
