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
    [SerializeField, Tooltip("UP,DOWN,LEFT,RIGHT")]
    private bool[] _CollidedSides = new bool[4];

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _vInputs.x = Input.GetAxis("Horizontal");
        _vInputs.y = Input.GetAxis("Vertical");

        ShootLaserz();
        Move();
    }

    void ShootLaserz()
    {
        // UP RAY
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x + _Rays[0].x, transform.position.y + _Rays[0].y), transform.right, _Rays[0].z);
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
        hit = Physics2D.Raycast(new Vector2(transform.position.x + _Rays[1].x, transform.position.y + _Rays[1].y), transform.right, _Rays[1].z);
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
        hit = Physics2D.Raycast(new Vector2(transform.position.x + _Rays[2].x, transform.position.y + _Rays[2].y), transform.up, _Rays[2].z);
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
        hit = Physics2D.Raycast(new Vector2(transform.position.x + _Rays[3].x, transform.position.y + _Rays[3].y), transform.up, _Rays[3].z);
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
        if(_vInputs != Vector2.zero)
        {
            transform.Translate(_vInputs * Time.deltaTime * _fSpeed);
        }
        if (_CollidedSides[0])
        {
            transform.Translate(-transform.up * Time.deltaTime * _fSpeed);
        }
        if (_CollidedSides[1])
        {
            transform.Translate(transform.up * Time.deltaTime * _fSpeed);
        }
        if (_CollidedSides[2])
        {
            transform.Translate(transform.right * Time.deltaTime * _fSpeed);
        }
        if (_CollidedSides[3])
        {
            transform.Translate(-transform.right * Time.deltaTime * _fSpeed);
        }
    }

}
