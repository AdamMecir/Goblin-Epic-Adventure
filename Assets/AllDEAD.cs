using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllDEAD : MonoBehaviour
{
    public Transform MiddleLocation;
    public GameObject Teleport;
    public BOSSADAM currenthealthA;
    public BOSSKIKA currenthealthK;
    public BOSSPALO currenthealthP;
    public BOSSLUKAS currenthealthL;
    // Start is called before the first frame update
    void Start()
    {
        currenthealthA = GameObject.Find("Adam").GetComponent<BOSSADAM>();
        currenthealthK = GameObject.Find("Kika").GetComponent<BOSSKIKA>();
        currenthealthP = GameObject.Find("Palo").GetComponent<BOSSPALO>();
        currenthealthL = GameObject.Find("Lukas").GetComponent<BOSSLUKAS>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currenthealthA.currentHealth <= 0 && currenthealthK.currentHealth <= 0 && currenthealthP.currentHealth <= 0 && currenthealthL.currentHealth <= 0 )
        {

            MiddleLocation = GameObject.FindGameObjectWithTag("MiddlePoint").GetComponent<Transform>();
            Teleport = GameObject.FindGameObjectWithTag("Teleport");
            Teleport.transform.position = MiddleLocation.transform.position;
            Destroy(gameObject);

        }
    }
}
