using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    //variables
    private Rigidbody playerRb;
    public float speed = 5.0f;
    private GameObject focalPoint;
    public bool hasPowerUp = false;
    public float powerUpStrength = 20;
    public GameObject powerUpIndicator;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");

    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * speed * forwardInput);
        powerUpIndicator.transform.position = transform.position + new Vector3(0, -.5f, 0);


    }

   
    //power up 
    private void OnTriggerEnter(Collider Other)
    {
        if(Other.CompareTag("PowerUp"))
        {
            hasPowerUp = true;
            Destroy(Other.gameObject);
            StartCoroutine(PowerupCountdownroutine());
            powerUpIndicator.gameObject.SetActive(true);    

        }
    }

    //timer for powerup
    IEnumerator PowerupCountdownroutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerUp = false;
        powerUpIndicator.gameObject.SetActive(false);


    }
    //enemy hit w/powerup
    private void OnCollisionEnter(Collision collision)
    {

        if(collision.gameObject.CompareTag("Enemy") && hasPowerUp)
        {
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 away = (collision.gameObject.transform.position - transform.position);
            enemyRb.AddForce(away * powerUpStrength, ForceMode.Impulse);

        }
    }
}
