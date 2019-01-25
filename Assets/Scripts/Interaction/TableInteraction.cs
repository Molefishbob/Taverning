using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableInteraction : GenericInteraction
{
    public enum State
    {
        Empty,
        Full,
        Fighting
    }

    public State _currentState;
    public int _chairCount;

    // Start is called before the first frame update
     void Start()
    {
        
    }

    protected override void Interaction()
    {
        throw new System.NotImplementedException();
    }

    protected override void ChangeState(int state)
    {
        throw new System.NotImplementedException();
    }
}
