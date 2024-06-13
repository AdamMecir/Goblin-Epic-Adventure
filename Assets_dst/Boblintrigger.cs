using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boblintrigger : MonoBehaviour
{
    private GameObject Boblin;
    private GameObject Teleport;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Teleport = GameObject.FindGameObjectWithTag("Teleport");
            Boblin = (GameObject)Resources.Load("Boblin", typeof(GameObject));
            GameObject.Instantiate(Boblin, Teleport.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

    }
        // Start is called before the first frame update
        void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
