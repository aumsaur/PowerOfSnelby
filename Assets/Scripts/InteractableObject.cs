using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractableObject : MonoBehaviour
{
    [SerializeField] private KeyCode interactKey = KeyCode.E;
    [SerializeField] private bool isInRange;

    protected Player player;

    protected virtual void Update()
    {
        if (isInRange)
        {
            if (Input.GetKeyDown(interactKey))
            {
                Interact();
            }
        }
    }

    public abstract void Interact();

    public virtual void changeInteractKey(KeyCode newKey)
    {
        interactKey = newKey;
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player = other.GetComponent<Player>();
            isInRange = true;
            Debug.Log("Player Enter");
            
            // Trigger
        }

    }

    protected virtual void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player = other.GetComponent<Player>();
            isInRange = true;
            Debug.Log("Player Stay");

            // Draw someting to let player know can be interact with
        }
    }

    protected virtual void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player = null;
            isInRange = false;
            Debug.Log("Player Exit");
        }
    }
}
