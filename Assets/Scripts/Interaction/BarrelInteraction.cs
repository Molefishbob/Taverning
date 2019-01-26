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

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        if (_substance == Substance.Error) {
            _substance = Substance.Beer;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_actionOnGoing && _liquidPercentage > 0) {
            if (_timer.IsCompleted) {
                _liquidPercentage -= _percentageLossPerDrink;
                /// TODO: TELL PLAYER HE HAS ALCOHOL
            }
        }

        if (_liquidPercentage <= 0) {
            /// TODO: ACTIVATE DESTRUCTION OF BARREL
        } else if (_liquidPercentage <= 0.1f) {
            /// TODO: ACTIVATE WARNING MESSAGE
        }

    }

    protected override void InteractionStart()
    {
        ResetTimer();
        _actionOnGoing = true;
    }
}
