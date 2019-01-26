using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float _fSpeed;
    [SerializeField]
    private Vector2 _vInputs;

    [Tooltip("UP,DOWN,LEFT,RIGHT")]
    public Vector3[] _Rays;
    [Tooltip("UP,DOWN,LEFT,RIGHT")]
    public bool[] _CollidedSides = new bool[4];
    public LayerMask _UnignoredLayersMovement;
    private Animator _anim;

    private void Awake()
    {
        _anim = gameObject.GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _vInputs.x = Input.GetAxis("Horizontal");
        _vInputs.y = Input.GetAxis("Vertical");
        if (_vInputs.x != 0 || _vInputs.y != 0)
        {
            _anim.SetBool("Walking", true);
        } else
        {
            _anim.SetBool("Walking", false);
        }

        ShootLaserz();
        RotatePlayer();
        Move();
    }

    void ShootLaserz()
    {
        // UP RAY
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x + _Rays[0].x, transform.position.y + _Rays[0].y), Vector2.right, _Rays[0].z, _UnignoredLayersMovement);
        if (hit.collider != null)
        {
            Debug.DrawLine(new Vector2(transform.position.x + _Rays[0].x, transform.position.y + _Rays[0].y), hit.point, Color.red);
            _CollidedSides[0] = true;
        } else
        {
            Debug.DrawLine(new Vector2(transform.position.x + _Rays[0].x, transform.position.y + _Rays[0].y), new Vector2(transform.position.x + _Rays[0].x + _Rays[0].z, transform.position.y + _Rays[0].y), Color.yellow);
            _CollidedSides[0] = false;
        }
        // BOTTOM
        hit = Physics2D.Raycast(new Vector2(transform.position.x + _Rays[1].x, transform.position.y + _Rays[1].y), Vector2.right, _Rays[1].z, _UnignoredLayersMovement);
        if (hit.collider != null)
        {
            Debug.DrawLine(new Vector2(transform.position.x + _Rays[1].x, transform.position.y + _Rays[1].y), hit.point, Color.red);
            _CollidedSides[1] = true;
        }
        else
        {
            Debug.DrawLine(new Vector2(transform.position.x + _Rays[1].x, transform.position.y + _Rays[1].y), new Vector2(transform.position.x + _Rays[1].x + _Rays[1].z, transform.position.y + _Rays[1].y), Color.yellow);
            _CollidedSides[1] = false;
        }
        // LEFT
        hit = Physics2D.Raycast(new Vector2(transform.position.x + _Rays[2].x, transform.position.y + _Rays[2].y), Vector2.up, _Rays[2].z, _UnignoredLayersMovement);
        if (hit.collider != null)
        {
            Debug.DrawLine(new Vector2(transform.position.x + _Rays[2].x, transform.position.y + _Rays[2].y), hit.point, Color.red);
            _CollidedSides[2] = true;
        }
        else
        {
            Debug.DrawLine(new Vector2(transform.position.x + _Rays[2].x, transform.position.y + _Rays[2].y), new Vector2(transform.position.x + _Rays[2].x, transform.position.y + _Rays[2].y + _Rays[2].z), Color.yellow);
            _CollidedSides[2] = false;
        }
        // RIGHT
        hit = Physics2D.Raycast(new Vector2(transform.position.x + _Rays[3].x, transform.position.y + _Rays[3].y), Vector2.up, _Rays[3].z, _UnignoredLayersMovement);
        if (hit.collider != null)
        {
            Debug.DrawLine(new Vector2(transform.position.x + _Rays[3].x, transform.position.y + _Rays[3].y), hit.point, Color.red);
            _CollidedSides[3] = true;
        }
        else
        {
            Debug.DrawLine(new Vector2(transform.position.x + _Rays[3].x, transform.position.y + _Rays[3].y), new Vector2(transform.position.x + _Rays[3].x, transform.position.y + _Rays[3].y + _Rays[3].z), Color.yellow);
            _CollidedSides[3] = false;
        }
    }

    void Move()
    {
        
        Vector2 tempMovement = _vInputs;
        if (_CollidedSides[0] && _vInputs.y > 0)
        {
            _vInputs.y = 0;
        }
        if (_CollidedSides[1] && _vInputs.y < 0)
        {
            _vInputs.y = 0;
        }
        if (_CollidedSides[2] && _vInputs.x < 0)
        {
            _vInputs.x = 0;
        }
        if (_CollidedSides[3] && _vInputs.x > 0)
        {
            _vInputs.x = 0;
        }
        if (_vInputs != Vector2.zero)
        {
            transform.Translate(_vInputs * Time.deltaTime * _fSpeed, Space.World);
        }
    }

    void RotatePlayer()
    {
        if(_vInputs != Vector2.zero)
        {
            Vector3 dir = new Vector3(_vInputs.x, _vInputs.y, 0);
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);
        }
        
    }

}
