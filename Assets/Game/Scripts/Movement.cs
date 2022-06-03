using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Vector3 startPosition;

    [SerializeField]
    private float frequency = 5f;

    [SerializeField]
    private float magnitude = 5f;

    [SerializeField]
    private float offset = 0f;
    // Start is called before the first frame update


    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = startPosition + transform.up * Mathf.Sin(Time.time * frequency + offset) * magnitude;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.transform.SetParent(transform);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.transform.SetParent(null);
    }

}
