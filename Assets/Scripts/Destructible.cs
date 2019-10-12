using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour, ILaser
{

    [SerializeField]
    float TimeToDie = 3f;
    float TimeRemaining;
    
    Animator animator;
    
    public bool isBeingHit = false;
    public bool isAlive = true; 


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

    /// <summary>
    /// Shake de advertencia, se dispara cuando el jugador hace contacto pero este destructible aun esta con vida. 
    /// solo deberia ejecutarse si la animacion de shake no se esta reproduciendo. 
    /// </summary>
    public void Shake()
    {
        if (!animator.GetBool("isBeingHit"))
        {
            animator.SetBool("isBeingHit", true);
            Invoke("StopShake", 3f); 
        }
    }

    private void StopShake()
    {
        animator.SetBool("isBeingHit", false); 
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
