using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlterPlayerHealth : MonoBehaviour
{
    public int changeValue;
    public bool consumable;
    public Type type;
    public enum Type
    {
        Heal,
        Damage
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if(type == Type.Heal)
            {
                other.GetComponent<PlayerHealth>().Heal(changeValue);
                if (consumable)
                {
                    Destroy(this.gameObject);
                }
            }
            else
            {
                if (other.tag == "Player")
                {
                    other.GetComponent<PlayerHealth>().TakeDamage(changeValue);
                }
            }
        }
    }

}
