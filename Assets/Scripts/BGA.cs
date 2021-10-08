using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BGA : MonoBehaviour
{
    public GameObject respawn;
    void Start()
    {
        if (respawn == null)
            respawn = GameObject.FindWithTag("Audio");
        if (respawn == true)
            Destroy(this.gameObject);
        return;
    }
}