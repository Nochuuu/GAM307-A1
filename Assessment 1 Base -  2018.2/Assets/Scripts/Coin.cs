using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour 
{

    [SerializeField]
    private float rotateSpeed = 1.0f; // In rotations per second

    [SerializeField]
    private float floatSpeed = 0.5f; // In cycles (up and down) per second

    [SerializeField]
    private float movementDsitance = 0.5f; // The maximum distance the coin can move up and down

    [SerializeField]
    private GameObject collectCoinEffect; // The particle effect we will instantiate on Pickup 

    private float startingY;
    private bool isMovingUp = true;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Pickup();
        }
    }

    private void Pickup()
    {
        GameManager.Instance.NumCoins++;
        Instantiate(collectCoinEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    // Use this for initialization
    void Start () 
    {
        startingY = transform.position.y;

        transform.Rotate(transform.up, Random.Range(0f, 360f));
    }

    void Update()
    {
        //Spin();
        //Float();
    }

    private void Spin()
    {
		while (true)
        {
            transform.Rotate(transform.up, 360 * rotateSpeed * Time.deltaTime);
        }
	}

    private void Float()
    {
        while (true)
        {
            float newY = transform.position.y + (isMovingUp ? 1 : -1) * movementDsitance * floatSpeed * Time.deltaTime;

            if (newY > startingY + movementDsitance)
            {
                newY = startingY + movementDsitance;
                isMovingUp = false;
            }
            else if (newY < startingY)
            {
                newY = startingY;
                isMovingUp = true;
            }

            transform.position = new Vector3(transform.position.x, newY, transform.position.z);
        }
    }
}
