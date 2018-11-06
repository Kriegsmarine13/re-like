using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemyController : MonoBehaviour {
    
    public float speed = 1.5f;
    public int aggroDistance;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        var movespeed = speed * Time.deltaTime;
        var player = GameObject.FindWithTag("Player");

        float distanceBetweenPlayerAndEnemy = Vector3.Distance(player.transform.position, transform.position);

        //Debug.Log("Distance to Player:" + distanceBetweenPlayerAndEnemy);

        if (distanceBetweenPlayerAndEnemy < aggroDistance)
        {
            //Debug.Log("Start moving!");
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, movespeed);
        }
    }
}
