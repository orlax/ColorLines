using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controla el touch input. 
/// </summary>
public class InputManager : MonoBehaviour
{

    Deflector selectedDeflector;

    Vector2 TouchPos;

    Vector2 TouchStartPos;
    float startRotation; 

    bool touch;
    bool touching; 

    // Update is called once per frame
    void Update()
    {
        //soporte para touch en movil y mouse en desktop. 
        if (Application.isMobilePlatform)
        {
            touch = (Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Began);
            touching = (Input.touchCount > 0);
            TouchPos = touching ? Input.GetTouch(0).position : Vector2.zero;
        }
        else {
            touch = Input.GetMouseButtonDown(0);
            TouchPos = Input.mousePosition;
            touching = Input.GetMouseButton(0); 
        }

        //revisamos el touch input y seleccionamos al reflector adecuado. 
        if (touch)
        {
            UpdateSelection();
            TouchStartPos = TouchPos; 
            if(selectedDeflector != null)
            {
                startRotation = selectedDeflector.transform.rotation.eulerAngles.z; 
            }
        }
        //si hay un elemento seleccionado y tenemos un evento de touch actualizamos la rotacion. 
        if (touching && selectedDeflector != null) UpdateReflectorRotation(); 
    }

    private void UpdateReflectorRotation()
    {
        Vector3 diff = TouchPos - TouchStartPos;
        selectedDeflector.transform.eulerAngles = new Vector3(0, 0, startRotation + -.14f * diff.x); 
        //selectedDeflector.transform.right = (Vector3)TouchPos - selectedDeflector.transform.position; 
    }

    void UpdateSelection()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(TouchPos);
        RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);
        if (hit != null && hit.collider != null)
        {
            Debug.Log("something hit!");
            if (hit.collider.CompareTag("reflector"))
            {
                if (hit.collider.gameObject.GetComponent<Rotate>() != null) return; //si el reflector tocado esta rotando automaticamente, no se puede seleccionar. 
                if (selectedDeflector != null) selectedDeflector.UnSelect();
                selectedDeflector = hit.collider.GetComponent<Deflector>();
                selectedDeflector.Select();

            }
        }
    }
}
