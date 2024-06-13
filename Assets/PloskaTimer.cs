using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PloskaTimer : MonoBehaviour
{
    public float cooldown = 0;
    public float cooldowntimer = 1f;
    private bool Iscooldown = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

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
        }
        if (Iscooldown == true)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Ploska");
            foreach (GameObject enemy in enemies)
                GameObject.Destroy(enemy);

        }
    }
}
