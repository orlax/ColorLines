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

    [Header("Proximo Nivel")]
    public string NextLevel = "sandbox"; 

    private bool GameOver = false;
    private int overloadLevel = 0;

    Undestructible[] undestructibles;
    LaserEmisor[] emisors; 

    UIManager UI;

    /// <summary>
    /// Revisa el estado de todos los destructibles y  segun este aumenta o disminuye el nivel de overload 
    /// </summary>
    /// <param name="laser"></param>
    internal void updateOverloadLevel()
    {
        overloadLevel = 0; 
        foreach(Undestructible d in undestructibles)
        {
            if (d.isBeingHit) overloadLevel += 1;
        }
        foreach(LaserEmisor l in emisors)
        {
            if (l.Overloading) Overload += 1; 
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        UI = FindObjectOfType<UIManager>();
        undestructibles = FindObjectsOfType<Undestructible>();
        emisors = FindObjectsOfType<LaserEmisor>(); 
    }

    internal void Win()
    {
        var destructibles = FindObjectsOfType<Destructible>();
        bool canWin = true; 
        foreach(Destructible d in destructibles)
        {
            if (d.isAlive) {
                canWin = false;
                d.Shake();
            } 
        }
        //si no quedan destructibles en el nivel, hemos ganado. 
        if (canWin)
        {
            UI?.winScreen();
            GameOver = true;
            Invoke("LoadNextLevel", 4f); 
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GameOver) return; 

        Energy = Energy - EnergyUseRate * Time.deltaTime; //cada segundo que pasa perdemos energia. 
        if (Energy <= 0 && !GameOver)
        {
            GameOverScreen(1); 
        }

        updateOverloadLevel();
        //si el nivel de overload supera 1 
        if (overloadLevel > 0)
        {
            Overload += OverloadRate*Time.deltaTime;
        }
        else if(Overload>0)
        {
            Overload -= OverloadRate * Time.deltaTime * 1.3f;
            Overload = Mathf.Clamp(Overload, 0, 10000); 
        }

        if (Overload > 100)
        {
            OverloadScreen();
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

    public void GoToHomeScreen()
    {
        SceneManager.LoadScene("MainMenu"); 
    }

    public void OverloadScreen()
    {
        GameOverScreen(2);
    }

    private void GameOverScreen(int type)
    {
        GameOver = true; 
        UI?.GameOverScreen(type); 
    }

    private void LoadNextLevel()
    {
       SceneManager.LoadScene(NextLevel);
    }
}
