using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class BOSSKIKA : MonoBehaviour
{

    public int currentHealth;
    public GameObject Teleport;
    public HealthBar healthBar;
    public Transform MiddleLocation;
    public DamageController Damagesystem;
    public int maxHealth;

    // Start is called before the first frame update
    void Start()
    {
        Damagesystem = GameObject.FindGameObjectWithTag("GameManager").GetComponent<DamageController>();

        healthBar = GameObject.FindGameObjectWithTag("HealthBarBossKika").GetComponent<HealthBar>();


        maxHealth = Damagesystem.KikaMaxHealth;

        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

    }

    // Update is called once per frame
    void Update()
    {
        maxHealth = Damagesystem.BossMaxHealth;
        if (currentHealth <= 0)
        {

            Destroy(gameObject);

        }

    }
    public void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.gameObject.tag == "Sip" && PlayerPrefs.GetString("Damage") == "true")
            TakeDamage(Damagesystem.SipDamage);







    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ploska" && PlayerPrefs.GetString("Damage") == "true")
            TakeDamage(Damagesystem.PloskaDamage);
    }
    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }
}
