using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatBehaviour : SphereBehaviour
{
    // INHERITANCE
    // POLYMORPHISM
    public override void TorqueAddition()
    {
        sphereRb.AddTorque(Vector3.up * Time.deltaTime * torqueSpeed, ForceMode.Impulse);
    }

    public override void Update()
    {
        posFixed = Direction();

        TorqueAddition();

        GravityHandler();

        OutOfBounds();
    }
    
}
