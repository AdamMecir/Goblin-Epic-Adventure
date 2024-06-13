using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class GolemBossMovement : MonoBehaviour
{
    private float speed = 60f;
    public GameObject SpecialarrowPrefab;
    public GameObject HurtStone;
    public GameObject PushStone;
    public DamageController Damagesystem;
    float velocity = 400f;
    float velocitystone;
    public Transform target;

    public GameObject Player;
  
    public Transform Boss;
    public HealthBar healthBar;
    public Transform MiddleLocation;
    public Transform CornerLocation;
    int MovementControl = 0;
    bool MovementToPlayer = true;
    float randomnumber;
    Animator animator;

    public GameObject SpawnLocation;



 

    // Start is called before the first frame update



    void Start()
    {
        Damagesystem = GameObject.FindGameObjectWithTag("GameManager").GetComponent<DamageController>();


        PlayerPrefs.SetString("Damage", "true");
        healthBar = GameObject.FindGameObjectWithTag("HealthBarBoss").GetComponent<HealthBar>();

        animator = gameObject.GetComponent<Animator>();

    }

    private void FixedUpdate()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        Boss = GameObject.FindGameObjectWithTag("BOSS").GetComponent<Transform>();
    }

    // Update is called once per frame
    private void Update()
    {
        

        if(MovementToPlayer == true)
        {
            speed = Damagesystem.GolemNormalSpeed;
            PlayerPrefs.SetString("Damage", "true");
            Vector2 targetvector = (Player.transform.position - transform.position).normalized;
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }

        randomnumber = Random.Range(0, 2);

        if (healthBar.FindHealth() <= Damagesystem.GolemHealthFor1Rotation && healthBar.FindHealth() >= Damagesystem.GolemHealthFor2Rotation)
        {

            MovementToPlayer = false;
           // PlayerPrefs.SetString("Damage", "false");
            speed = 300f;
        
            if(MovementControl == 0)
            {
            CornerLocation = GameObject.FindGameObjectWithTag("LavyDolny").GetComponent<Transform>();
            Vector2 targetvector = (CornerLocation.transform.position - transform.position).normalized;
            transform.position = Vector2.MoveTowards(transform.position, CornerLocation.position, speed * Time.deltaTime);
                if (transform.position == CornerLocation.transform.position)
                {
                    if (randomnumber >= 1)
                    {
                        velocitystone = 25f;
                        HurtStoneattack();
                    }

                    else
                    {
                        velocitystone = 200f;
                        PushStoneattack();
                    }
                    MovementControl = 1;
                }
                    
            }




            if (MovementControl == 1)
            {
            CornerLocation = GameObject.FindGameObjectWithTag("PravyDolny").GetComponent<Transform>();
            Vector2 targetvector1 = (CornerLocation.transform.position - transform.position).normalized;
            transform.position = Vector2.MoveTowards(transform.position, CornerLocation.position, speed * Time.deltaTime);
                if (transform.position == CornerLocation.transform.position)
                {
                    if (randomnumber >= 1)
                    {
                        velocitystone = 25f;
                        HurtStoneattack();
                    }

                    else
                    {
                        velocitystone = 200f;
                        PushStoneattack();
                    }

                    MovementControl = 2;
                }
                    
            }



            if (MovementControl == 2)
            {
                CornerLocation = GameObject.FindGameObjectWithTag("LavyHorny").GetComponent<Transform>();
                Vector2 targetvector2 = (CornerLocation.transform.position - transform.position).normalized;
                transform.position = Vector2.MoveTowards(transform.position, CornerLocation.position, speed * Time.deltaTime);
                if (transform.position == CornerLocation.transform.position)
                {
                    if (randomnumber >= 1)
                    {
                        velocitystone = 25f;
                        HurtStoneattack();
                    }
                       
                    else
                    {
                        velocitystone = 200f;
                        PushStoneattack();
                    }
                       
                    MovementControl = 3;
                }
                    
            }

            if (MovementControl == 3)
            {
                CornerLocation = GameObject.FindGameObjectWithTag("PravyHorny").GetComponent<Transform>();
                Vector2 targetvector3 = (CornerLocation.transform.position - transform.position).normalized;
                transform.position = Vector2.MoveTowards(transform.position, CornerLocation.position, speed * Time.deltaTime);
                if (transform.position == CornerLocation.transform.position)
                {
                    if (randomnumber >= 1)
                    {
                        velocitystone = Damagesystem.HurtStonevelocity;
                        HurtStoneattack();
                    }

                    else
                    {
                        velocitystone = Damagesystem.PushStoneVelocity;
                        PushStoneattack();
                    }
                    MovementControl = 0;
                }
                    

            }

        }

        if (healthBar.FindHealth() >= Damagesystem.GolemHealthFor3Rotation && healthBar.FindHealth() <= Damagesystem.GolemHealthFor2Rotation-1 && MovementToPlayer == false)
        {
            PlayerPrefs.SetString("Damage", "false");
            MiddleLocation = GameObject.FindGameObjectWithTag("MiddlePoint").GetComponent<Transform>();
            Vector2 targetvector2 = (MiddleLocation.transform.position - transform.position).normalized;
            transform.position = Vector2.MoveTowards(transform.position, MiddleLocation.position, speed * Time.deltaTime);
            if (transform.position == MiddleLocation.transform.position)
            {

                
             for(int i = 0;i <= 15; i++)
                {
                    Specialattack();
                    if (i == 10)
                    {
                        MovementToPlayer = true;
                        speed = 60f;
                    }
                        
                }

                


            }
        }

        if (healthBar.FindHealth() >= 0 && healthBar.FindHealth() <= Damagesystem.GolemHealthFor3Rotation-1 && MovementToPlayer == true)
        {
            Destroy(GameObject.FindGameObjectWithTag("Kamen"));
        }









        }

    void HurtStoneattack()
    {
       
        Vector2 directionToTarget = target.transform.position - transform.position;

     
        float angle = Vector3.Angle(Vector3.right, directionToTarget);

        if (target.transform.position.y < transform.position.y) angle *= -1;

       
        Quaternion bulletRotation = Quaternion.AngleAxis(angle, Vector3.forward);
        
       GameObject StoneInstance = Instantiate(HurtStone, transform.position, bulletRotation);

        StoneInstance.GetComponent<Rigidbody2D>().AddForce(directionToTarget * velocitystone, ForceMode2D.Impulse);
    }

    void PushStoneattack()
    {

        Vector2 directionToTarget = target.transform.position - transform.position;


        float angle = Vector3.Angle(Vector3.right, directionToTarget);

        if (target.transform.position.y < transform.position.y) angle *= -1;


        Quaternion bulletRotation = Quaternion.AngleAxis(angle, Vector3.forward);

        GameObject StoneInstance = Instantiate(PushStone, transform.position, bulletRotation);

        StoneInstance.GetComponent<Rigidbody2D>().AddForce(directionToTarget * velocitystone, ForceMode2D.Impulse);
    }
    void Specialattack()
    {
       
            



            Quaternion Rot = Quaternion.Euler(new Vector3(0f, 0f, 135f));
            GameObject arrowInstance = Instantiate(SpecialarrowPrefab, transform.position, Rot);

            arrowInstance.GetComponent<Rigidbody2D>().AddForce(Rot * Vector2.right * velocity, ForceMode2D.Impulse);




            Rot = Quaternion.Euler(new Vector3(0f, 0f, 45f));
            arrowInstance = Instantiate(SpecialarrowPrefab, transform.position, Rot);

            arrowInstance.GetComponent<Rigidbody2D>().AddForce(Rot * Vector2.right * velocity, ForceMode2D.Impulse);


            Rot = Quaternion.Euler(new Vector3(0f, 0f, 225f));
            arrowInstance = Instantiate(SpecialarrowPrefab, transform.position, Rot);

            arrowInstance.GetComponent<Rigidbody2D>().AddForce(Rot * Vector2.right * velocity, ForceMode2D.Impulse);


            Rot = Quaternion.Euler(new Vector3(0f, 0f, 315f));
            arrowInstance = Instantiate(SpecialarrowPrefab, transform.position, Rot);

            arrowInstance.GetComponent<Rigidbody2D>().AddForce(Rot * Vector2.right * velocity, ForceMode2D.Impulse);


            arrowInstance = Instantiate(SpecialarrowPrefab, transform.position, Quaternion.identity);

            arrowInstance.GetComponent<Rigidbody2D>().AddForce(Vector2.right * velocity, ForceMode2D.Impulse);


            Rot = Quaternion.Euler(new Vector3(0f, 0f, 90f));
            arrowInstance = Instantiate(SpecialarrowPrefab, transform.position, Rot);

            arrowInstance.GetComponent<Rigidbody2D>().AddForce(Vector2.up * velocity, ForceMode2D.Impulse);


            Rot = Quaternion.Euler(new Vector3(0f, 0f, 180f));
            arrowInstance = Instantiate(SpecialarrowPrefab, transform.position, Rot);

            arrowInstance.GetComponent<Rigidbody2D>().AddForce(Vector2.left * velocity, ForceMode2D.Impulse);


            Rot = Quaternion.Euler(new Vector3(0f, 0f, 270f));
            arrowInstance = Instantiate(SpecialarrowPrefab, transform.position, Rot);

            arrowInstance.GetComponent<Rigidbody2D>().AddForce(Vector2.down * velocity, ForceMode2D.Impulse);




        

    }
}
