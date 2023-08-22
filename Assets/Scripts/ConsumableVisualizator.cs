using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ConsumableVisualizator : MonoBehaviour
    {
        [SerializeField] private Button showMoreBtn;
        [SerializeField] private TMP_Text countLable;

        GameModel.ConsumableTypes type;

        public void Initialize(GameModel.ConsumableTypes _type, Action _showMoreAction)
        {
            type = _type;
            showMoreBtn.onClick.AddListener(() => _showMoreAction?.Invoke());
        }

        public void UpdateView()
        {
            countLable.text = GameModel.GetConsumableCount(type).ToString();
        }
    }
}
