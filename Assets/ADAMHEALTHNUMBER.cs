using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ADAMHEALTHNUMBER : MonoBehaviour
{
    private TextMeshPro textMeshPro;
    public DamageController Damagesystem;
    public TextMeshProUGUI displayText;
    public BOSSADAM currenthealth;


    void Update()
    {

        displayText.text = (currenthealth.currentHealth.ToString() + " / " + Damagesystem.AdamMaxHealth.ToString());

    }
    // Start is called before the first frame update
    void Start()
    {
        Damagesystem = GameObject.FindGameObjectWithTag("GameManager").GetComponent<DamageController>();
        currenthealth = GameObject.Find("Adam").GetComponent<BOSSADAM>();

    }
}
