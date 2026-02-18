using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingScript : MonoBehaviour
{
    public GameObject ChebuQPoint;
    public GameObject ChebuAPoint;
    public GameObject ChebuEPoint;
    public GameObject ChebuDPoint;
    public float moveSpeed = 10f;
    private Vector3 targetPosition;
    private bool isMoving = false;
    private KeyCode currentKey = KeyCode.None;

    void Update()
    {
        bool keyPressed = false;
        if (Input.GetKey(KeyCode.Q) && ChebuQPoint != null)
        {
            SetTarget(ChebuQPoint.transform.position);
            currentKey = KeyCode.Q;
            keyPressed = true;
        }
        else if (Input.GetKey(KeyCode.A) && ChebuAPoint != null)
        {
            SetTarget(ChebuAPoint.transform.position);
            currentKey = KeyCode.A;
            keyPressed = true;
        }
        else if (Input.GetKey(KeyCode.E) && ChebuEPoint != null)
        {
            SetTarget(ChebuEPoint.transform.position);
            currentKey = KeyCode.E;
            keyPressed = true;
        }
        else if (Input.GetKey(KeyCode.D) && ChebuDPoint != null)
        {
            SetTarget(ChebuDPoint.transform.position);
            currentKey = KeyCode.D;
            keyPressed = true;
        }
        else
        { 
            isMoving = false;
            currentKey = KeyCode.None;
        }
        if (isMoving)
        {
            MoveSmoothly();
        }
    }

    void SetTarget(Vector3 newPos)
    {
        targetPosition = newPos;
        isMoving = true;
    }

    void MoveSmoothly()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        if (Vector3.Distance(transform.position, targetPosition) < 0.05f)
        {
            transform.position = targetPosition;
            isMoving = false;
        }
    }
}