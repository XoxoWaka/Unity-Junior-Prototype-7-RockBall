using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private GameObject focalPoint;
    private float powerUpStrength = 15f;
    public float speed = 10f;
    public bool hasPowerUp = false;
    public GameObject powerUpdIndicator; //переменная для PowerUpdIndicator

    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("FocalPoint"); 
    }
    private void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");               
        playerRb.AddForce(focalPoint.transform.forward * forwardInput * speed);

        //чтоб PowerUpdIndicator следовал за игроком мы в каждом кадре приравниваем его позицию к позиции игрока
        powerUpdIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            hasPowerUp = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerUpCoroutine());
            powerUpdIndicator.SetActive(true); //делаем PowerUpdIndicator активным
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerUp)
        {            
            Rigidbody enemyRigidBody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.transform.position - transform.position;            
            enemyRigidBody.AddForce(awayFromPlayer * powerUpStrength, ForceMode.Impulse);
        }
    }

    IEnumerator PowerUpCoroutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerUp = false;
        powerUpdIndicator.SetActive(false); //PowerUpdIndicator выключаем когда закончилось время его действия 
    }
}
