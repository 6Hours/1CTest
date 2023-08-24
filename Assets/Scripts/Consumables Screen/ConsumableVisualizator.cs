using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI.Consumables
{
    public class ConsumableVisualizator : MonoBehaviour
    {
        [SerializeField] private TMP_Text nameLable;
        [SerializeField] private TMP_Text countLable;
        [SerializeField] private TMP_Text descriptionLable;

        [SerializeField] private Button buyBtn;
        [SerializeField] private TMP_Text costLable;
        
        GameModel.ConsumableTypes type;

        public void Initialize(GameModel.ConsumableTypes _type, int _buyCost, UnityAction _buyAction)
        {
            type = _type;
            buyBtn.onClick.AddListener(_buyAction);
            costLable.text = _buyCost.ToString();
            //Also set text for title and description
        }

        public void UpdateView()
        {
            countLable.text = GameModel.GetConsumableCount(type).ToString();
        }
    }
}
