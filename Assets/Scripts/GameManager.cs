using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public float _Gold;
    public GameObject[] _Tables = new GameObject[4];
    public GameObject[] _CustomersToSpawn = new GameObject[5];
    public GameObject _SpawnPoint;
    public List<GameObject> _SpawnedCustomers;
    public bool paused = false;
    public float _SpawnTimer = 1;
    private float _Timer = 0;
    
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one GameManager in the scene");
        }
        else
        {
            instance = this;
        }
        _Gold = 0;
        _SpawnedCustomers = new List<GameObject>();
        DontDestroyOnLoad(transform.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (!paused)
        {
            _Timer += Time.deltaTime;
            if (_Timer >= _SpawnTimer)
            {
                _Timer = 0;
                SpawnCustomer();
            }
        }
    }

    void SpawnCustomer()
    {
        int CustomerNumber = Random.Range(0, 5);
        GameObject _JustSpawned = Instantiate(_CustomersToSpawn[CustomerNumber]);
        _JustSpawned.transform.position = _SpawnPoint.transform.position;
        _JustSpawned.GetComponent<CustomerAI>().MoveToState(GetSeat(_JustSpawned));
        _SpawnedCustomers.Add(_JustSpawned);
    }
    void DespawnCustomer(GameObject customer)
    {
        _SpawnedCustomers.Remove(customer);
    }

    public Transform GetSeat(GameObject customer)
    {
        Transform chair = null;
        for(int a = 0; a < _Tables.Length;a++) {
            chair = _Tables[a].GetComponent<TableInteraction>().GetFreeSeat(customer);
            if (chair != null) {
                return chair;
            }
        }
        return chair;
    }
}
