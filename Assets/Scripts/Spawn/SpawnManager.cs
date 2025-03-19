
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    [SerializeField]
    private float startDelay = 1;
    [SerializeField]
    private float repeatRate = 1;
    
    private Vector3 spawnPos = new Vector3(40, 0, 0);

    //private PlayerController playerControllerScript;

    void Start()
    {
        //playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
        //Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation); Esto tambi�n mirar si es �til
    }

    void OnCollisionEnter(Collision collision)
    {
        // Verifica si el objeto con el que colision� tiene la etiqueta "ObstacleLimit"
        if (collision.gameObject.CompareTag("ObstacleLimit"))
        {
            // Imprime "Colisi�n" en la consola
            Debug.Log("Colisi�n");
        }
    }

    void SpawnObstacle()
    {
        Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);

        //Vector3 spawnPos = new Vector3(25, 0, 0);
        //int index = Random.Range(0, obstaclePrefab.Length);


        //Esto se puede dejar por si vamos a finalizar el juego. Por ahora, en espera de c�digo de tiempo
        //if (playerControllerScript.gameOver == false)
        //{
        //    Instantiate(obstaclePrefab[index], spawnPos, obstaclePrefab[index].transform.rotation);
        //}
    }
}
