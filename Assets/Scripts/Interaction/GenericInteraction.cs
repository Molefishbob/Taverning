using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GenericInteraction : MonoBehaviour
{
    public float _actionTime;
    public Collider2D[] _colliders;
    private float _timeInteracted;
    private bool _actionOnGoing;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_actionOnGoing)
        {
            
        }
    }

    protected abstract void Interaction();

    protected abstract void ChangeState(int state);
}
