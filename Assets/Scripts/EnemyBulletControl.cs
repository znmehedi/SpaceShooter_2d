using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletControl : MonoBehaviour
{
    private Vector2 move;
    [SerializeField]
    private float speed = 2f;
    private float yBound = -5.81f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        MoveBullet();   
    }
    void MoveBullet()
    {
        move = transform.position;
        move.y -= speed * Time.deltaTime;
        transform.position = move;

        if(move.y<yBound)
        {
            Destroy(gameObject);
        }
    }

}
