using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Target : MonoBehaviour
{
    private Rigidbody _targetRb;
    private GameManager _gameManager;
    private float _minSpeed = 12; 
    private float _maxSpeed = 16; 
    private float _maxTorque = 10; 
    private float _xRange = 4; 
    private float _ySpawnPos = -2;
    public ParticleSystem _explosionParticle;
    public int _pointValue;

    /// <summary> 
    /// Initializes the target object's Rigidbody and GameManager component, 
    /// and applies random force and torque to the Rigidbody.
    /// Sets the initial position to a random spawn position. 
    /// </summary>
    void Start()
    {
        _targetRb = GetComponent<Rigidbody>();
        _gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        _targetRb.AddForce(RandomForce(), ForceMode.Impulse); 
        _targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse); 
        transform.position = RandomSpawnPos();
    }

    /// <summary> 
    /// Destroys the game object when it is clicked, 
    /// instantiates an explosion particle effect at the object's position, 
    /// and updates the game score by the object's point value.
    /// </summary>
    private void OnMouseDown() 
    {
        Destroy(gameObject);
        Instantiate(_explosionParticle, transform.position, _explosionParticle.transform.rotation);
        _gameManager.UpdateScore(_pointValue);
    }

    /// <summary> 
    /// Destroys the object when it fall out of view of the game. 
    /// </summary>
    private void OnTriggerEnter(Collider other) 
    { 
        Destroy(gameObject); 
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

