using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class FINISH : MonoBehaviour
{
    // Start is called before the first frame update

    public int order = 0;
    public float delay = 0.1f;
    private string[] FINISHBOBLIN =
        {"My LollyPOP !!!!!! ",
         "Next time be faster , it hasnt got any taste now .."
        };

    private string[] FINISHMOM =
      {"WHAT ARE YOU DOING !?",
         "IT IS TIME FOR DINNER !!",
         "GO HOME NOW !!!",

        };

    private string[] FINISHBOBLIN2 =
      {"But Mom"

        };
    private string[] FINISHMOM2 =
  {"NO BUTS!!",
         "HOME ! NOW !"
  

        };
    private string[] FINISHBOBLIN3 =
   {"Okey .. Bye kiddo."

        };
    public string fullText;
    private string currentText = "";
    public TMP_Text textMeshPro;
    public AudioSource Clip;
    public AudioSource ClipMOM;

    public Image ImageBoblin;
    public Image ImageMOM;
    public Image StoreIMG;
    // Start is called before the first frame update
    void Start()
    {
        // rnd = Random.Range(0, fullText[]);
        PlayerPrefs.SetString("SAVE", "FINISH");

        ClipMOM = GameObject.Find("AudioSourceMOM").GetComponent<AudioSource>();
        ImageBoblin = GameObject.Find("BoblinIMG").GetComponent<Image>();
        ImageMOM = GameObject.Find("MOM").GetComponent<Image>();
        StoreIMG = GameObject.Find("Store").GetComponent<Image>();
        StartCoroutine(Setup());


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
        while (order == 0)
        {


            for (int y = 0; y <= FINISHBOBLIN.Length; y++)
            {
                if (y == FINISHBOBLIN.Length)
                {

                    order = 1;
                    StartCoroutine(Setup2());

                }
                else
                {

                    fullText = FINISHBOBLIN[y];
                    for (int i = 1; i <= fullText.Length; i++)
                    {
                        Clip.Play();
                        currentText = fullText.Substring(0, i);
                        textMeshPro.text = currentText;

                        yield return new WaitForSeconds(delay);
                        Clip.Stop();


                    }
                }

                yield return new WaitForSeconds(2);


            }

        }
        


    }
    IEnumerator Setup2()
    {
        while (order == 1)
        {
            StoreIMG.sprite = ImageBoblin.sprite;
            ImageBoblin.sprite = ImageMOM.sprite;



            for (int y = 0; y <= FINISHMOM.Length; y++)
            {
                if (y == FINISHMOM.Length)
                {

                    order = 3;
                    StartCoroutine(Setup3());

                }
                else
                {
                    fullText = FINISHMOM[y];
                    for (int i = 1; i <= fullText.Length; i++)
                    {
                        Clip.Play();
                        currentText = fullText.Substring(0, i);
                        textMeshPro.text = currentText;
                        yield return new WaitForSeconds(delay);
                        Clip.Stop();

                    }
                }

                yield return new WaitForSeconds(1);
            }
        }
    }
    IEnumerator Setup3()
    {
        while (order == 3)
        {
            ImageBoblin.sprite = StoreIMG.sprite;



            for (int y = 0; y <= FINISHBOBLIN2.Length; y++)
            {
                if (y == FINISHBOBLIN2.Length)
                {

                    order = 4;
                    StartCoroutine(Setup4());

                }
                else
                {
                    fullText = FINISHBOBLIN2[y];
                    for (int i = 1; i <= fullText.Length; i++)
                    {
                        Clip.Play();
                        currentText = fullText.Substring(0, i);
                        textMeshPro.text = currentText;
                        yield return new WaitForSeconds(delay);
                        Clip.Stop();

                    }
                }

                yield return new WaitForSeconds(1);
            }
        }
    }
    IEnumerator Setup4()
    {
        while (order == 4)
        {
            StoreIMG.sprite = ImageBoblin.sprite;
            ImageBoblin.sprite = ImageMOM.sprite;



            for (int y = 0; y <= FINISHMOM2.Length; y++)
            {
                if (y == FINISHMOM2.Length)
                {

                    order = 5;
                    StartCoroutine(Setup5());

                }
                else
                {


                    fullText = FINISHMOM2[y];
                    for (int i = 1; i <= fullText.Length; i++)
                    {
                        Clip.Play();
                        
                        currentText = fullText.Substring(0, i);
                        textMeshPro.text = currentText;
                        yield return new WaitForSeconds(delay);
                        Clip.Stop();

                    }
                }

                yield return new WaitForSeconds(2);
            }
        }
    }
    IEnumerator Setup5()
    {
        while (order == 5)
        {
            ImageBoblin.sprite = StoreIMG.sprite;



            for (int y = 0; y <= FINISHBOBLIN3.Length; y++)
            {
                if (y == FINISHBOBLIN3.Length)
                {
                    order = 6;
                    SceneManager.LoadScene(0);
                    //SceLoadScene(1);
                    //StartCoroutine(Setup5());

                }
                else
                {
                    fullText = FINISHBOBLIN3[y];
                    for (int i = 1; i <= fullText.Length; i++)
                    {
                        Clip.Play();
                        currentText = fullText.Substring(0, i);
                        textMeshPro.text = currentText;
                        yield return new WaitForSeconds(delay);
                        Clip.Stop();

                    }
                }
                yield return new WaitForSeconds(1);
            }
        }
    }
}
