using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnTriggerEnter2D(Collider2D collision)
    {

       if (collision.CompareTag("stena"))
        {
            Destroy(gameObject);
        }

    }
}
