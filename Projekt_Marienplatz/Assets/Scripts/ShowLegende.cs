using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowLegende : MonoBehaviour
{
    Image legende;

    private void Start()
    {
        legende = gameObject.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && legende.enabled == false) {
            legende.enabled = true;
        }
        else if (Input.GetKeyDown(KeyCode.E) && legende.enabled == true) {
            legende.enabled = false;
        }
        
        // gameObject.SetActive(Input.GetKeyDown(KeyCode.E));
    }
}
