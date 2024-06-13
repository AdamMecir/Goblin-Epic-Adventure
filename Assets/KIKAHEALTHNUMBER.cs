using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KIKAHEALTHNUMBER : MonoBehaviour
{
    private TextMeshPro textMeshPro;
    public DamageController Damagesystem;
    public TextMeshProUGUI displayText;
    public BOSSKIKA currenthealth;


    void Update()
    {

            displayText.text = (currenthealth.currentHealth.ToString() + " / " + Damagesystem.KikaMaxHealth.ToString());

    }
    // Start is called before the first frame update
    void Start()
    {
        Damagesystem = GameObject.FindGameObjectWithTag("GameManager").GetComponent<DamageController>();
        currenthealth = GameObject.Find("Kika").GetComponent<BOSSKIKA>();

    }
}