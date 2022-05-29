using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rbody;

    float speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = 50f;
        rbody = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {        

    }

    private void FixedUpdate()
    {
        Vector2 translationVector = new Vector2(Input.GetAxis("Horizontal") * speed, Input.GetAxis("Vertical") * speed) * Time.fixedDeltaTime;
        rbody.MovePosition(rbody.position + translationVector);
    }
}
