using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    private float rotZ;
    public float rotSpeed;
    public bool rotClockwise;

    // Update is called once per frame
    void Update()
    {
        if(rotClockwise == false) {
            rotZ += Time.deltaTime * rotSpeed;
        }
        else {
            rotZ += -Time.deltaTime * rotSpeed; 
        }

        transform.rotation = Quaternion.Euler(0, 0, rotZ);
    }
}
