using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieFollowing : MonoBehaviour
{
    public Transform playerTarget;

    public NavMeshAgent navAgent;

    // Start is called before the first frame update
    void Start()
    {
        //playerTarget = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(playerTarget != null)
        {
            following();
        }
    }

    public void following()
    {
        navAgent.SetDestination(playerTarget.position);
    }



    public void OnTriggerEnter(Collider other)
    {
        if(other.name == "Player")
        {
            playerTarget = GameObject.Find("Player").transform;
        }
    }
}
