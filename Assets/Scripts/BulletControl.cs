using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{
    [SerializeField]
    private float speed = 2f;
    private float yBound = 5.61f;
    private Vector2 offset;

    // Start is called before the first frame update
    private void Start()
    { 
    }
    // Update is called once per frame
    void Update()
    {
        bulletMove();
    }
    void bulletMove()
    {
        offset = transform.position;
        offset.y += speed * Time.deltaTime;
        transform.position = offset;

        //destroy Bullet
        if (offset.y > yBound)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyBullet"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
