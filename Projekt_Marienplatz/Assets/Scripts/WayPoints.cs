using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoints : MonoBehaviour
{

    GameObject waypoints;
    public Transform[] waypointTransforms;
    public Vector2[] waypointPositions;

    List<GameObject> walkerList = new List<GameObject>();
    int numOfWalkers = 20;
    [SerializeField] 
    GameObject walkerPrefab;

    GameObject camObject;
    Cam camScript;


    // Start is called before the first frame update
    void Start()
    {
        waypoints = this.gameObject;
        waypointTransforms = GetComponentsInChildren<Transform>(waypoints);
        waypointPositions = new Vector2[waypoints.transform.childCount];

        camObject = GameObject.Find("Main Camera");
        camScript = camObject.GetComponent<Cam>();

        for (int i = 0; i < waypointPositions.Length; i++)
        {
            waypointPositions[i] = waypointTransforms[i + 1].position;
        }

        for(int i = 0; i < numOfWalkers; i++)
        {
            spawnWalker();
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject walker in walkerList.ToArray()) //ToArray() nicht die beste Lösung
        {
            Walker wscript = walker.GetComponent<Walker>();
            if (wscript.isAtDestination() && wscript.isUnseen()) 
            {
                walkerList.Remove(walker);
                GameObject.Destroy(walker);
            }
        }

        if(walkerList.Count < numOfWalkers)
        {
            spawnWalker();
        }
    }

    public Vector2 getRandomDestination()
    {
        int ran = Random.Range(0, waypointPositions.Length);       
        return waypointPositions[ran];
    }

    //public Vector2 getSpawnPosition()

    void spawnWalker()
    {
        walkerList.Add(
                Instantiate(walkerPrefab,
                getRandomDestination(),
                Quaternion.identity));
    }

}
