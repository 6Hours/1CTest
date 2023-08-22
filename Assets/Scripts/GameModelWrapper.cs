using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;

public class GameModelWrapper : MonoBehaviour
{
    [SerializeField] private MainScreen mainScreen;

    // Start is called before the first frame update
    void Start()
    {
        mainScreen.Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        GameModel.Update();
    }
}
