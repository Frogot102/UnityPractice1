using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MandarineSpawns : MonoBehaviour
{
    [SerializeField] GameObject pointPrefab;       
    [SerializeField] Transform[] spawnPoints;       
    [SerializeField] float interval = 5f;        
    [SerializeField] GenaMoveScript genaAI;                 

    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= interval)
        {
            SpawnMandarine();
            timer = 0f;
        }
    }

    void SpawnMandarine()
    {
        if (spawnPoints == null || spawnPoints.Length == 0)
        {
            return;
        }

        int randomIndex = Random.Range(0, spawnPoints.Length);
        Vector3 position = spawnPoints[randomIndex].position;

        Instantiate(pointPrefab, position, Quaternion.identity);

        if (genaAI != null)
        {
            genaAI.OnFallingObjectSpawned();
        }
        else
        {
            return;
        }
    }
}