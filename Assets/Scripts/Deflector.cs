using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deflector : MonoBehaviour
{
    public SpriteRenderer selector; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Select()
    {
        selector.enabled = true; 
    }

    public void UnSelect()
    {
        selector.enabled = false;
    }
}
