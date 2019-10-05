using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class LaserEmisor : MonoBehaviour
{
    LineRenderer Laser;
    Vector3[] Positions;
    [SerializeField]
    float maxLaserLength = 20;
    [SerializeField]
    float laserOrigin = 0.3f;
    [SerializeField]
    Vector3 Zoffset = new Vector3(0, 0, -.22f);
    [SerializeField]
    LaserDirection Direction = LaserDirection.UP; 

    private enum LaserDirection
    {
        UP, RIGHT, DOWN, Left
    }

    // Start is called before the first frame update
    void Start()
    {
        Positions = new Vector3[2];
    }

    // Update is called once per frame
    void Update()
    {
        UpdateLineRenderer(); 
    }

    private void UpdateLineRenderer()
    {
        Positions[0] = transform.position + (Vector3.up * laserOrigin) + Zoffset;
        Positions[1] = transform.position + (Vector3.up * maxLaserLength) + Zoffset;
        Laser = GetComponent<LineRenderer>();
        Laser.SetPositions(Positions);
    }
}
