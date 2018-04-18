using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField]
    private float velocidad_movimiento;
    [SerializeField]
    private float velocidad_salto;

    private Rigidbody rb;
    private bool saltar = false;

	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
       if(Input.GetKey(KeyCode.D))
        {
            Moverse(-1);
        }

        if (Input.GetKey(KeyCode.A))
        {
            Moverse(1);
        }

        if (Input.GetKeyDown(KeyCode.Space) && saltar)
        {
            Saltar();
            saltar = false;
        }
	}

    private void Moverse(int direccion)
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x + direccion,transform.position.y,transform.position.z),velocidad_movimiento * Time.deltaTime);
    }

    private void Saltar()
    {
        Vector3 direccion = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z) - transform.position;
        direccion.Normalize();
        rb.AddForce(direccion * velocidad_salto, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision other)
    {
        saltar = true;
    }
}
