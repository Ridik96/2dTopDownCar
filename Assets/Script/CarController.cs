using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [Header("Car Component")]
    public Rigidbody2D car;

    [Header("Car Setings")]
    public float accelerationForc;
    public float turnForce;
    public float driftFactor;
    public LayerMask mask;

    public float CarSpeed => car.velocity.magnitude;

    private void FixedUpdate()
    {
        DriftReduction();

        TurnFactor();

        if(Input.GetKey(KeyCode.W))
        {
            Acceleration(Vector2.up);
        }
        else if  (Input.GetKey(KeyCode.S))
        {
            Acceleration(-Vector2.up);
        }
        
    }
    
    private void TurnFactor()
    {
        float minimumSpeedToTurn = (car.velocity.magnitude / 8);
        minimumSpeedToTurn = Mathf.Clamp01(minimumSpeedToTurn);

        car.AddTorque(Input.GetAxis("Horizontal") * turnForce  * minimumSpeedToTurn);
    }

    private void DriftReduction()
    {
        Vector2 forwardVelocity = transform.up * Vector2.Dot(car.velocity, transform.up);
        Vector2 driftVelocity = transform.right * Vector2.Dot(car.velocity, transform.right);

        car.velocity = forwardVelocity + driftVelocity * driftFactor;
    }

    private void Acceleration(Vector2 direction)
    {
        car.AddRelativeForce(direction * accelerationForc * 10,ForceMode2D.Force);
    }
}
