using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BoblinTextSelector : MonoBehaviour
{
    bool wait;
    public float delay = 0.1f;
    private int rnd;
    public string fullText;
private string currentText = "";
    public TMP_Text textMeshPro;
    // Start is called before the first frame update
    void Start()
    {
       // rnd = Random.Range(0, fullText[]);
        if (PlayerPrefs.GetString("SAVE") == "Kitchen")
        {
          
          //  fullText = "Hey !! Come to the toilet !! ";
            StartCoroutine(Setup());
           // fullText = "I dont have time ! Quickly !";
           // StartCoroutine(Setup());
            
         
  
        }
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        
    }
    void Update()
    {
        
           

    }

  IEnumerator Setup()
    {
        
        for (int i = 0;  i < fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i);
            textMeshPro.text = currentText;
            yield return new WaitForSeconds(delay);

        }
        
    }



}
