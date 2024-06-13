using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BoblinTextSelector : MonoBehaviour
{
    public int Order = 0;

    public float delay = 0.1f;
    private string[] KitchenBoblin1 =
        {"Hey !! Come to the toilet !! ",
         "I dont have time ! Quickly !",
         "Toilet ! Quick !",
         "It is important , Come to the Toilet !",
         "You know what a toilet is?"
        };

    private string[] KitchenBoblin2 =
        {"I lost my most important thing !!",
         "Please Help me !",
         "Jump to the toilet and help me pleaseee !",
         "It is important !",
         "Where's the hold up?",
         "Come on..."
        };
    private string[] SlimeBoblin =
     {"Kill that Slime !!",
         " Come on !!! Press harder that W",
         "Why are you just running? Kill it !",
         "Dont be such a pus** !!!",
            "I eat such jello for breakfast !",
            "Use salt!",
            "We need more salt",
            "Are you really taking this long?",
            "Man, you really are phatethic...",
            "You are quite bad at this..."
        };
    private string[] GolemBoblin =
   {"This guy is easy, dont worry",
         "He just throws rocs  !!!",
         "Here comes a Stone",
         "My Grandma can fight better dude ...",
            "Did you give up yet?",
            "Are you even trying???",
            "This is really sad to look at...",
            "Are you sure you're an adventurer?"
        };

    private string[] UsBoblin =
  {"They were very weak in school !!",
         "Try better !",
         "Adam , Lukas , Kika , Palo ? These are such dumb Bosses",
         "They dont know what is going on here !!",
         "Why are they even here?",
         "Don't they have classes to attend?",
         "You really shouldn't be taking this long...",
         "How are you this bad?",
         "The're IT students...",
         "You should've won by now..."
        };


    private int rnd;
    private string fullText;
    private string currentText = "";
    private TMP_Text textMeshPro;
    private BoblinFollow BoblinInKitchen;
    public AudioSource Clip;
    // Start is called before the first frame update
    void Start()
    {
        // rnd = Random.Range(0, fullText[]);
        textMeshPro = GameObject.Find("Text (TMP)").GetComponent<TMP_Text>();
        BoblinInKitchen = GameObject.FindGameObjectWithTag("NPC").GetComponent<BoblinFollow>();
            StartCoroutine(Setup());


       




    }

    // Update is called once per frame
    private void FixedUpdate()
    {
       
    }
    void Update()
    {


        BoblinInKitchen = GameObject.FindGameObjectWithTag("NPC").GetComponent<BoblinFollow>();
        if (BoblinInKitchen.KitchenSpawned == true)
            {
                Order = 1;
            }
        else if (BoblinInKitchen.SlimeSpawned == true)
        {
            Order = 2;
        }
        else if (BoblinInKitchen.GolemSpawned == true)
        {
            Order = 3;
        }
        else if (BoblinInKitchen.UsSpawned == true)
        {
            Order = 4;
        }
        else
        {

        }


    }

  IEnumerator Setup()
    {
    while(Order == 0)
        {
     

            rnd = Random.Range(0,KitchenBoblin1.Length);
        fullText = KitchenBoblin1[rnd];
        for (int i = 0;  i <= fullText.Length; i++)
        {
                Clip.Play();
            currentText = fullText.Substring(0, i);
            textMeshPro.text = currentText;
                
                yield return new WaitForSeconds(delay);  
            Clip.Stop();
         

        }
            yield return new WaitForSeconds(3);

        }
    while(Order == 1)
        {
            rnd = Random.Range(0, KitchenBoblin2.Length);
            fullText = KitchenBoblin2[rnd];
            for (int i = 0; i <= fullText.Length; i++)
            {
                Clip.Play();
                currentText = fullText.Substring(0, i);
                textMeshPro.text = currentText;
                yield return new WaitForSeconds(delay);
                Clip.Stop();

            }
            yield return new WaitForSeconds(3);
        }
        while (Order == 2)
        {
            rnd = Random.Range(0, SlimeBoblin.Length);
            fullText = SlimeBoblin[rnd];
            for (int i = 0; i <= fullText.Length; i++)
            {
                Clip.Play();
                currentText = fullText.Substring(0, i);
                textMeshPro.text = currentText;
                yield return new WaitForSeconds(delay);
                Clip.Stop();

            }
            yield return new WaitForSeconds(3);
        }
        while (Order == 3)
        {
            rnd = Random.Range(0, GolemBoblin.Length);
            fullText = GolemBoblin[rnd];
            for (int i = 0; i <= fullText.Length; i++)
            {
                Clip.Play();
                currentText = fullText.Substring(0, i);
                textMeshPro.text = currentText;
                yield return new WaitForSeconds(delay);
                Clip.Stop();

            }
            yield return new WaitForSeconds(3);
        }
        while (Order == 4)
        {
            rnd = Random.Range(0, UsBoblin.Length);
            fullText = UsBoblin[rnd];
            for (int i = 0; i <= fullText.Length; i++)
            {
                Clip.Play();
                currentText = fullText.Substring(0, i);
                textMeshPro.text = currentText;
                yield return new WaitForSeconds(delay);
                Clip.Stop();

            }
            yield return new WaitForSeconds(3);
        }


    }


}
