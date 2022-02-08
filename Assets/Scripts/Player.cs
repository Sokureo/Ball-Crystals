using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float BounceSpeed;
    private Rigidbody componentRigidbody;
    Vector3 tempVect = new Vector3(0, 0, 1);
    public float Speed;
    private Vector3 _previousMousePosition;
    public int Score = 0;
    public GameObject Loss;
    public GameObject GameScore;
    public Player Controls;

    void Start()
    {
        componentRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        tempVect = tempVect.normalized * Speed * Time.deltaTime;
        componentRigidbody.MovePosition(transform.position + tempVect);

        if (Input.GetMouseButton(0))
        {

            Vector3 delta = Input.mousePosition - _previousMousePosition;
            delta = delta.normalized * Speed * Time.deltaTime;
            Vector3 newPosition = new Vector3(transform.position.x + delta.x, transform.position.y, transform.position.z + tempVect.z);
            componentRigidbody.MovePosition(newPosition);
        }
        _previousMousePosition = Input.mousePosition;
    }

    public void Bounce()
    {
        componentRigidbody.velocity = new Vector3(0, BounceSpeed, 0);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "crystal")
        {
            Score++;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "bad")
        {
            Controls.enabled = false;
            componentRigidbody.velocity = Vector3.zero;
            Loss.SetActive(true);
            GameScore.SetActive(false);
        }
    }
}
