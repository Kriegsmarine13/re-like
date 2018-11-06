using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {
    GameObject gameObject;
    float speed = 3.0f;
    bool shootingMode = false;
    public int shootingRange = 10;

    // Use this for initialization
    void Start()
    {

    }
	
	// Update is called once per frame
	void Update () {
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * speed;
        RaycastHit hit;

        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);

        var weapon = GameObject.FindGameObjectWithTag("Weapon");
        //Debug.Log(shootingMode);

        //Shoot mode ready
        if (Input.GetKeyDown("z"))
        {
            Debug.Log("Shooting mode");
            shootingMode = true;
            //Debug.Log(shootingMode);
            speed = 0f;
            weapon.transform.Rotate(0, 0, 45);
        }

        //Shoot
        if (Input.GetKey("z") && Input.GetKeyDown("c"))
        {
            //Debug.Log("POW!");
            Vector3 forward = transform.TransformDirection(Vector3.forward);
            Vector3 shootLine = forward * shootingRange;
            if (Physics.Raycast(transform.position, forward, out hit))
            {
                Debug.Log("Object hit!");
                print(hit.collider);
            }
            Debug.DrawRay(transform.position, forward * shootingRange, Color.red, 600);
        }

        if (Input.GetKeyUp("z"))
        {
            shootingMode = false;
            speed = 3.0f;
            weapon.transform.Rotate(0, 0, -45);
        }
	}
}
