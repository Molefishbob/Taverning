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
    RaycastHit2D _hit;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ShootLazer();
        if(IHIT) {
            _hit.transform.gameObject.GetComponent<GenericInteraction>().InteractionStart(this);
        } else {
            _hit.transform.gameObject.GetComponent<GenericInteraction>().InteractionInterrupt(this);
        }
    }

    void ShootLazer()
    {
        RaycastHit2D hit = Physics2D.CircleCast(transform.position, _CircleCastRadius, transform.up, 0, _InteractionLayer);
        if(hit.collider != null)
        {   
            _hit = hit;
            IHIT = true;
        } else
        {
            IHIT = false;
        }
    }
}
