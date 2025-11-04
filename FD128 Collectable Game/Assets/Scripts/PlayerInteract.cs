using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public float interactDistance;
    public TMP_Text interactText;
    // Start is called before the first frame update
    void Start()
    {
        interactText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        CheckForInteractable();
        Interact();
    }

    public void CheckForInteractable()
    {
        RaycastHit hit;
        if (Physics.Raycast(this.transform.position, this.transform.forward, out hit, interactDistance))
        {
            if (hit.collider.CompareTag("Door"))
            {
                if (interactText != null)
                {
                    interactText.text = "E";
                }
            }
            else
            {
                interactText.text = "";
            }
        }
        else
        {
            interactText.text = "";
        }
    }
    public void Interact()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("pressed e");
            RaycastHit hit;
            if (Physics.Raycast(this.transform.position, this.transform.forward, out hit, interactDistance))
            {
                Debug.Log(hit.collider.name);
                if (hit.collider.CompareTag("Door"))
                {
                    Debug.Log("hit door");
                    hit.collider.gameObject.GetComponent<DoorOpen>().Interact();
                }
                else
                {
                    Debug.Log("No interactable found");
                }
            }
        }

    }



    }
