using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class mira : MonoBehaviour
{
    private int dinero;
    public Canvas canvas;
    public Text texto;
    public Camera camara1l;
    public Text contador;
    public float vida;
    public Text vidas;
    public Canvas menus;
    private bool pausado;
    // Start is called before the first frame update
    void Start()
    {
        dinero = 0;
        vida = 15;
        //Time.timeScale = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            if (pausado)
            {
                Continuar();
            }
            else
            {
                Pausar();
            }

        Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        if (camara1l.enabled)
        {
            if (Input.GetMouseButtonDown(0))
            {
                GetComponent<AudioSource>().Play();
                if (Physics.Raycast(myRay, out hitInfo))
                {
                    if (hitInfo.collider.gameObject.CompareTag("enemigo"))
                    {
                        Destroy(hitInfo.collider.gameObject);
                    }
                }
            }
        }
        contador.text = dinero.ToString()+"$";
        vidas.text = vida.ToString();

        if(dinero>= 120)
        {
            menus.transform.Find("Ganaste").gameObject.SetActive(true);
            Time.timeScale = 0.0f;
        }
        if (vida == 0)
        {
            menus.transform.Find("Perdiste").gameObject.SetActive(true);
            Time.timeScale = 0.0f;
        }
        
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("oro"))
        {
            canvas.transform.Find("Panel").gameObject.SetActive(true);
            texto.text = "Presione E para recojer oro";
            if (Input.GetKeyDown(KeyCode.E))
            {
                dinero += 10;
                Destroy(collision.gameObject);
            }
        }else if (collision.gameObject.CompareTag("dinero"))
        {
            canvas.transform.Find("Panel").gameObject.SetActive(true);
            texto.text = "Presione E para recojer dinero";
            if (Input.GetKeyDown(KeyCode.E))
            {
                dinero += 5;
                Destroy(collision.gameObject);
            }
        }else if (collision.gameObject.CompareTag("monedas"))
        {
            canvas.transform.Find("Panel").gameObject.SetActive(true);
            texto.text = "Presione E para recojer monedas";
            if (Input.GetKeyDown(KeyCode.E))
            {
                dinero += 1;
                Destroy(collision.gameObject);
            }
        }else if (collision.gameObject.CompareTag("puerta"))
        {
            canvas.transform.Find("Panel").gameObject.SetActive(true);
            texto.text = "Presione E para destruir puerta";
            if (Input.GetKeyDown(KeyCode.E))
            {
                Destroy(collision.gameObject);
            }
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        canvas.transform.Find("Panel").gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("bala"))
        {
            vida--;
        }
    }
    public void RegresarG(string escena)
    {
        SceneManager.LoadScene(escena);
    }
    public void Pausar()
    {
        menus.transform.Find("Pausa").gameObject.SetActive(true);
        Time.timeScale = 0.0f;
        pausado = true;
    }
    public void Continuar()
    {
        menus.transform.Find("Pausa").gameObject.SetActive(false);
        Time.timeScale = 1.0f;
        pausado = false;
    }
    public void Regresar(string escena)
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(escena);
    }
    /*public void ContinuarI()
    {
        Time.timeScale = 1.0f;
        menus.transform.Find("Controles").gameObject.SetActive(false);

    }*/
}
