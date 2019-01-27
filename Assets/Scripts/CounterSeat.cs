using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterSeat : MonoBehaviour
{

    public CustomerAI _customer;
    private Collider2D _coll;
    private CounterInteraction _counterInteraction;
    // Start is called before the first frame update
    void Start()
    {
        _coll = GetComponent<BoxCollider2D>();
        _coll.enabled = false;
        _counterInteraction = transform.GetChild(0).gameObject.GetComponent<CounterInteraction>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool IsSpotFree() {
        if (_customer == null) {
            return true;
        } else {
            return false;
        }
    }
    
    public bool AddCustomer(CustomerAI customer) {

        if (_customer == null) {
            _customer = customer;
            _coll.enabled = true;
            return true;
        } else {
            return false;
        }
    }

    public void CustomerLeave() {
        _customer = null;
        _coll.enabled = false;
    }
}
