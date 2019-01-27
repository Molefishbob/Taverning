using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TAMK.SpaceShooter;

public class CustomerAI : MonoBehaviour
{
    public enum state {
        Counter,
        Table,
        PassedOut
    }

    public state _currentState;
    const float _defaultValue = 0.15f;
    private const string Walking = "Walking";
    [Range(0,1)]
    public float _drunkessLevel;
    [Range(0,1)]
    public float _annoyanceLevel;
    [Tooltip("1: Beer\n2: Mead\n3: Wine")]
    public int _desiredDrink;
    [Range(0,1)]
    public float _annoyanceIncrease;
    [Range(0,1)]
    public float _drunknessIncrease;
    public float _passOutChange;
    private Timer _timer;
    private Timer _timer1;
	public float _turnSpeed;
	public float _moveSpeed;
    private Vector3 _center;
    private Transform _tm;
    private bool _moving;
    private bool _passingOut;
    private GameObject _myTable;
    private Animator _anim;
    public GameObject[] _bubbles;


    // Start is called before the first frame update
    void Awake()
    {
        _anim = GetComponent<Animator>();
        _timer = GetComponent<Timer>();
        _timer1 = GetComponent<Timer>();
        _desiredDrink = Random.Range(1,4);
        _passOutChange = _defaultValue * _desiredDrink;
    }

    // Update is called once per frame
    void Update()
    {
        if (_moving) {
            Vector3 dir = _tm.position - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);
            transform.Translate(Vector3.down * Time.deltaTime * _moveSpeed,Space.Self);
            if (Vector3.Distance(_tm.position,transform.position) <= 0.1f) {
                transform.position = _tm.position;
                _moving = false;

                if(_currentState == state.Counter)
                {
                    if (_desiredDrink == 1)
                    {
                        _bubbles[0].gameObject.SetActive(true);
                    }
                    else if (_desiredDrink == 2)
                    {
                        _bubbles[1].gameObject.SetActive(true);
                    }
                    else if (_desiredDrink == 3)
                    {
                        _bubbles[2].gameObject.SetActive(true);
                    }
                }

                _anim.SetBool(Walking, false);
                transform.rotation = _tm.rotation;
            }

        } else
        {
            StageActions();
        }


    }

    private void StageActions()
    {
        switch (_currentState)
        {
            case state.Counter:
                if (_timer1.IsCompleted)
                {
                    _annoyanceLevel += _annoyanceIncrease;
                    ResetTimer(_timer1);
                }
                if (_annoyanceLevel >= 1) {
                    _myTable.transform.GetChild(0).GetComponent<CounterSeat>().CustomerLeave();
                    GameManager.instance.GetSeat(gameObject);
                    _myTable.GetComponent<TableInteraction>()._currentState = TableInteraction.State.Fighting;
                }
                break;
            case state.Table:
                if (_timer1.IsCompleted)
                {
                    _drunkessLevel += _drunknessIncrease * _desiredDrink;
                    ResetTimer(_timer1);
                    if (_drunkessLevel >= 0.5f)
                    {
                        if (Random.Range(0f, 1f) <= _passOutChange)
                        {
                            PassOut();
                            _currentState = state.PassedOut;
                        }
                    }
                }
                break;
            case state.PassedOut:
                _zzz.SetActive(true);
                break;
        }
    }

    public void PassOut() {
        _passingOut = true;
        if (_myTable != null) {
            _myTable.GetComponent<TableInteraction>().IHaveFallenAndCantGetUp();
        }
    }

    public void GiveCorrectAlcohol() {
        if (_myTable != null) {
        _myTable.GetComponent<CounterSeat>().CustomerLeave();
        }
        GameManager.instance.GetSeat(gameObject);
    }

    public void MoveToState(Transform trans) {
        _anim.SetBool(Walking,true);
        _myTable = trans.parent.gameObject;

        foreach (GameObject bubble in _bubbles)
        {
            bubble.SetActive(false);
        }

        _center = trans.position;
        _tm = trans;
        _moving = true;
    }
    private void ResetTimer(Timer timer)
    {
        timer.Stop();
        timer.SetTime(.5f);
        timer.StartTimer();
    }
}

    private Animator _anim;
    public GameObject[] _bubbles;
    public GameObject _zzz;


    // Start is called before the first frame update
                if(_currentState == state.Counter)
                {
                    if (_desiredDrink == 1)
                    {
                        _bubbles[0].gameObject.SetActive(true);
                    }
                    else if (_desiredDrink == 2)
                    {
                        _bubbles[1].gameObject.SetActive(true);
                    }
                    else if (_desiredDrink == 3)
                    {
                        _bubbles[2].gameObject.SetActive(true);
                    }