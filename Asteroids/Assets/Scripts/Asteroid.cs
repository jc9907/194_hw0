using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float maxSpeed = 5f;
    [SerializeField] private float maxX = 7.7f;
    [SerializeField] private float maxY = 6f;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        transform.position = new Vector3(Random.Range(-maxX, maxX), Random.Range(-maxY, maxY), 0);

        rb.velocity = Quaternion.Euler(0, 0, Random.Range(0, 360)) * new Vector3(Random.Range(0.5f, maxSpeed), 0.0f, 0.0f);
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }

        if (transform.position.x < -maxX)
        {
            transform.position = new Vector2(maxX, transform.position.y);
        }
        else if (transform.position.x > maxX)
        {
            transform.position = new Vector2(-maxX, transform.position.y);
        }

        if (transform.position.y < -maxY)
        {
            transform.position = new Vector2(transform.position.x, maxY);
        }
        else if (transform.position.y > maxY)
        {
            transform.position = new Vector2(transform.position.x, -maxY);
        }
    }
}
