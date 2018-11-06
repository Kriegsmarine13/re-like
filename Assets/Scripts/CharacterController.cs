using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {
    GameObject gameObject;
    float speed = 3.0f;
    // Use this for initialization
    void Start()
    {

    }
	
	// Update is called once per frame
	void Update () {
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * speed;

        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);

        var weapon = GameObject.FindGameObjectWithTag("Weapon");

        if (Input.GetKeyDown("z"))
        {
            speed = 0f;
            weapon.transform.Rotate(0, 0, 45);
        }

        if (Input.GetKeyUp("z"))
        {
            speed = 3.0f;
            weapon.transform.Rotate(0, 0, -45);
        }
	}
}
