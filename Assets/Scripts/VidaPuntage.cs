using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class VidaPuntage : MonoBehaviour {

    [SerializeField]
    private int vidas = 3;
    [SerializeField]
    private Text UI_puntaje;
    [SerializeField]
    private Text UI_vidas;

    private int puntaje = 0;
    private GameObject enemigo;

	// Use this for initialization
	void Start ()
    {
        enemigo = null;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (enemigo != null)
        {
            if (transform.position.x < enemigo.transform.position.x)
            {
                puntaje += 10;
                enemigo = null;
            }
        }

        if(vidas <= 0)
        {
            SceneManager.LoadScene("GAMEOVER");
        }

        UI_puntaje.text = "Puntaje: " + puntaje;
        UI_vidas.text = "Vidas restantes: " + vidas;
	}

    private void OnTriggerEnter(Collider other)
    {
        GameObject otro = other.gameObject;

        if(otro.tag == "Obstacle")
        {
            enemigo = otro;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        GameObject otro = other.gameObject;

        if (otro.tag == "Obstacle")
        {
            vidas -= 1;
            Destroy(otro);
        }
    }
}
