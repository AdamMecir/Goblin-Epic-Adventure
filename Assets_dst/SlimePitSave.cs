using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimePitSave : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
            PlayerPrefs.SetString("SAVE", "Slime");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
