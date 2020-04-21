using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trafficLights : MonoBehaviour
{
    List<GameObject> Cylinders = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        CreateTrafficLights();
    }

    public float radius = 10;

    void CreateTrafficLights()
    {
        float theta = (Mathf.PI * 2.0f) / 10f;

        for (int i = 0; i < 10; i++)
        {
            Vector3 p = new Vector3(Mathf.Sin(theta * i) * radius, 0, Mathf.Cos(theta * i) * radius);
            p = transform.TransformPoint(p);
            Quaternion q = Quaternion.AngleAxis(theta * i * Mathf.Rad2Deg, Vector3.up);
            q = transform.rotation * q;

            GameObject trafficL = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            trafficL.transform.SetPositionAndRotation(p, q);
            trafficL.transform.parent = this.transform;

            Cylinders.Add(trafficL);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
