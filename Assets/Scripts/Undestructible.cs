using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Undestructible : MonoBehaviour, ILaser
{

    [SerializeField]
    float DamagePerSecond = 3f;


    Animator animator;
    bool isBeingHit = false;

    public void GetLaser(bool laser)
    {
        isBeingHit = laser;
        animator.SetBool("isBeingHit", isBeingHit);
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isBeingHit)
        {

        }
    }
}
