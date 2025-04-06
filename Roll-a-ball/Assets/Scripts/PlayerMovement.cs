using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro; 

public class PlayerMovement : MonoBehaviour
{
    public float speed = 0;
    public TextMeshProUGUI countText;


    public GameObject winText;
    public GameObject lostText; 
    public GameObject pickups;

    private Rigidbody rb;
    private int points; 
    private float movementX;
    private float movementY;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        points = 0; 
        SetCountText();
        winText.SetActive(false); 
        lostText.SetActive(false);
    }

    void SetCountText()
    {

        countText.text = "Count: " + points.ToString();
        if (points >= 12)
        {
            winText.SetActive(true);

        }

    }

    void HasLost()
    {
        lostText.SetActive(true );
        pickups.SetActive(false );



    }

    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            points++;
            SetCountText();
        }

        if (other.gameObject.CompareTag("Killer"))
        {
            HasLost(); 
        }

    }
}