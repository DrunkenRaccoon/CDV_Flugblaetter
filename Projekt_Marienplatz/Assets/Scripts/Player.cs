using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rbody;
    float speed;

    public bool isTalkingToWalker = false;
    public GameObject talkingWaker;

    GameObject leafletsObject;
    Leaflets leafletsScript;

    public int score = 0;

    /*readonly int mapMaxHorizontal = 650;
    readonly int mapMaxVertical = 350;*/

    // Start is called before the first frame update
    void Start()
    {
        speed = 50f;
        rbody = gameObject.GetComponent<Rigidbody2D>();

        leafletsObject = GameObject.Find("Leaflets");
        leafletsScript = leafletsObject.GetComponent<Leaflets>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            giveLeaflet();
        }
    }

    private void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector2 translationVector = new Vector2(horizontalInput * speed, verticalInput * speed) * Time.fixedDeltaTime;


        /*float camHeight = Camera.main.orthographicSize;
        float camWidth = camHeight * Camera.main.aspect;
        float posX = transform.position.x;
        float posY = transform.position.y;

        bool isNotAllowedToMove =
               (posY - camHeight > -mapMaxVertical && rbody.velocity.y <= 0)
            || (posY + camHeight < mapMaxVertical && rbody.velocity.y > 0)
            || (posX - camWidth > -mapMaxHorizontal && rbody.velocity.x <= 0)
            || (posX + camWidth < mapMaxHorizontal && rbody.velocity.x > 0);*/
        
        rbody.MovePosition(rbody.position + translationVector);
       
    }

    void giveLeaflet()
    {
        Leaflets.Leaflet currentLeaflet = leafletsScript.leafletArray[leafletsScript.currentLeafletIndex];

        if (talkingWaker != null)
        {
            Walker walkerScript = talkingWaker.GetComponent<Walker>();

            // TODO wenn reward gleich null -> Zeitmalus
            score += walkerScript.rewardLeaflet(currentLeaflet);
        }
    }
}
