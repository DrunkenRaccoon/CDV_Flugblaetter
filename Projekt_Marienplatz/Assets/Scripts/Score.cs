using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    GameObject score;
    TMP_Text scoreText;
    

    GameObject player;
    Player playerScript;

    // Start is called before the first frame update
    void Start()
    {
        score = GameObject.Find("Score Text");
        scoreText = score.GetComponent<TMP_Text>();

        player = GameObject.Find("Player");
        playerScript = player.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = playerScript.score.ToString();
    }
}
