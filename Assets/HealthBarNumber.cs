using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthBarNumber : MonoBehaviour
{
    private TextMeshPro textMeshPro;
    public DamageController Damagesystem;
    public TextMeshProUGUI displayText;
    public Boss currenthealth;


    void Update()
    {
        if (PlayerPrefs.GetString("SAVE") == "Slime")
             displayText.text = (currenthealth.currentHealth.ToString() +" / "+  Damagesystem.BossMaxHealth.ToString());
        else if (PlayerPrefs.GetString("SAVE") == "Golem")
            displayText.text = (currenthealth.currentHealth.ToString() + " / " + Damagesystem.GolemMaxHealth.ToString());
        //else if (PlayerPrefs.GetString("SAVE") == "UsBosses")
    }
    // Start is called before the first frame update
    void Start()
    {
        Damagesystem = GameObject.FindGameObjectWithTag("GameManager").GetComponent<DamageController>();
        currenthealth = GameObject.FindGameObjectWithTag("BOSS").GetComponent<Boss>();

    }

  
}
