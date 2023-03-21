using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //private vehicles mechanics
    [SerializeField] float horsePower = 500f;
    [SerializeField] float turnSpeed = 25.0f;
    [SerializeField] float horizontalInput;
    [SerializeField] float forwardInput;
    private Rigidbody playerRb;
    [SerializeField] GameObject centerOfMass;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRb.centerOfMass = centerOfMass.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //The player input is here
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        
        //Car is movin! Wowie, this moves the car
        playerRb.AddRelativeForce(Vector3.forward * forwardInput * horsePower);
        // And this does, in fact, turn the car
        transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);
    }
}
