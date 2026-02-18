using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenaMoveScript : MonoBehaviour
{
    public GameObject ChebuQPoint;
    public GameObject ChebuAPoint;
    public GameObject ChebuEPoint;
    public GameObject ChebuDPoint;
    public float moveSpeed = 5f;
    public float reactionChance = 0.75f;
    public Transform cheburaTransform;
    private Vector3 currentTargetPosition;
    private bool isMoving = false;
    private List<GameObject> allPoints;

    void Start()
    {
        allPoints = new List<GameObject>();
        if (ChebuQPoint != null) allPoints.Add(ChebuQPoint);
        if (ChebuAPoint != null) allPoints.Add(ChebuAPoint);
        if (ChebuEPoint != null) allPoints.Add(ChebuEPoint);
        if (ChebuDPoint != null) allPoints.Add(ChebuDPoint);

    }

    void Update()
    {
        if (isMoving)
        {
            MoveToTarget();
        }
    }
    public void OnFallingObjectSpawned()
    {
        if (Random.value <= reactionChance)
        {
            ChooseNewTarget();
        }
        else
        {
            Debug.Log("Гена проигнорировал мандарин");
        }
    }
    void ChooseNewTarget()
    {
        if (allPoints.Count == 0 || cheburaTransform == null) return;

        List<GameObject> freePoints = new List<GameObject>();

        foreach (var point in allPoints)
        {
            if (point == null) continue;

            float distance = Vector3.Distance(cheburaTransform.position, point.transform.position);

            if (distance > 0.2f)
            {
                freePoints.Add(point);
            }
        }


        int randomIndex = Random.Range(0, freePoints.Count);
        GameObject targetPoint = freePoints[randomIndex];

        currentTargetPosition = targetPoint.transform.position;
        isMoving = true;

        Debug.Log($"Гена идет к точке: {targetPoint.name}");
    }

    void MoveToTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, currentTargetPosition, moveSpeed * Time.deltaTime);
        if (Vector3.Distance(transform.position, currentTargetPosition) < 0.05f)
        {
            isMoving = false;
            Debug.Log("Гена достиг цели.");
        }
    }
}
