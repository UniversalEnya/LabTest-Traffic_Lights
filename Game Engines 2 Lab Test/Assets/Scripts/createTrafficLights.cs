using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createTrafficLights : MonoBehaviour
{
    List<GameObject> Cylinders = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        cylindersCreatedInACircle();
    }

    public float radius = 10;

    void cylindersCreatedInACircle()
    {
        float theta = (Mathf.PI * 2.0f) / 10f;

        for (int i = 0; i < 10; i++)
        {
            Vector3 pos = new Vector3(Mathf.Sin(theta * i) * radius, 0, Mathf.Cos(theta * i) * radius);
            pos = transform.TransformPoint(pos);

            GameObject trafficL = GameObject.CreatePrimitive(PrimitiveType.Cylinder);

            trafficL.transform.position = pos;
            trafficL.transform.parent = this.transform;

            Cylinders.Add(trafficL);
        }

        foreach (GameObject go in Cylinders)
        {
            go.AddComponent<trafficLightAI>();
            go.AddComponent<Renderer>();
        }
    }
}
