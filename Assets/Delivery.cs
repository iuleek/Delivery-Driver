using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField] Color32 noPackageColor = new Color32(1, 1, 1, 1);

    [SerializeField] float destroyDelay = 0.5f;

    bool hasPackage;

    SpriteRenderer spriteRenderer; //For acces sprite detail such as colour

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); 
    }
    void OnCollisionEnter2D(Collision2D other) //when we bump into trees/houses/rocks
    {
        Debug.Log("Ouch!");
    }

    void OnTriggerEnter2D(Collider2D other) //for objects that we cand drive over
    {
        if (other.tag == "Package" && !hasPackage)
        {
            Debug.Log("Package picked up.");
            hasPackage = true;
            spriteRenderer.color = hasPackageColor; // line 14 use
            Destroy(other.gameObject, destroyDelay);
     
        }
        
        if(other.tag == "Customer" && hasPackage)
        {
            Debug.Log("Package delivered to the customer.");
            hasPackage = false;
            spriteRenderer.color = noPackageColor; //line 14 use
        }
    }
}
