using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class LaserEmisor : MonoBehaviour
{
    LineRenderer Laser;
    List<Vector3> Positions;
    [SerializeField]
    float maxLaserLength = 20;
    [SerializeField]
    float laserOrigin = 0.3f;
    [SerializeField]
    Vector3 Zoffset = new Vector3(0, 0, -.22f);
    [SerializeField]
    LaserDirection Direction = LaserDirection.UP;

    List<Collider2D> HitColliders; 

    private enum LaserDirection
    {
        UP, RIGHT, DOWN, LEFT
    }

    // Start is called before the first frame update
    void Start()
    {
        Laser = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        CastLaserRay(); 
        UpdateLineRenderer(); 
        UpdateRotation(); 
    }

    /// <summary>
    /// Realiza los Raycasts adecuados,  actualiza el array de puntos para dibujar el laser 
    /// y llama a las funciones adecuadas dependiendo de los objetos golpeados. 
    /// </summary>
    private void CastLaserRay()
    {
        //reiniciamos las pocisiones 
        HitColliders = new List<Collider2D>();
        Positions = new List<Vector3>();
        //el primer cast se hace en la direccion del emisor. 
        Positions.Add(transform.position + (Vector3)(GetlaserDirection() * laserOrigin) + Zoffset); //Posicion original del laser. 
        RaycastHit2D hit = Physics2D.Raycast(Positions[0], GetlaserDirection(), maxLaserLength); 
        //si golpeamos algo el segundo punto es igual al lugar del hit. 
        if(hit.collider != null)
        {
            HitColliders.Add(hit.collider); 
            Positions.Add(hit.collider.transform.position + Zoffset);
            //golpeamos un reflector?
            if (hit.collider.gameObject.CompareTag("reflector"))
            {
                BounceLaser(hit.collider.gameObject.transform); 
            }
        }
        //si no hubo golpes el laser sigue de largo. 
        else
        {
            Positions.Add(transform.position + (Vector3)(GetlaserDirection() * maxLaserLength) + Zoffset);
        }
    }
    /// <summary>
    /// Recibe el transform de un reflector, realiza un nuevo raycast 
    /// y agrega los puntos necesarios al array de positions del line renderer. 
    /// </summary>
    /// <param name="reflector"></param>
    private void BounceLaser(Transform reflector)
    {
        RaycastHit2D hit = Physics2D.Raycast(reflector.position + reflector.up * 2, reflector.up, maxLaserLength);
        if (hit.collider != null && !HitColliders.Contains(hit.collider))
        {
            HitColliders.Add(hit.collider); 
            Positions.Add(hit.collider.transform.position + Zoffset);
            //golpeamos un reflector?
            if (hit.collider.gameObject.CompareTag("reflector"))
            {
                BounceLaser(hit.collider.gameObject.transform);
            }
        }
        else
        {
            Positions.Add(reflector.position + (reflector.up * maxLaserLength)); 
        }
    }

    private Vector2 GetlaserDirection()
    {
        switch (Direction)
        {
            case LaserDirection.UP:
                return Vector2.up; 
            case LaserDirection.RIGHT:
                return Vector2.right;
            case LaserDirection.DOWN:
                return Vector2.down; 
            case LaserDirection.LEFT:
                return Vector2.left;
        }
        return Vector2.up; 
    }

    private void UpdateRotation()
    {
        switch (Direction)
        {
            case LaserDirection.UP:
                transform.eulerAngles = new Vector3(0, 0, 0);
                break;
            case LaserDirection.RIGHT:
                transform.eulerAngles = new Vector3(0, 0, -90);
                break;
            case LaserDirection.DOWN:
                transform.eulerAngles = new Vector3(0, 0, -180); 
                break;
            case LaserDirection.LEFT:
                transform.eulerAngles = new Vector3(0, 0, 90);
                break; 
        }
    }

    private void UpdateLineRenderer()
    {
        Laser.positionCount = Positions.Count; 
        Laser.SetPositions(Positions.ToArray());
    }
}
