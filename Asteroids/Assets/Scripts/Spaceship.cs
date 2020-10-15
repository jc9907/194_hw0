using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Experimental.AI;

public class Spaceship : MonoBehaviour
{
    public GameObject bulletPrefab;
    private float turnSpeed = 200;

    [SerializeField] private float thrust = 0.000015f;
    private float maxX = 6.7f;
    private float maxY = 5f;
    private float maxSpeed = 5f;
    private Vector3 shipDir = new Vector3(0, 1, 0);

    private Rigidbody2D rb;

    // Start is called before the first frame update

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float turnAngle;
        if (Input.GetKey("j"))//left
        {
            turnAngle = turnSpeed * Time.deltaTime;
            transform.Rotate(0, 0, turnAngle);
            shipDir = Quaternion.Euler(0, 0, turnAngle) * shipDir;
        }
        if (Input.GetKey("l"))//right
        {
            turnAngle =- turnSpeed * Time.deltaTime;
            transform.Rotate(0, 0, turnAngle);
            shipDir = Quaternion.Euler(0, 0, turnAngle) * shipDir;
        }
        if (Input.GetKey("k"))//thrust
        {
            rb.AddForce(shipDir * thrust);
        }
        if (Input.GetKeyDown("space"))
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.transform.position = transform.position;
        }
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
        if(transform.position.x < -maxX)
        {
            transform.position = new Vector2(maxX, transform.position.y);
        }
        else if (transform.position.x > maxX)
        {
            transform.position = new Vector2(-maxX, transform.position.y);
        }

        if (transform.position.y < -maxY)
        {
            transform.position = new Vector2( transform.position.x, maxY);
        }
        else if (transform.position.y > maxY)
        {
            transform.position = new Vector2(transform.position.x, -maxY);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if( collision.gameObject.tag == "Asteroid")
        {
            Destroy(gameObject);
        }
    }
}
