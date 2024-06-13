using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabySlimeMovement : MonoBehaviour
{
    public float speed;


    private Transform target;

    private GameObject Player;
    public int maxHealth;
    public int currentHealth;
    public DamageController Damagesystem;
    public HealthBar healthBar;
 
    Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        Damagesystem = GameObject.FindGameObjectWithTag("GameManager").GetComponent<DamageController>();

        animator = gameObject.GetComponent<Animator>();

        maxHealth = Damagesystem.MinionMaxHealth;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        
        speed = Random.Range(100, 150);
    }
    private void FixedUpdate()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Sip"))
            TakeDamage(Damagesystem.SipDamage);
      


    }
    public void OnTriggerStay2D(Collider2D collision)
    {
       if (collision.CompareTag("Ploska"))
            TakeDamage(Damagesystem.PloskaDamage);
    }
    
    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
       
            if (currentHealth <= 0)
        {
            
            Destroy(gameObject);
          

        }
                
      
    }
}
