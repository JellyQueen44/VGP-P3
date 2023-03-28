using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float rpm;
    [SerializeField] private float horsePower = 0;
    [SerializeField] float turnSpeed = 30.0f;
    private float horizontalInput;
    private float forwardInput;
    private Rigidbody playerRb;

    [SerializeField] GameObject centerOfMass;
    [SerializeField] TextMeshProUGUI speedometerText;
    [SerializeField] TextMeshProUGUI rpmText;

    [SerializeField] List<WheelCollider> allWheels;
    [SerializeField] int wheelsOnGround;

    private bool Cam;
    public GameObject primaryCamera;
    public GameObject secondaryCamera;

    private void Start()
    {
        //Funky Components + CenterOfMass
        playerRb = GetComponent<Rigidbody>();
        playerRb.centerOfMass = centerOfMass.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Player Input for Shmovement
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        if (IsOnGround())
        {
            //Shmovement
            playerRb.AddRelativeForce(Vector3.forward * forwardInput * horsePower);
            transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * horizontalInput);

            //The Speed in Kilometers, just a better measuring system
            speed = Mathf.RoundToInt(playerRb.velocity.magnitude * 3.6f);
            speedometerText.SetText("Speed: " + speed + " kph");

            //RPM, Rotations, Idk why you need it but you do
            rpm = Mathf.Round((speed % 30) * 40);
            rpmText.SetText("RPM: " + rpm);
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            ChangeCamera();
        }

    }

    bool IsOnGround()
    {
        //Keep Those Legs On The Ground
        wheelsOnGround = 0;
        foreach (WheelCollider wheel in allWheels)
        {
            if (wheel.isGrounded)
            {
                wheelsOnGround++;
            }
        }
        if (wheelsOnGround == 4)
        {
            return true;
        } else
        {
            return false;
        }
    }

    void ChangeCamera()
    {
        if (!Cam)
        {
            Cam = true;
            primaryCamera.SetActive(true);
            secondaryCamera.SetActive(false);
        }
        else
        {
            Cam = false;
            secondaryCamera.SetActive(true);
            primaryCamera.SetActive(false);
        }
    }
}
