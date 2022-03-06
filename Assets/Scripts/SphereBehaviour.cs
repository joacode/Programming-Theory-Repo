using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SphereBehaviour : MonoBehaviour
{
    public GameObject box;

    private Vector3 posFixed;

    private Rigidbody sphereRb;

    private AudioSource source;

    [SerializeField] private float minSpeed = 2;
    [SerializeField] private float maxSpeed = 10;
    [SerializeField] private float torqueSpeed = 30;

    private Touch touch;

    private float speed;

    // Start is called before the first frame update
    void Start()
    {

        sphereRb = GetComponent<Rigidbody>();
        
        speed = Random.Range(minSpeed, maxSpeed);

        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        posFixed = new Vector3(0, 0, 0) - transform.position;

        if (gameObject.CompareTag("Sphere"))
        {
            sphereRb.AddTorque(RandomRotation() * Time.deltaTime * torqueSpeed, ForceMode.Impulse);
        }
        else if (gameObject.CompareTag("Hat"))
        {
            sphereRb.AddTorque(Vector3.up * Time.deltaTime * torqueSpeed, ForceMode.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.Space) /*|| touch.phase == TouchPhase.Began*/)
        {
            sphereRb.useGravity = true;
            sphereRb.velocity = sphereRb.velocity;
            source.Play();
            sphereRb.constraints = RigidbodyConstraints.None;
        }
        else if (sphereRb.useGravity == false)
        {
            sphereRb.AddForce(posFixed.normalized * Time.deltaTime * speed, ForceMode.Impulse);

            sphereRb.velocity = sphereRb.velocity - new Vector3(0, sphereRb.velocity.y, 0);
        }

        OutOfBounds();
    }

    Vector3 RandomRotation()
    {
        Vector3 torq = new Vector3(Random.Range(0f, 10f), Random.Range(0f, 10f), Random.Range(0f, 10f));

        return torq;
    }

    void OutOfBounds()
    {
        if (transform.position.x < -21 || transform.position.x > 21)
        {
            Destroy(gameObject);
        }
        else if (transform.position.z < -21 || transform.position.z > 21)
        {
            Destroy(gameObject);
        }
    }
    

}
