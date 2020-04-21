using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carMovement : MonoBehaviour
{
    public Vector3 velocity = Vector3.zero;
    public Vector3 acceleration = Vector3.zero;
    public Vector3 force = Vector3.zero;

    public float mass = 1.0f;

    public float maxSpeed = 5;
    public float maxForce = 10;

    public float speed = 0;

    public bool seekEnabled = false;
    public Vector3 target;
    Transform targetTransform;

    [Range(0.0f, 10.0f)]
    public float banking = 0.1f;

    public GameObject choosenTrafficLight;

    public createTrafficLights trafficLights;
    private trafficLightAI colorLight;


    public void randomTrafficLight()
    {
        choosenTrafficLight = trafficLights.Cylinders[Random.Range(0, trafficLights.Cylinders.Count)];
        colorLight = choosenTrafficLight.GetComponent<trafficLightAI>();


        // colorLight = choosenTrafficLight.GetComponent<trafficLightAI>();
    }


    public void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position + acceleration);

        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position + velocity);

    }

    Vector3 Seek(Vector3 target)
    {
        Vector3 toTarget = target - transform.position;
        Vector3 desired = toTarget.normalized * maxSpeed;

        return desired - velocity;
    }

    public Vector3 CalculateForce()
    {
        Vector3 force = Vector3.zero;
        if (seekEnabled)
        {
            force += Seek(target);
        }

        return force;
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(target, transform.position);

        if (dist < 1f)
        {
            randomTrafficLight();
        }

        if (colorLight.isGreen == true)
        {
            target = choosenTrafficLight.transform.position;
        }
        else
        {
            randomTrafficLight();
        }


        if (targetTransform != null)
        {
            target = targetTransform.position;
        }

        force = CalculateForce();
        acceleration = force / mass;
        velocity += acceleration * Time.deltaTime;

        transform.position += velocity * Time.deltaTime;
        speed = velocity.magnitude;

        if (speed > 0)
        {
            Vector3 tempUp = Vector3.Lerp(transform.up, Vector3.up + (acceleration * banking), Time.deltaTime * 3.0f);
            transform.LookAt(transform.position + velocity, tempUp);

            transform.forward = velocity;
        }

    }
}
