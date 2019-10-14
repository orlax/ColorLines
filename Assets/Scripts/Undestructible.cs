using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Undestructible : MonoBehaviour, ILaser
{
    Animator animator;
    public bool isBeingHit = false;
    public bool animated = true;
    public ParticleSystem p; 

    public void Start()
    {
        p = GetComponent<ParticleSystem>();
        if (animated)
        {
            animator = GetComponent<Animator>();
        }
    }

    public void GetLaser(bool laser)
    {
        isBeingHit = laser;
        animator?.SetBool("isBeingHit", isBeingHit);
       
    }

    void Update()
    {
        if (isBeingHit && !p.isPlaying)
        {
            Debug.Log("play particles");
            p.Play();
        }
        else if (!isBeingHit && p.isPlaying)
        {
            p.Stop();
            Debug.Log("stop particles");
        }
    }
}
