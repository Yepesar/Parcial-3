using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaculoHorizontal : MonoBehaviour {

    [SerializeField]
    private float velocidad = 5;

	void Update ()
    {
        Moverse();
	}

    private void Moverse()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x + 1, transform.position.y, transform.position.z), velocidad * Time.deltaTime);
    }
}
