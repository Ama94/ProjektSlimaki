﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    public string playerName;
    public int numberOfSnails;
    public GameObject snailePrefab;
    public Snail[] team;
    public bool isItMyTurn;
    private int lastUsedSnail;
    private Snail snail;
    private Color color;
    private int teamDeaths;
    
    // Use this for initialization
    void Start () {
       
        InitializeSnails(numberOfSnails, Random.Range(-3f,3f), Random.Range(-3f,2f), snailePrefab);
        isItMyTurn = false;
        lastUsedSnail = 0;
        teamDeaths = 0;
       
	}
	
	// Update is called once per frame
	void Update () {
       
        if (isItMyTurn)
        {
            this.nextSnailTurn();
        }
        else
        {
            this.resetSnails();
        }
	}

    //snail = team[lastUsedSnail].GetComponentInParent(typeof(Snail)) as Snail;
    public Snail[] InitializeSnails(int numberOfSnails, float startingX, float startingY, GameObject SnailPrefab)
    {
        color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f,1f));
        team = new Snail[numberOfSnails];
        for (int x = 0; x < numberOfSnails; x++, startingX++)
        {
            {
                Vector3 pos = new Vector3(startingX, startingY, 0f);
                GameObject temp = Instantiate(SnailPrefab, pos, Quaternion.identity);
                team[x] = temp.GetComponentInParent(typeof(Snail)) as Snail;
                getSnail(x).setColor(color);
            }
        }
        return team;
    }

    public Snail getSnail(int i)
    {
        return team[i]; 
    }

    public void nextSnailTurn()
    {
        teamDeaths = 0;
        foreach(Snail snail in team)
        {
            if (snail.isThisSnailAlive() == false)
            {
                teamDeaths +=1;
            }
        }
        if (teamDeaths >= numberOfSnails) {
            SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
        }
        else
        {
            if (lastUsedSnail == numberOfSnails-1)
            {
                lastUsedSnail = 0;
            }
            if (team[lastUsedSnail].isThisSnailAlive())
            {
                team[lastUsedSnail].setTurnOn();
            }

            if (team[lastUsedSnail].isThisSnailAlive() == false)
            {
                //lastUsedSnail++;
                nextSnailTurn();
            }
        }
    }

    public void resetSnails()
    {
        for(int i=0; i<numberOfSnails; i++)
        {
            team[i].setTurnOff();
        }
    }

    public void incrementLastUsedSnail()
    {
        
        if (lastUsedSnail < numberOfSnails)
        {
            lastUsedSnail++;
        }
       if (lastUsedSnail == numberOfSnails)
        {
            lastUsedSnail = 0;
        }
       
    }

    public int getLastUsedSnail()
    {
        return lastUsedSnail;
    }
}
