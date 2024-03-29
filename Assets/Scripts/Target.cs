using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{/// <summary>
/// all the variables with the set perameters
/// </summary>
    private Rigidbody targetRb;
    private GameManager gameManager;
    private float minSpeed = 12;
    private float maxSpeed = 14;
    private float maxTorque = 10;
    private float xRange = 6;
    private float ySpawnPos = -4;

    public int pointValue;
    public ParticleSystem explosionParticle;





    // Start is called before the first frame update
    void Start()
    {

        targetRb = GetComponent<Rigidbody>();// accessing the GameObjects Rigidbody
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        targetRb.AddForce(RandomForce(), ForceMode.Impulse); // applying Force randomly to the object
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse); // applying that force on all three axis

        transform.position = RandomSpawnPos(); //spawn in random position
    }

    // Update is called once per frame
    void Update()
    {

    }
    /// <summary>
    /// These are all the methods created to Destroy the objects apply the diffrent types of force and positions
    /// </summary>
    private void OnMouseDown() //function
    {

        if (gameManager.isGameActive)

        {
            Destroy(gameObject);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            gameManager.UpdateScore(pointValue);
        }
    }
    /// <summary>
    /// looking for a good game object to hit the sensor , when it does it will stop the game
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {

        if (!gameObject.CompareTag("Bad"))

        {
            gameManager.GameOver();

        }
    }
    // creating the method that will oput the random force and torque and range for all the game objects

    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }
    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }
}
