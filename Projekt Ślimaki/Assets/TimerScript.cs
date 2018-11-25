using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TimerScript : MonoBehaviour
{


    public Text textPool;
    private float startingTime = 5f;
    private float waitingTime = 5f;
    public flowController flowController;


    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        startingTime -= Time.deltaTime;
        timeAlertState(startingTime);
        textPool.text = "Your turn: " + (int)startingTime;
        if (startingTime <= 0f)
        { 
            resetTimer();

        }
        
    }

    private void timeAlertState(float t)
    {
        if (t < 8)
        {
            textPool.color = Color.red;
        }
        else
        {
            textPool.color = Color.white;
        }
    }

    private void resetTimer()
    {
        textPool.color = Color.yellow;
        
        waitingTime -= Time.deltaTime;
        textPool.text = "Prepare! " + (int)waitingTime;
        flowController.resetPlayers();
        if (waitingTime <= 0f)
        {
            flowController.nextPlayer();
            startingTime = 20f;
            waitingTime = 5f;
        }
    }
}


