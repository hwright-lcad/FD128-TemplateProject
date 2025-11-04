using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public Orientation orientation;
    private Quaternion closedRotation;
    private Quaternion openRotation;
    private Quaternion targetRotation;

    public float rotationSpeed;

    private bool isOpen = false;
    private bool isMoving = false;
    private Quaternion newAngle;
    
    public enum Orientation
    {
        Inward,
        Outward
    }
    // Start is called before the first frame update
    void Start()
    {
        closedRotation = transform.localRotation;

        Vector3 euler = closedRotation.eulerAngles;

        if (orientation == Orientation.Inward)
        {
            openRotation = Quaternion.Euler(euler.x, euler.y - 90f, euler.z);
        }           
        else
        {
            openRotation = Quaternion.Euler(euler.x, euler.y + 90f, euler.z);
        }
          
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            if (isOpen)
            {
                targetRotation = openRotation;
            }
            else
            {
                targetRotation = closedRotation;
            }
            transform.localRotation = Quaternion.RotateTowards(transform.localRotation,targetRotation, rotationSpeed * Time.deltaTime * 100f);

            if (Quaternion.Angle(transform.localRotation, targetRotation) < 0.1f)
            {
                transform.localRotation = targetRotation;
                isMoving = false;
            }
        }

    }

    public void Interact()
    {
        if (!isMoving)
        {
            isOpen = !isOpen;
            isMoving = true;
        }
    }


}
