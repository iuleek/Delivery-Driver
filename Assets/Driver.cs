using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 300f;
    [SerializeField] float moveSpeed = 20f;
    [SerializeField] float slowSpeed = 15f ;
    [SerializeField] float boostSpeed = 30f;
    void Start()
    {
        
    }

    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
    }

    void OnTriggerEnter2D(Collider2D other) //for objects that we cand drive over
    {
        if (other.tag == "Boost")
        {
            moveSpeed = boostSpeed;
        }
    }

    void OnCollisionEnter2D(Collision2D collision) //for objects that we bump into
    {
        moveSpeed = slowSpeed;
    }
}

