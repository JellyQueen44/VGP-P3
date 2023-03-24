using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TrailRenderer), typeof(BoxCollider))]

public class ClickAndDrag : MonoBehaviour
{
    private GameManager gameManager;
    private Camera camera;

    private Vector3 mousePos;
    private TrailRenderer trail;
    private BoxCollider col;

    private bool swiping = false;

    // Start is called before the first frame update
    void Awake()
    {
        camera = Camera.main;
        trail = GetComponent<TrailRenderer>();
        col = GetComponent<BoxCollider>();

        trail.enabled = false;
        col.enabled = false;

        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGameActive)
        {
            //Just Controls Swiping, lots of If
            if (Input.GetMouseButtonDown(0))
            {
                swiping = true;
                UpdateComponents();
            }
            else if (Input.GetMouseButtonUp(0))
            {
                swiping = false;
                UpdateComponents();
            }

            if (swiping)
            {
                UpdateMousePosition();
            }
        }
    }

    void UpdateMousePosition()
    {
        mousePos = camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y, 10.0f));
        transform.position = mousePos;
    }

    void UpdateComponents()
    {
        //On and Off switch
        trail.enabled = swiping;
        col.enabled = swiping;
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<Target>())
        {
            collision.gameObject.GetComponent<Target>().DestroyTarget();
        }
    }

}
