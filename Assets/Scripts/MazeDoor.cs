using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeDoor : Door
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    public override void Interact()
    {
        
    }

    protected override void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player = other.GetComponent<Player>();
            // do something about player
        }
    }

    protected override void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player = other.GetComponent<Player>();
            // do something about player
        }
    }
}
