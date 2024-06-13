using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PALOHEALTHNUMBER : MonoBehaviour
{
    private TextMeshPro textMeshPro;
    public DamageController Damagesystem;
    public TextMeshProUGUI displayText;
    public BOSSPALO currenthealth;


    void Update()
    {

        displayText.text = (currenthealth.currentHealth.ToString() + " / " + Damagesystem.PaloMaxHealth.ToString());

    }
    // Start is called before the first frame update
    void Start()
    {
        Damagesystem = GameObject.FindGameObjectWithTag("GameManager").GetComponent<DamageController>();
        currenthealth = GameObject.Find("Palo").GetComponent<BOSSPALO>();

    }
}
