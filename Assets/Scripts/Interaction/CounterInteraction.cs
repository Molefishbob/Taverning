using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterInteraction : GenericInteraction
{
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void InteractionStart(PlayerInteraction player)
    {
        ResetTimer();
        //_player = player;
        _actionOnGoing = true;
    }

    public override void InteractionInterrupt(PlayerInteraction player)
    {
        _timer.Stop();
    }
}
