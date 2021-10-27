using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockCursor : MonoBehaviour
{
    void OnGUI()
    {
        //Set Cursor to not be visible
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

}
