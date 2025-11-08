using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordPickup : MonoBehaviour
{
    public bool canPickup = false;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        canPickup = true;
    }

    public void OnTriggerExit(Collider other)
    {
        if (canPickup && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Sword picked up!");
            Destroy(gameObject);
        }
    }
}