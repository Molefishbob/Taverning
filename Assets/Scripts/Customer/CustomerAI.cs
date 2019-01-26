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
    public Transform trans;
    private bool _moving;
    

    // Start is called before the first frame update
    void Start()
    {
        _timer = GetComponent<Timer>();
        _timer1 = GetComponent<Timer>();
        _desiredDrink = Random.Range(1,4);
        _passOutChange = _defaultValue * _desiredDrink;
        MoveToState(trans.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (_moving) {
            Vector3 dir = trans.position - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);
            transform.Translate(Vector3.down * Time.deltaTime * _moveSpeed,Space.Self);
            if (Vector3.Distance(trans.position,transform.position) <= 0.1f) {
                transform.position = trans.position;
                _moving = false;
                transform.rotation = trans.rotation;
            }

        } else {
            switch (_currentState) {
                case state.Counter:
                    if (_timer1.IsCompleted) {
                        _annoyanceLevel += _annoyanceIncrease;
                        ResetTimer(_timer1);
                    }
                    break;
                case state.Table:
                    if (_timer1.IsCompleted) {
                        _drunkessLevel += _drunknessIncrease * _desiredDrink;
                        ResetTimer(_timer1);
                    }
                    if (_drunkessLevel >= 0.5f) {
                        if (Random.Range(0,1) <= _passOutChange) {
                            _currentState = state.PassedOut;
                        }
                    }
                    break;
                case state.PassedOut:
                    /// TODO: PASSOUT
                    break;
            }
        }
    }

    public void MoveToState(Vector3 pos) {
        _center = pos;
        _moving = true;
    }
    private void ResetTimer(Timer timer)
    {
        timer.Stop();
        timer.SetTime(.5f);
    }
}
