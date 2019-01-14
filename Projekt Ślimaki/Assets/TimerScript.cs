using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TimerScript : MonoBehaviour
{

    public static bool afterShootingTurn = false;
    public Text textPool;
    private float startingTime = 5f;
    private float waitingTime = 5f;
    private float afterShootingTime = 3f;
    public flowController flowController;


    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (afterShootingTurn == false)
        {
            timeTicking();
        }
        else
        {
            timerAfterShoot();
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

    private void timeTicking()
    {
        startingTime -= Time.deltaTime;
        timeAlertState(startingTime);
        textPool.text = "Your turn: " + (int)startingTime;
        if (startingTime <= 0f)
        {
            resetTimer();
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
            defaultTime();
        }
    }

    private void defaultTime()
    {
        startingTime = 20f;
        waitingTime = 5f;
    }

    public void timerAfterShoot()
    {
        textPool.color = Color.green;
        afterShootingTime -= Time.deltaTime;
        textPool.text = "Hide! Your turn ends in: " + (int)afterShootingTime;
        if (afterShootingTime <= 0f)
        {
            startingTime = 0f;
            flowController.resetPlayers();
            //flowController.nextPlayer();
            afterShootingTurn = false;
            afterShootingTime = 3f;
            {
                resetTimer();
            }
        }
    }
}


