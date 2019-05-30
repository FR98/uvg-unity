using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

public class PlayerAI : MonoBehaviour
{
    private NavMeshAgent playerAIAgent;
    public GameObject[] wayPoints;
    float secondsCounter = 0;
    float secondsToCount = 120;
    int lastRnd = 0;

    // Start is called before the first frame update
    void Start()
    {
        playerAIAgent = GetComponent<NavMeshAgent>();
        move();
    }

    // Update is called once per frame
    void Update()
    {
        // Desicion aleatoria respecto al movimiento
        if (randomNumber(0,2) == 1) {
            // Movimiento aleatorio seleccionando nueva posicion cada cierto tiempo
            secondsCounter += Time.deltaTime;
            if (secondsCounter >= secondsToCount) {
                secondsCounter = 0;
                move();
            }
        } else {
            // Movimiento aleatorio seleccionando nueva posicion cuando se encuantra cerca de su destino
            if (playerAIAgent.remainingDistance < 0.5f)
                move();
        }

    }

    void move() {
        // int rndPosition = randomNumber(0, (wayPoints.Length));
        // if (wayPoints.Length > 0) {
        //     playerAIAgent.SetDestination(wayPoints[rndPosition].transform.position);
        // }
    }

    int randomNumber(int i, int f) {
        System.Random rnd = new System.Random();
        int rndNum = rnd.Next(i, f);
        if (rndNum == lastRnd) {
            randomNumber(i, f);
        }
        lastRnd = rndNum;
        return rndNum;
    }
}
