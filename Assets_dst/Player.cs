using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Reflection;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public DamageController Damagesystem;
    public HealthBar healthBar;
    public int maxHealth;
	public int currentHealth;
    
    
    public List<int> burnticktimers = new List<int>();

    // Start is called before the first frame update
    void Start()
    {
        Damagesystem = GameObject.FindGameObjectWithTag("GameManager").GetComponent<DamageController>();

        healthBar = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<HealthBar>();
        maxHealth = Damagesystem.PlayerMaxHealth;
		currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);
		
    }
    private void Update()
    {
       
        if (healthBar.FindHealth() <= 0)
        {
            Destroy(gameObject);
            healthBar.slider.value = 1;
            SceneManager.LoadScene(7);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        
    }
    
 /*   public void OnTriggerEnter2D(Collider2D collision)
    {
		if (collision.gameObject.tag == "BOSS")
			TakeDamage(20);

        if (collision.gameObject.tag == "Minion")
            TakeDamage(10);


    }*/
    public void OnTriggerStay2D(Collider2D collision)
    {
     
        if (collision.gameObject.tag == "BOSS")
        {
          
                TakeDamage(Damagesystem.BossDamageCollision);
        }


        if (collision.gameObject.tag == "Minion")
        {
          Debug.Log("Hello: " + gameObject.name);
            TakeDamage(Damagesystem.MinionDamage);
            
               
        }
            
    }






    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "HurtStone")
            TakeDamage(Damagesystem.HurtStoneDamage);
    }







    public void ApplyBurn(int ticks , int damage)
    {
        if (burnticktimers.Count <= 0)
        {
            burnticktimers.Add(ticks);
            TakeDamage(damage);
            StartCoroutine(Burn());
            }
        else
        {
            burnticktimers.Add(ticks);
        }
    }



    IEnumerator Burn()
    {
        
        while(burnticktimers.Count > 0)
        {
            for(int i = 0; i < burnticktimers.Count; i++)
            {
                
                burnticktimers[i]--;
                
            }
           
            
           

            burnticktimers.RemoveAll(i => i == 0);
            yield return new WaitForSeconds(0.75f);
        }
    }



  



    void TakeDamage(int damage)
	{
		currentHealth -= damage;

		healthBar.SetHealth(currentHealth);
	}
}
