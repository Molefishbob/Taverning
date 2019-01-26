using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TAMK.SpaceShooter;

public abstract class GenericInteraction : MonoBehaviour
{
    public float _actionTime;
    public Collider2D[] _colliders;
    protected Timer _timer;
    protected float _timeInteracted;
    protected bool _actionOnGoing;

    // Start is called before the first frame update
    public virtual void Start()
    {
        _timer = GetComponent<Timer>();
    }


    protected abstract void InteractionStart();

    protected void ResetTimer()
    {
        _timer.Stop();
        _timer.SetTime(_actionTime);
        _timer.StartTimer();
    }
}
