using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Cam : MonoBehaviour
{
    public Vector2 upperBounds;
    public Vector2 lowerBounds;
    float relativeHalfHeight;
    float relativeHalfWidth;

    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        relativeHalfHeight = Camera.main.orthographicSize;
        relativeHalfWidth = relativeHalfHeight * Camera.main.aspect;

        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10); //z muss -10 sein!

        float posX = Camera.main.transform.position.x;
        float posY = Camera.main.transform.position.y;

        upperBounds = new Vector2(posX + relativeHalfWidth, posY + relativeHalfHeight);
        lowerBounds = new Vector2(posX - relativeHalfWidth, posY - relativeHalfHeight);
    }

    public bool isInCameraBounds(Vector2 pos)
    {
        if (lowerBounds.x < pos.x && pos.x < upperBounds.x
            && lowerBounds.y < pos.y && pos.y < upperBounds.y)
        {
            return true;
        }
        return false;
    }
}

