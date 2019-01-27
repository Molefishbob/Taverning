using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterInteraction : GenericInteraction
{
    public CustomerAI _customer;
    public PlayerInteraction _player;
    public CounterSeat _counterSeat;
    public AudioClip _money;
    private AudioSource _audio;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        _counterSeat = transform.parent.gameObject.GetComponent<CounterSeat>();
        _audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_actionOnGoing && _customer != null)
        {
            if (_timer.IsCompleted && (int)_player._hands == _customer._desiredDrink)
            {
                _audio.PlayOneShot(_money);
                _customer._currentState = CustomerAI.state.Table;
                _player._hands = PlayerInteraction.hands.Empty;
                _customer.MoveToState(GameManager.instance.GetSeat(_customer.gameObject));
                _counterSeat.CustomerLeave();
                _actionOnGoing = false;
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
        _actionOnGoing = false;
        _timer.Stop();
    }
}
