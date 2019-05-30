using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public GameObject player;
    public GameObject bala;
    private bool atacando;
    private Vector3 distancia;
    private float separacion;
    private float cadencia = 4f;
    private float disparo = 0;
    private GameObject tiro;
    public GameObject generar;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        atacar();

        distancia = (transform.position - player.transform.position);
        distancia.y = 0;
        separacion = distancia.magnitude;
        distancia /= separacion;

        if (separacion < 10)
        {
            atacando = true;
        }
        else
        {
            atacando = false;
        }
    }


    private void atacar()
    {
        if (atacando)
        {
            if (Time.time > disparo)
            {
                transform.LookAt(player.transform);
                disparo = Time.time + cadencia;
                tiro = Instantiate(bala, generar.transform.position, Quaternion.identity);
                tiro.GetComponent<Rigidbody>().AddForce(transform.forward * 2500);

            }
        }
    }

}
