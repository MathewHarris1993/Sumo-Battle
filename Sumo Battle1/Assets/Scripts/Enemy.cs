using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    //variables
    public float enemySpeed = 2.5f;
    private Rigidbody enemyRb;
    private GameObject player;


    // Start is called before the first frame update
    void Start()
    {

        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");


    }

    // Update is called once per frame
    void Update()
    {
        //enemy vector
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;

        //use vector to chase player
        enemyRb.AddForce(lookDirection * enemySpeed);

        if(transform.position.y < -10)
        {
            Destroy(gameObject);

        }

    }
}
