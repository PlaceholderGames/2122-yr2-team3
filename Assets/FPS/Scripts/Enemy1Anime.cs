using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Enemy1Anime : MonoBehaviour
{ 
    public float lookRadius = 10f;

    Transform target;
    NavMeshAgent agent;
    Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        
        if (distance <= lookRadius)
        {
            anim.SetBool("IsRun", true);
            anim.SetBool("IsIdle", false);
        }else
        {
            anim.SetBool("IsRun", false);
            anim.SetBool("IsIdle", true);

        }

    }
}
