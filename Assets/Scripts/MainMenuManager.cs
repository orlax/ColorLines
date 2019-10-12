﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public string FirstLevel;

    public void LoadFirstLevel()
    {
        SceneManager.LoadScene(FirstLevel);
    }
}
