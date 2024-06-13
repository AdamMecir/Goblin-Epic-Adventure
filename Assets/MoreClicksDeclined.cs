using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MoreClicksDeclined : MonoBehaviour
{
    public Button Button;
    public void Prevent(Button Button)
    {
       Button.interactable = false;
    }
}
