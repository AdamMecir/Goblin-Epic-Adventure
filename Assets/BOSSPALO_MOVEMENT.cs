using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOSSPALO_MOVEMENT : MonoBehaviour
{
    private float speed = 60f;

    public GameObject HurtStone;

    public DamageController Damagesystem;
    float velocity = 400f;
    float velocitystone;
    public Transform target;

    public GameObject Player;

    public Transform Boss;
    public Transform MiddleLocation;
    public Transform CornerLocation;
    int MovementControl = 0;

    Animator animator;

    public GameObject SpawnLocation;
    // Start is called before the first frame update
    void Start()
    {
        Damagesystem = GameObject.FindGameObjectWithTag("GameManager").GetComponent<DamageController>();

        PlayerPrefs.SetString("Damage", "true");

        animator = gameObject.GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        Boss = GameObject.FindGameObjectWithTag("BOSS").GetComponent<Transform>();
    }
    // Update is called once per frame
    void Update()
    {
        speed = 200f;

        if (MovementControl == 0)
        {
            CornerLocation = GameObject.FindGameObjectWithTag("LavyDolny").GetComponent<Transform>();
            Vector2 targetvector = (CornerLocation.transform.position - transform.position).normalized;
            transform.position = Vector2.MoveTowards(transform.position, CornerLocation.position, speed * Time.deltaTime);
            if (transform.position == CornerLocation.transform.position)
            {

                velocitystone = 25f;
                HurtStoneattack();

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

                velocitystone = 25f;
                HurtStoneattack();




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

                velocitystone = 25f;
                HurtStoneattack();




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

                velocitystone = Damagesystem.HurtStonevelocity;
                HurtStoneattack();

                MovementControl = 0;
            }


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

}
