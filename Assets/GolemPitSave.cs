using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemPitSave : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetString("SAVE", "Golem");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
