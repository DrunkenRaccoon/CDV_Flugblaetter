using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walker : MonoBehaviour
{
    GameObject waypointsObject;
    WayPoints waypointsScript;

    GameObject camObject;
    Cam camScript;

    GameObject player;
    float reachOfPlayer = 22f;
    public float distFromPlayer;

    UnityEngine.AI.NavMeshAgent agent;

    enum Gender {Female, Male}
    enum Job {Unemployed, Farmer, Worker, Employee, Officer, Capitalist}
    enum Religion {Catholic, Protestant, Jewish, Atheist}
    enum CivilStatus {Single, Married, Widowed, Orphaned}
    enum PoliticalStance {Liberal, Conservative}

    enum Party {KPD, USPD, MSPD, DDP, WBWB, Zentrum, Buergerpartei}

    string firstName;
    Gender gender;
    int age;
    Job job;
    bool isWarDisabled;
    Religion religion;
    CivilStatus civilStatus;
    bool isParent;
    PoliticalStance politicalStance;

    Party partyAffiliation;


// Start is called before the first frame update
void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        waypointsObject = GameObject.Find("WayPoints");
        waypointsScript = waypointsObject.GetComponent<WayPoints>();

        camObject = GameObject.Find("Main Camera");
        camScript = camObject.GetComponent<Cam>();

        player = GameObject.Find("Player");

        
        agent.destination = waypointsScript.getRandomDestination();
    }

    // Update is called once per frame
    void Update()
    {
        distFromPlayer = Vector2.Distance(transform.position, player.transform.position);
        if ( Vector2.Distance(transform.position, player.transform.position) <= reachOfPlayer)
        {
            agent.isStopped = true;
        }
        else
        {
            agent.isStopped = false;
        }
    }

    public bool isAtDestination()
    {
        if( Vector2.SqrMagnitude(transform.position - agent.destination) < 3f )
        {
            return true;
        }
        return false;
    }

    public bool isUnseen()
    {
        return !camScript.isInCameraBounds(transform.position);
    }

    void generateCharacterTraits()
    {
        //to implement
    }
}