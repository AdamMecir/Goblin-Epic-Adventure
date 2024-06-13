using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BCTRIGGER : MonoBehaviour
{
    public TMP_Text text;
    void Update()
    {
        if (PlayerPrefs.GetString("GOD") == "YES")
        {
        
            if (PlayerPrefs.GetString("SAVE") == "Kitchen")
            {
                text = GameObject.Find("BCTEXT").GetComponent<TMP_Text>();
                text.text = "BC. Earned / GOD MOD ENABLED";

            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            PlayerPrefs.SetString("GOD", "YES");
        }
    }
}
