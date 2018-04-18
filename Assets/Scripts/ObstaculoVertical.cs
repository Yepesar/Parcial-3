using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaculoVertical : MonoBehaviour {

    [SerializeField]
    private float velocidad = 15;

    private Rigidbody rb;
    private bool saltar = false;

	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(saltar)
        {
            Saltar();
            saltar = false;
        }
	}

    private void Saltar()
    {
        Vector3 direccion = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z) - transform.position;
        direccion.Normalize();
        rb.AddForce(direccion * velocidad, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision other)
    {
        saltar = true;
    }
}
