using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public float Energy = 100;
    public float EnergyUseRate = 1;
    public float Overload = 0;
    public float OverloadRate = 10;

    private bool isOverloading = false;
    private bool GameOver = false;

    UIManager UI; 

    // Start is called before the first frame update
    void Start()
    {
        UI = FindObjectOfType<UIManager>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (GameOver) return; 

        Energy = Energy - EnergyUseRate * Time.deltaTime; //cada segundo que pasa perdemos energia. 
        if (Energy <= 0 && !GameOver)
        {
            GameOverScreen(); 
        }

        //Actualizar la UI si hay alguna. 
        if (UI != null)
        {
            UI.Energy = Energy;
            UI.Overload = Overload; 
        }
    }

    internal void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }

    internal void GoToHomeScreen()
    {
        throw new NotImplementedException();
    }

    private void GameOverScreen()
    {
        GameOver = true; 
        UI?.GameOverScreen(); 
    }
}
