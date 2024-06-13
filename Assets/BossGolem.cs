using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class BossGolem : MonoBehaviour
{
    private int maxHealth = 1000;
    public int currentHealth;
    public GameObject Teleport;
    private HealthBar healthBar;
    public Transform MiddleLocation;
    BossMovement Barierabool;


    // Start is called before the first frame update
    void Start()
    {
        healthBar = GameObject.FindGameObjectWithTag("HealthBarBoss").GetComponent<HealthBar>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {

            MiddleLocation = GameObject.FindGameObjectWithTag("MiddlePoint").GetComponent<Transform>();
            Teleport = GameObject.FindGameObjectWithTag("Teleport");
            GameObject.Instantiate(Teleport, MiddleLocation.transform.position, Quaternion.identity);
            DestroyImmediate(GameObject.FindGameObjectWithTag("BOSS"), true);

        }

    }
    public void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.gameObject.tag == "Sip" && PlayerPrefs.GetString("Damage") == "true")
            TakeDamage(20);

        if (collision.gameObject.tag == "Ploska" && PlayerPrefs.GetString("Damage") == "true")
            TakeDamage(30);













    }
    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }
}
