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
    private GameObject[] _Seats;
    private bool[] _SeatTaken;

    // Start is called before the first frame update
     public override void Start()
    {
        base.Start();
        _Seats = new GameObject[_chairCount];
        _SeatTaken = new bool[_chairCount];
        for (int i = 0; i < _chairCount; i++)
        {
            _Seats[i] = transform.GetChild(i + 1).gameObject;
            _SeatTaken[i] = false;
        }
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

    public override void InteractionInterrupt(PlayerInteraction player)
    {
        _timer.Stop();
    }

    public Transform GetFreeSeat()
    {
        for(int i = 0; i < _chairCount; i++)
        {
            if (!_SeatTaken[i])
            {
                _SeatTaken[i] = true;
                return _Seats[i].transform;
            }
        }
        return null;
    }
}
