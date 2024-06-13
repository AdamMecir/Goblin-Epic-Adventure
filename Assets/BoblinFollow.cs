using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoblinFollow : MonoBehaviour
{
    public bool KitchenSpawned = false;
    public bool SlimeSpawned = false;
    public bool GolemSpawned = false;
    public bool UsSpawned = false;
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
       Player = GameObject.FindGameObjectWithTag("Player"); 
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
     }

    // Update is called once per frame
    private void Update()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        if (PlayerPrefs.GetString("SAVE") == "Kitchen")
        {
            KitchenSpawned = true;


        }
        else if (PlayerPrefs.GetString("SAVE") == "Slime")
        {
            KitchenSpawned = false;
            SlimeSpawned = true;


        }
        else if (PlayerPrefs.GetString("SAVE") == "Golem")
        {
          
            SlimeSpawned = false;
            GolemSpawned = true;



        }
        else if (PlayerPrefs.GetString("SAVE") == "UsBosses")
        {

           
            GolemSpawned = false;
            UsSpawned = true;



        }

        Vector2 targetvector = (Player.transform.position - transform.position).normalized;
        
        if(Vector2.Distance(transform.position, target.position) > stoppingDistance)
        {
            
            transform.position = Vector2.MoveTowards(transform.position,target.position,speed * Time.deltaTime);
          animator.SetBool("IsMoving", true);   
          animator.SetFloat("X",targetvector.x);
        animator.SetFloat("Y",targetvector.y);
           

        }
        else
        animator.SetBool("IsMoving", false);
        }

        
        

    
}
