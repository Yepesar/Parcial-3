using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creador : MonoBehaviour {

    [SerializeField]
    private GameObject obstaculo_estatico01;
    [SerializeField]
    private GameObject obstaculo_estatico02;
    [SerializeField]
    private GameObject obstaculo_horizontal;
    [SerializeField]
    private GameObject obstaculo_vertical;
    [SerializeField]
    private GameObject suelo01;
    [SerializeField]
    private GameObject Player;
    [SerializeField]
    private GameObject puntos_de_origen;
    [SerializeField]
    private int cadencia_creacion = 35;

   
    private GameObject suelo02;
    private int contador = 0;
    private int contador_destruir = 0;
    private bool crear = false;
   
    // Use this for initialization
    void Awake ()
    {
        suelo02 = Instantiate(suelo01, new Vector3(suelo01.transform.position.x - 17, suelo01.transform.position.y, suelo01.transform.position.z), Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update ()
    {

        if (Player.transform.position.x <= suelo02.transform.position.x + 7 )
        {
            Mover_Suelo01();         
        }

        if (Player.transform.position.x <= suelo01.transform.position.x + 7)
        {
            Mover_Suelo02();        
        }

        //Contador crear

        contador += 1;

        if (contador >= cadencia_creacion)
        {
            contador = 0;
            if (crear)
            {
                CrearObstaculo();
            }
        }

        //Validar pos player

       if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {
            crear = true;
        }

        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            crear = false;
        }



    }

    private void Mover_Suelo01()
    {
        suelo01.transform.position = new Vector3(suelo02.transform.position.x - 17, suelo02.transform.position.y, suelo02.transform.position.z);
        
    }

    private void Mover_Suelo02()
    {
        suelo02.transform.position = new Vector3(suelo01.transform.position.x - 17, suelo01.transform.position.y, suelo01.transform.position.z);
        
    }

    private void CrearObstaculo()
    {
        float num = Random.Range(1,5);
        

        if(num < 2 && num >= 1 ) //Obstaculo estandar #1
        {
            GameObject clon_obs_est01 = Instantiate(obstaculo_estatico01, puntos_de_origen.transform.GetChild(Random.Range(0,1)).transform.position, Quaternion.identity);
        }

        if (num >= 2 && num < 3) //Obstaculo estandar #2
        {
            GameObject clon_obs_est02 = Instantiate(obstaculo_estatico02, puntos_de_origen.transform.GetChild(Random.Range(0, 1)).transform.position, Quaternion.identity);
        }

        if (num >= 3 && num < 4) //Obstaculo vertical 
        {
            GameObject clon_obs_ver = Instantiate(obstaculo_vertical, puntos_de_origen.transform.GetChild(Random.Range(0, 1)).transform.position, Quaternion.identity);
        }

        if (num >= 4 && num < 5) //Obstaculo horizontal 
        {
            GameObject clon_obs_horizontal = Instantiate(obstaculo_horizontal, puntos_de_origen.transform.GetChild(Random.Range(0, 1)).transform.position, Quaternion.identity);
        }

        Debug.Log("Se ha creado un obstaculo nuevo");
    }

   
}
