using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public enum hands {
        Empty = 0,
        Beer = 1,
        Mead = 2,
        Wine = 3
    }
    const int InteractableObject = 8;
    public hands _hands;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D other) {
        if (other.gameObject.layer == InteractableObject) {
            other.GetComponent<GenericInteraction>().InteractionStart(this);
        }
    }
}
