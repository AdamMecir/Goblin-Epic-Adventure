using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnPlayer : MonoBehaviour
{
   
    private GameObject SpawnLocation;
    private GameObject Player;
   



    // Start is called before the first frame update
    void Start()
    {
         if (PlayerPrefs.GetString("Char") == "Warrior")
         Player = (GameObject)Resources.Load("PlayerWarrior",typeof(GameObject));
       if (PlayerPrefs.GetString("Char") == "Mage")
         Player = (GameObject)Resources.Load("PlayerMage",typeof(GameObject));
    if (PlayerPrefs.GetString("Char") == "Archer")
         Player = (GameObject)Resources.Load("PlayerArcher",typeof(GameObject));
     
       
        SpawnLocation = GameObject.FindGameObjectWithTag("SpawnPoint");

        spawncharacter();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void spawncharacter()
    {
        GameObject.Instantiate(Player, SpawnLocation.transform.position, Quaternion.identity);
    }

    public void ChoseClassWarior()
    {
        PlayerPrefs.SetString("Char","Warrior");
    }
    public void ChoseClassMage()
    {
        PlayerPrefs.SetString("Char","Mage");
    }
    public void ChoseClassArcher()
    {
        PlayerPrefs.SetString("Char","Archer");
    }

}
