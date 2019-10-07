using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour, ILaser
{

    [SerializeField]
    float TimeToDie = 3f;
    float TimeRemaining;
    
    Animator animator;
    
    bool isBeingHit = false;
    bool isAlive = true; 


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        TimeRemaining = TimeToDie; 
    }

    public void GetLaser(bool laser)
    {
        isBeingHit = laser;
        animator.SetBool("isBeingHit", isBeingHit);
    }

    // Update is called once per frame
    void Update()
    {
        if ( isAlive && isBeingHit)
        {
            Debug.Log(TimeRemaining); 
            TimeRemaining -= Time.deltaTime;
            if (TimeRemaining < 0)
            {
                isAlive = false;
                animator.SetBool("isAlive", isAlive);
                gameObject.GetComponent<Collider2D>().enabled = false; 
            }
        }
    }
}
