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
    public hands _hands;
    public LayerMask _InteractionLayer;
    public float _CircleCastRadius = 0.25f;
    public bool IHIT;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ShootLazer();
    }

    void ShootLazer()
    {
        RaycastHit2D hit = Physics2D.CircleCast(transform.position, _CircleCastRadius, transform.up, 0, _InteractionLayer);
        if(hit.collider != null)
        {
            hit.transform.gameObject.GetComponent<GenericInteraction>().InteractionStart(this);
            IHIT = true;
        } else
        {
            IHIT = false;
        }
    }
}
