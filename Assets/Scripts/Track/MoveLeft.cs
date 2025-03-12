using System.Collections;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 25;
    private float initialSpeed;
    private PlayerController playerController;
    private float leftBound = -15;

    void Start()
    {
        /*// playerController = GameObject.Find("Player").GetComponent<PlayerController>();*/
        initialSpeed = speed;
    }

    void Update()
    {

        transform.Translate(Vector3.left * Time.deltaTime * speed);

        /*if (playerControllerScript.gameOver == false) --- Esto si vamos a finalizar el juego cuando chcoca con un objeto
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }*/

        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Verifica si el objeto con el que colision� tiene la etiqueta "ObstacleLimit"
        if (collision.gameObject.CompareTag("ObstacleLimit"))
        {
            // Imprime "Colisi�n" en la consola
            Debug.Log("Colisi�n");
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            // Reduce la velocidad cuando colisiona con el jugador
            speed = speed * 0.5f; // Reduce la velocidad a la mitad
            Debug.Log("Colisi�n con Player, nueva velocidad: " + speed);

            // Inicia la corrutina para restaurar la velocidad despu�s de 20 segundos
            StopAllCoroutines(); // Det�n cualquier otra corrutina que est� ejecut�ndose
            StartCoroutine(RestoreSpeed());
        }

    }

    IEnumerator RestoreSpeed()
    {
        yield return new WaitForSeconds(10f); // Espera 10 segundos
        speed = initialSpeed; // Restaura la velocidad inicial
        Debug.Log("Velocidad restaurada a: " + speed);
    }


}
