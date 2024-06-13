using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOBLINFOLLOWLIZATKO : MonoBehaviour
{

    public float speed;
    public float stoppingDistance;

    private Transform target;

    private GameObject Player;


    Animator animator;


    // Start is called before the first frame update




    void Start()
    {

        animator = gameObject.GetComponent<Animator>();


    }
    private void FixedUpdate()
    {
        Player = GameObject.FindGameObjectWithTag("lizatko");
        target = GameObject.FindGameObjectWithTag("lizatko").GetComponent<Transform>();
    }

    // Update is called once per frame
    private void Update()
    {
    

        Vector2 targetvector = (Player.transform.position - transform.position).normalized;

        if (Vector2.Distance(transform.position, target.position) > stoppingDistance)
        {

            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            animator.SetBool("IsMoving", true);
            animator.SetFloat("X", targetvector.x);
            animator.SetFloat("Y", targetvector.y);


        }
        else
            animator.SetBool("IsMoving", false);
    }

}
