using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootController : MonoBehaviour
{

    public float sporeSpeedHigh;
    public float sporeSpeedLow;
    public float sporeAngle;
    public float sporeTorqueAngle;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(Random.Range(-sporeAngle, sporeAngle), Random.Range(sporeSpeedLow, sporeSpeedHigh)), ForceMode2D.Impulse);
        rb.AddTorque((Random.Range(-sporeTorqueAngle, sporeTorqueAngle)));
    }

    // Update is called once per frame
    void Update()
    {

    }
}