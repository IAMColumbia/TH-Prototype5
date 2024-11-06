using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Target : MonoBehaviour
{
    private float _minSpeed = 12; 
    private float _maxSpeed = 16; 
    private float _maxTorque = 10; 
    private float _xRange = 4; 
    private float _ySpawnPos = -6;
    private Rigidbody _targetRb;

    // Start is called before the first frame update
    void Start()
    {
        _targetRb = GetComponent<Rigidbody>();
        _targetRb.AddForce(RandomForce(), ForceMode.Impulse); 
        _targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse); 
        transform.position = RandomSpawnPos();
    }

    // Update is called once per frame
    void Update()
    {

    }
    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(_minSpeed, _maxSpeed);
    }
    float RandomTorque()
    {
        return Random.Range(-_maxTorque, _maxTorque);
    }
    Vector3 RandomSpawnPos()
    { 
        return new Vector3(Random.Range(-_xRange, _xRange), _ySpawnPos); 
    }
}

