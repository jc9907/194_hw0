using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GameController : MonoBehaviour
{ public GameObject asteroidPrefab;
    public GameObject shipPrefab;
    private int numAsteroids = 5;
    [SerializeField] private float minColRad = 2.0f;

    private void Awake()
    {
        InitializeLevel();
    }
    private void InitializeLevel()
    {
        for (int i = 0;  i < numAsteroids; i++)
        {
            spawnAsteroid();
        }
        spawnSpaceship();
    }

    private void spawnAsteroid()
    {   bool valid;
        GameObject newAsteroid;
        do
        {
            newAsteroid = Instantiate(asteroidPrefab);
            newAsteroid.gameObject.tag = "Asteroid";
            valid = checkAs(newAsteroid);
        } while (valid == false);
        
        
    }
    private void spawnSpaceship()
    {
        bool valid;
        GameObject newShip;
        do
        {
            newShip = Instantiate(shipPrefab);
            newShip.gameObject.tag = "ship";
            valid = checkAs(newShip);
        } while (valid == false);

        return;
    }
    private bool checkAs(GameObject testOb)
    {
        GameObject[] asteroids = GameObject.FindGameObjectsWithTag("Asteroid");
        foreach(GameObject asteroid in asteroids)
        {
            if(asteroid != testOb)
            {
                if(Vector3.Distance(testOb.transform.position, asteroid.transform.position) <minColRad)
                {
                    Destroy(testOb);
                    return false;
                }
            }
        }
        return true;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
