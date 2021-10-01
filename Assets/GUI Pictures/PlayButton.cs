using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Playbutton : MonoBehaviour
{
    int n;
    public void OnButtonPress()
    {
        n++;
        Debug.Log("Button clicked " + n + " times.");
    }
}
