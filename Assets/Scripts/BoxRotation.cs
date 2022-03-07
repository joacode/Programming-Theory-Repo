using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxRotation : MonoBehaviour
{

    [SerializeField] private int rotSpeed = 40;

    void FixedUpdate()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * rotSpeed);
    
    }
}
