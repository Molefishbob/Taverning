using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterInteraction : GenericInteraction
{
    public CustomerAI _customer;
    public PlayerInteraction _player;
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        if(_actionOnGoing && _customer != null)
        {
            if (_timer.IsCompleted && (int)_player._hands == _customer._desiredDrink)
            {
                _customer._currentState = CustomerAI.state.Table;
                _customer.MoveToState(GameManager.instance.GetSeat(_customer.gameObject));
            }
        }
    }

    public override void InteractionStart(PlayerInteraction player)
    {
        ResetTimer();
        _player = player;
        _actionOnGoing = true;
    }

    public override void InteractionInterrupt(PlayerInteraction player)
    {
        _timer.Stop();
    }
}
