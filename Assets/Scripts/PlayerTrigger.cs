using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    public WinLoose winLooseScript;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -50f)
        {
            winLooseScript.LooseLevel();
        }
    }
}
