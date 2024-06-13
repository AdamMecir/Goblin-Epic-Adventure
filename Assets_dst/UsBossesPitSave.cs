using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsBossesPitSave : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetString("SAVE", "UsBosses");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
