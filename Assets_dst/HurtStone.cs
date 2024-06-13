using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class HurtStone : MonoBehaviour
{
    public float cooldown = 0;
    public float cooldowntimer = 1f;
    private bool Iscooldown;

    public void Update()
    {
        if (Iscooldown == false)
        {

            cooldown += 1 / cooldowntimer * Time.deltaTime;

            if (cooldown >= 1)
            {
                cooldown = 0;
                Iscooldown = true;


            }

            if (Iscooldown == true)
            {

                Destroy(gameObject);

            }
        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
       // Debug.Log("Hit with:" + collision.name);

       if(collision.gameObject.tag == "stena")

        {
            Iscooldown = false;
        }
        else
        {
            Iscooldown = true;
        }
        
       

    }
}
