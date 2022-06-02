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
        Vector2 translationVector = new Vector2(Input.GetAxis("Horizontal") * speed, Input.GetAxis("Vertical") * speed) * Time.fixedDeltaTime;
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
