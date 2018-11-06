using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemyController : MonoBehaviour {
    
    public float speed = 1.5f;
    //public Transform thisEnemy;
    public int aggroDistance;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        //var z = Input.GetAxis("Vertical") * Time.deltaTime * speed;
        var movespeed = speed * Time.deltaTime;
        var player = GameObject.FindWithTag("Player");
        var playerX = player.transform.position.x;
        var playerY = player.transform.position.y;
        var playerZ = player.transform.position.z;

        float distanceBetweenPlayerAndEnemy = Vector3.Distance(player.transform.position, transform.position);

        Debug.Log("Distance to Player:" + distanceBetweenPlayerAndEnemy);

        if (distanceBetweenPlayerAndEnemy < aggroDistance)
        {
            Debug.Log("Start moving!");
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, movespeed);
            //var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
            //var z = Input.GetAxis("Vertical") * Time.deltaTime * speed;
            //transform.Rotate(playerX, x, playerZ);
            //transform.Translate(playerX, playerY, z);
        }
    }
}
