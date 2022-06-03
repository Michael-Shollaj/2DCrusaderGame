using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    GameObject objectToSpawn;

    float delayBeforeSpawn = 0;
    float cycleTime = 3.5f;
    float forceX = 0;
    float forceY = 0;
    float torque;
    float destroyAfter = 3.5f;
    private GameObject spawnedGameObject;

    void DoSpawn()
    {
        Rigidbody2D rb2d = null;
        spawnedGameObject = (GameObject)Instantiate(objectToSpawn);
        rb2d = spawnedGameObject.GetComponent<Rigidbody2D>();
        spawnedGameObject.transform.position = transform.position + Vector3.up * 0.1f;
        rb2d.AddForce(new Vector2(forceX, forceY));
        rb2d.AddTorque(torque);
    }

}
