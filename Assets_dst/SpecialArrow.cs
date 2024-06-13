using System.Collections;
using System.Collections.Generic;
//using System.Threading;
using UnityEngine;

public class SpecialArrow : MonoBehaviour
{
    public GameObject SpecialArrowItem;

    public void Start()
    {
       
    }
    public void Update()
    {
      
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BOSS") || collision.CompareTag("Minion") || collision.CompareTag("stena") || collision.CompareTag("Bariera"))
        {
        
        SpecialArrowItem = (GameObject)Resources.Load("ArrowSpecialDamage", typeof(GameObject));
        GameObject.Instantiate(SpecialArrowItem, transform.position, Quaternion.identity);

            
          
            


                
            Destroy(gameObject);
            
        }
        if (collision.CompareTag("Kamen"))
        {
            Destroy(gameObject);
        }
        else
        {
        



        }
        
    }

}
