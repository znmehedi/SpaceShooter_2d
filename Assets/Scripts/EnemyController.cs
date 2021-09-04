using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour

{
    [SerializeField]
    private bool canRotate;
    private float yBound = -5.81f;
    private Vector2 moveEnemy;
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float rotateSpeed=25f;


    //Bullet Part
    [SerializeField]
    private GameObject[] enemyBullets;
    [SerializeField]
    private Transform[] BulletRelasePoint;
    private bool canShoot;
    private float currentAttackTimer;
    [SerializeField]
    private float AttackTimer = 5f;
    
    private Animator anim;
    private AudioSource aux;
    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
        aux = GetComponent<AudioSource>();
    }

    void Start()
    {
        if (canRotate)
        {
            if(Random.Range(0, 2) > 0)
            {
                rotateSpeed = Random.Range(rotateSpeed, rotateSpeed + 20f);
                rotateSpeed *= -1f;
            }
        }

        //for Bullet speed;
        currentAttackTimer = AttackTimer;
    }

    // Update is called once per frame
    void Update()
    {
            Move();

            if(canRotate){
            AstroidRotate();
            }

            instaBullet();
    }
    private void Move()
    {
        moveEnemy = transform.position;
        moveEnemy.y -= moveSpeed * Time.deltaTime;
        transform.position = moveEnemy;

        if (moveEnemy.y < yBound)
        {
            Destroy(gameObject);
        }
    }
    private void AstroidRotate()
    {
        transform.Rotate(new Vector3(0f, 0f, rotateSpeed * Time.deltaTime), Space.World);
    }
    void instaBullet()
    {
        AttackTimer += Time.deltaTime;

        if (AttackTimer > currentAttackTimer)
        {
            canShoot = true;
            AttackTimer = 0f;
        }
        
        if (canShoot)
        {
            Instantiate(enemyBullets[0], BulletRelasePoint[0].position, enemyBullets[0].transform.rotation);
            Instantiate(enemyBullets[1], BulletRelasePoint[1].position, enemyBullets[1].transform.rotation);
            canShoot = false;
        }
    }//Bullet inastance

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("PlayerBullet"))
        {
            else if (gameObject.CompareTag("Enemy"))
            {
                anim.Play("Destroy");
                Destroy(gameObject, 0.1f);
            }
            else if (gameObject.CompareTag("Asteroid1"))
            {
                anim.Play("DestroyAsteriod1");
                Destroy(gameObject, 0.1f);
            }
            else if (gameObject.CompareTag("Asteroid2"))
            {
                anim.Play("DestroyAsteriod2");
                Destroy(gameObject, 0.1f);
            }
        }
    }

}
