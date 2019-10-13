using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//este objeto puede recibir el laser y teletransportalo a la salida de fibra asignada. 

[ExecuteInEditMode]
public class Fiber : LaserEmisor, ILaser
{

    [Space(10)]
    [Header("Out")]
    public Fiber OutFiber;

    bool isBeingHit; // esta el laser tocando a este nodo?
    bool isOut; //esta este nodo siendo usado como salida por otro punto de fibra?


    void Start()
    {
        Laser = GetComponent<LineRenderer>();
        Debug.Log("start function on child class is running!"); 
        LaserActive = false;
        Laser.enabled = false; 
    }

    public void GetLaser(bool laser)
    {
        if (!isOut) {
            isBeingHit = laser;
            if (OutFiber) OutFiber.SetOut(laser); 
        }
    }

    public void SetOut(bool newOut)
    {
        isOut = newOut;
        LaserActive = newOut;
        Laser.enabled = newOut; 
    }

    public override Vector2 GetlaserDirection()
    {
        var emisor = GameObject.FindGameObjectWithTag("emisor").GetComponent<LaserEmisor>();
        Vector3 laserDirection = emisor.Positions[emisor.Positions.Count - 1] - emisor.Positions[emisor.Positions.Count - 2];
        return laserDirection.normalized; 
    }

        void OnDrawGizmosSelected()
    {
        if (OutFiber != null)
        {
            Gizmos.color = new Color(1, 1, 0, 0.75F);
            Gizmos.DrawSphere(OutFiber.transform.position, .6f);
        }
    }
}
