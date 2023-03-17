using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //private vehicles mechanics
    [SerializeField] float speed = 5.0f;
    [SerializeField] float turnSpeed = 25.0f;
    [SerializeField] float horizontalInput;
    [SerializeField] float forwardInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //The player input is here
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        
        //Car is movin! Wowie, this moves the car
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        // And this does, in fact, turn the car
        transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);
    }
}
