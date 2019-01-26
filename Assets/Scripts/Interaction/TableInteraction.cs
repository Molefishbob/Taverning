using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableInteraction : GenericInteraction
{
    public enum State
    {
        Error,
        Empty,
        Full,
        Fighting
    }

    public State _currentState;
    public int _chairCount;

    // Start is called before the first frame update
     public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        if (_actionOnGoing && _currentState == State.Fighting)
        {
            if (_timer.IsCompleted)
            {
                _currentState = State.Empty;
                _actionOnGoing = false;
            }
        }
        if (_currentState == State.Error)
        {
            _currentState = State.Empty;
        }
    }

    public override void InteractionStart(PlayerInteraction player)
    {
        ResetTimer();
        _actionOnGoing = true;
    }

    public void ChangeState(State state) {
        _currentState = state;
    }
}
