﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flowController : MonoBehaviour {

    public int numberOfPlayers;
    public Player player;
    public Player[] players;
    public AudioSource startGame;
    public int nowActive=0;
    
	// Use this for initialization
	void Start () {
        InitializePlayers();
        startGame.Play();
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    public void InitializePlayers()
    {
        players = new Player[numberOfPlayers];
        for (int i = 0; i < numberOfPlayers; i++)
        {
            players[i] = Instantiate<Player>(player);
        }
    }

    public Player[] getPlayers()
    {
        return players;
    }

    public void resetPlayers()
    {
        for (int i = 0; i < numberOfPlayers; i++)
        {
            players[i].isItMyTurn = false;
        }
    }

    public void nextPlayer()
    {
        // prawdopodobnie bardzo nieoptymalne rozwiązanie :/ zakomentowane trzeba poprawić i bez pętli powinno być lepiej.
      
        if(nowActive == numberOfPlayers)
        {
            nowActive = 0;
        }
        players[nowActive].isItMyTurn = true;
        players[nowActive].incrementLastUsedSnail();
       
        nowActive++;
       
        /* if (nowActive < numberOfPlayers && nowActive>0)
         {
             Debug.Log(nowActive);
             Debug.Log("war 1 !");
             players[(nowActive-1)].isItMyTurn = false;
             players[nowActive++].isItMyTurn = true;
             Debug.Log(nowActive);
             Debug.Log("war 1 END !");
         }
         if (nowActive <= numberOfPlayers-1)
         {
             Debug.Log(nowActive);
             Debug.Log("war 2 przed zerowaniem !");
             nowActive = 0;
             players[(numberOfPlayers-1)].isItMyTurn = false;
             players[nowActive].isItMyTurn = true;
             Debug.Log(nowActive);
             Debug.Log("war 2 po zerowaniu !");
         }

         if(nowActive == 0)
         {
             Debug.Log(nowActive);
             Debug.Log("war 3 !");
             players[nowActive].isItMyTurn = true;
             nowActive++;
             Debug.Log(nowActive);
             Debug.Log("war 3 END !");
         }
         */
    }
}
