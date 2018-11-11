using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandgunScript : MonoBehaviour {

    public int shootingRange = 10;
    public float pushBack = 1.4f;

    RaycastHit hit;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Shoot()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        //Vector3 shootLine = forward * shootingRange;
        if (Physics.Raycast(transform.position, forward, out hit, shootingRange))
        {
            Debug.Log("Object hit!");
            if (hit.collider.tag == "Enemy")
            {
                Debug.Log("tag is enemy");
                hit.transform.Translate(forward * pushBack);
            }
            print(hit.collider);
        }
        Debug.DrawRay(transform.position, forward * shootingRange, Color.red, 600);
    }
}
