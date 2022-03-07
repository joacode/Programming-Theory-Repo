using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SphereBehaviour : MonoBehaviour
{
    private GameObject box;

    public Vector3 posFixed;

    public Rigidbody sphereRb;

    private AudioSource source;

    private float minSpeed = 5;
    private float maxSpeed = 10;
    public float torqueSpeed = 30;

    //private Touch touch;

    private float speed;

    // Start is called before the first frame update
    public virtual void Start()
    {
        box = GameObject.Find("Pos0");

        sphereRb = GetComponent<Rigidbody>();
        
        speed = Random.Range(minSpeed, maxSpeed);

        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public virtual void Update()
    {

        posFixed = Direction();

        if (gameObject.CompareTag("Sphere"))
        {
            TorqueAddition();
        }

        GravityHandler();

        OutOfBounds();
    }

    public Vector3 Direction()
    {
        return new Vector3(0, 0, 0) - transform.position;
    }

    public void GravityHandler()
    {
        if (Input.GetKeyDown(KeyCode.Space) /*|| touch.phase == TouchPhase.Began*/)
        {
            sphereRb.useGravity = true;
            sphereRb.velocity = sphereRb.velocity;
            source.Play();
            sphereRb.constraints = RigidbodyConstraints.None;
            MainManager.Instance.sphereCounter--;
        }
        else if (sphereRb.useGravity == false)
        {
            sphereRb.AddForce(posFixed.normalized * Time.deltaTime * speed, ForceMode.Impulse);

            sphereRb.velocity = sphereRb.velocity - new Vector3(0, sphereRb.velocity.y, 0);
        }
    }

    Vector3 RandomRotation()
    {
        Vector3 torq = new Vector3(Random.Range(0f, 10f), Random.Range(0f, 10f), Random.Range(0f, 10f));

        return torq;
    }

    public virtual void TorqueAddition()
    {
        sphereRb.AddTorque(RandomRotation() * Time.deltaTime * torqueSpeed, ForceMode.Impulse);
    }

    public void OutOfBounds()
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
