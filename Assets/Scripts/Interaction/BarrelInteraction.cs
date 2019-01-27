using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelInteraction : GenericInteraction
{
    public enum Substance {
        Error,
        Beer,
        Mead,
        Wine
    }
    [Range(0,1)]
    public float _liquidPercentage;
    [Range(0,1)]
    public float _percentageLossPerDrink;
    public Substance _substance;
    private PlayerInteraction _player;
    private PlayerInteraction.hands _handEnum;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        if (_substance == Substance.Error) {
            _substance = Substance.Beer;
        }
        switch (_substance) {
            case Substance.Beer:
                _handEnum = PlayerInteraction.hands.Beer;
                break;
            case Substance.Mead:
                _handEnum = PlayerInteraction.hands.Mead;
                break;
            case Substance.Wine:
                _handEnum = PlayerInteraction.hands.Wine;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_actionOnGoing) {
            if (_timer.IsCompleted) {
                if (_player._hands == PlayerInteraction.hands.Empty || _player._hands != _handEnum) {
                    
                    _player._hands = _handEnum;
                    _actionOnGoing = false;
                }
            }
        }

        if (_liquidPercentage <= 0) {
            /// TODO: ACTIVATE DESTRUCTION OF BARREL
            /// TODO: ACTIVATE EMPTY BARREL WARNING MESSAGE
        } else if (_liquidPercentage <= 0.1f) {
            /// TODO: ACTIVATE WARNING MESSAGE
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
