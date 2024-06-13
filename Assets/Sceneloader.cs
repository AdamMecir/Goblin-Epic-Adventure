using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Sceneloader : MonoBehaviour
{
   public int index;
  
  public GameObject loaderUI;
  public Slider progressSlider;

    private void Update()
    {
        
    }


    private void OnTriggerEnter2D (Collider2D collision)
     {

        if (collision.gameObject.tag == "Player")
        {
       
         LoadScene(index);
      
        }
            
    } 
    public void LoadScene(int index)
    {
        
         if (index == 2)
                PlayerPrefs.SetString("SAVE", "Kitchen");
        else  if(index == 3)
            PlayerPrefs.SetString("SAVE", "Slime");
        else if (index == 4)
            PlayerPrefs.SetString("SAVE", "Golem");
        else if (index == 5)
            PlayerPrefs.SetString("SAVE", "UsBosses");
        StartCoroutine(LoadScene_Coroutine(index));
   

    }
    public void LoadSceneAgain()
    {
        if (PlayerPrefs.GetString("SAVE") == "Slime")
            StartCoroutine(LoadScene_Coroutine(3));

        if (PlayerPrefs.GetString("SAVE") == "Golem")
        StartCoroutine(LoadScene_Coroutine(4));

        if (PlayerPrefs.GetString("SAVE") == "UsBosses")
            StartCoroutine(LoadScene_Coroutine(5));



    }

    public IEnumerator LoadScene_Coroutine(int index)
  {
    progressSlider.value = 0;
    loaderUI.SetActive(true);

    AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(index);
    asyncOperation.allowSceneActivation = false;
    float progress = 0;
    while(!asyncOperation.isDone)
    {
        progress = Mathf.MoveTowards(progress,asyncOperation.progress, Time.deltaTime);
        progressSlider.value = progress;
        if(progress >= 0.9f)
        {
            progressSlider.value = 1;
            asyncOperation.allowSceneActivation = true;
        }
        yield return null;
    }
  }

}