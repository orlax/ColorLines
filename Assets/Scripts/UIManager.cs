using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[ExecuteInEditMode]
public class UIManager : MonoBehaviour
{


    public float Energy = 100;
    public float Overload = 0;

    public Image energyBar;
    public Image overloadBar;

    public GameObject OverloadPauseCanvas;

    private GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>(); 
    }

    // Update is called once per frame
    void Update()
    {
        energyBar.rectTransform.localScale = new Vector3(Energy / 100, 1, 1);
        overloadBar.rectTransform.localScale = new Vector3(Overload / 100, 1, 1);
    }

    internal void GameOverScreen()
    {
        OverloadPauseCanvas.SetActive(true);
    }

    public void RestarButtonClicked()
    {
        gameManager?.RestartLevel();           
    }

    public void HomeButtonClicked()
    {
        gameManager?.GoToHomeScreen();
    }
}
