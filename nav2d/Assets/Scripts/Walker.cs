using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walker : MonoBehaviour
{

    Transform destinationTransform;
    GameObject destination;

    // Start is called before the first frame update
    void Start()
    {
        var agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        destination = GameObject.Find("Destination");
        destinationTransform = destination.transform;

        agent.destination = destinationTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
