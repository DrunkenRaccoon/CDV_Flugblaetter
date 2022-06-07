using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rbody;
    float speed;

    public bool isTalkingToWalker = false;
    public GameObject talkingWaker;

    public int score = 0;

    readonly int mapMaxHorizontal = 650;
    readonly int mapMaxVertical = 350;

    // Start is called before the first frame update
    void Start()
    {
        speed = 50f;
        rbody = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
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
        if(talkingWaker != null)
        {
            Walker walkerScript = talkingWaker.GetComponent<Walker>();
            score += walkerScript.rewardLeaflet();
        }
    }
}
