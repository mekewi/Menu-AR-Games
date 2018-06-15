using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;


public class MoveCar : MonoBehaviour
{
    public float smoothing;

    private Vector2 origin;
    private Vector2 direction;
    private Vector2 smoothDirection;
    private bool touched;
    private int pointerID;

    void Awake()
    {
        direction = Vector2.zero;
        touched = false;
    }

    public void OnPointerDown(Vector2 data)
    {
             origin = data;
     }

    public void OnDrag(Vector2 data)
    {
         Vector2 currentPosition = data;
        Vector2 directionRaw = currentPosition - origin;
        direction = directionRaw.normalized;
 
    }

    public void OnPointerUp()
    {
        direction = Vector3.zero;
     }

    public Vector2 GetDirection()
    {

        smoothDirection = Vector2.MoveTowards(smoothDirection, direction, smoothing);
 
        return smoothDirection;
    }
    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            touched = true;
            OnPointerDown(Input.GetTouch(0).position);
        }
        if (touched)
        {
            Debug.Log("touched " + Input.GetTouch(0).position);

            OnDrag(Input.GetTouch(0).position);
        }
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            touched = false;
            OnPointerUp();
        }

    }

}
