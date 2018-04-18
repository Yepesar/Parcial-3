using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstaculo : MonoBehaviour {

	private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reciclador")
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "Obstacle")
        {
            Destroy(other.gameObject);
        }
   
    }
}
