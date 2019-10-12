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
    public GameObject contactCanvas;
    [SerializeField]
    public Text gameOverDescription; 

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

    /// <summary>
    /// Presents the game over screen with the correspondent text: 
    /// 1 - time up 
    /// 2 - overload. 
    /// </summary>
    /// <param name="type"></param>
    internal void GameOverScreen(int type)
    {
        gameOverDescription.text = type == 1 ? "¡SIN ENERGIA!" : "¡SOBRECARGA!";
        OverloadPauseCanvas.SetActive(true);
    }

    internal void winScreen()
    {
        contactCanvas.SetActive(true); 
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
