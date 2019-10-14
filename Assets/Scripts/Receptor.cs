using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Receptor : MonoBehaviour, ILaser
{
    bool GettingLaser = false;
    float TimeTowin = 1f;
    float currentTime = 0;

    ParticleSystem p; 

    void Start()
    {
        p = transform.parent.gameObject.GetComponent<ParticleSystem>();
    }

    public void GetLaser(bool laser)
    {
        GettingLaser = laser;
    }

    // Update is called once per frame
    void Update()
    {
        if (GettingLaser)
        {
            if (!p.isPlaying) p.Play();
            currentTime += Time.deltaTime;
            if (currentTime > TimeTowin)
            {
                Debug.Log("wining"); 
                FindObjectOfType<GameManager>()?.Win();
            }
        }
        else
        {
            currentTime = 0f;
            if (p.isPlaying) p.Stop();
        }
    }
}
