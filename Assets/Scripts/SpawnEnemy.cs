using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SpawnEnemy : MonoBehaviour
{
    private float leftY = -2.12f;
    private float rightY = 2.12f;

    [SerializeField]
    private GameObject[] asteroids;
    [SerializeField]
    private GameObject enemyShip;

    private float xPosition;
    private Vector3 vec;
    // Start is called before the first frame update
    void Start()
    {

        Invoke("ReleaseEnemy", 2f);
    }

    // Update is called once per frame
    void Update()
    {
     
    }
    void ReleaseEnemy()
    {
        xPosition = Random.Range(leftY, rightY);
        vec = transform.position;
        vec.x = xPosition;
        transform.position = vec;

        if(Random.Range(0, 2) > 0)
        {
            Instantiate(asteroids[Random.Range(0, asteroids.Length)], transform.position, Quaternion.identity);
        }
        else
        {
            Instantiate(enemyShip, transform.position, Quaternion.Euler(0f, 0f, 180f));
        }
        Invoke("ReleaseEnemy", 2f);
    }
}
