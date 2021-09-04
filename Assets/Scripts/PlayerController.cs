using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private GameObject playerBullet;
    [SerializeField]
    private Transform attackPoint;
    [SerializeField]
    private bool AutoShoot;
    private bool canShoot;

    private float current_attack_timer;
    public float attack_timer = 0.3f;


    private Animator anim;

    public float playerSpeed = 0.5f;
    private Vector2 PositionOffset;
    private float maxX=2.28f, maxY=3.39f, minX=-2.28f, minY=-4.09f;
    // Start is called before the first frame update
    void Start()
    {
        current_attack_timer = attack_timer;
        anim = GetComponent<Animator>();
    }//start 

    // Update is called once per frame
    void Update()
    {
        changePosition();
        FireBullet();
    }//update
    void changePosition()
    {
        PositionOffset = transform.position;
        if (Input.GetAxis("Horizontal")<0f) //left
        {
            PositionOffset.x += -playerSpeed * Time.deltaTime;
        }
        else if (Input.GetAxis("Horizontal") > 0f) //right
        {
            PositionOffset.x += playerSpeed * Time.deltaTime;
        }
        if (PositionOffset.x < minX)
        {
            PositionOffset.x = minX;
        }
        else if(PositionOffset.x > maxX)
        {
            PositionOffset.x = maxX;
        }
        if (Input.GetAxis("Vertical") > 0f) //up
        {
            PositionOffset.y += playerSpeed * Time.deltaTime;
        }
        else if (Input.GetAxis("Vertical") < 0f) //down
        {
            PositionOffset.y += -playerSpeed * Time.deltaTime;
        }
        if (PositionOffset.y > maxY)
        {
            PositionOffset.y = maxY;
        }
        if (PositionOffset.y < minY)
        {
            PositionOffset.y = minY;
        }
        transform.position = PositionOffset;
    }//change position
    void FireBullet()
    {
        if (AutoShoot){
            instBullet();
        }
        else if(Input.GetKeyDown(KeyCode.F)){
            instBullet();
        }
    }//firebullet
    private void instBullet()
    {
        attack_timer += Time.deltaTime;
        if (attack_timer > current_attack_timer)
        {
            canShoot = true;
            attack_timer = 0f;
        }
        if (canShoot)
        {
            Instantiate(playerBullet, attackPoint.position, playerBullet.transform.rotation);
            canShoot = false;
        }
    }//bullet instance

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Asteroid2") || collision.CompareTag("EnemyBullet") || collision.CompareTag("Enemy")||collision.CompareTag("Asteroid2"))
        {
            anim.Play("DestroyPlayer");
            Destroy(gameObject, 0.1f);
        }
    }
}
