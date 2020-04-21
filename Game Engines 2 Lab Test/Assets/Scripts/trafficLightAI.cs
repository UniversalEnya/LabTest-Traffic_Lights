using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trafficLightAI : MonoBehaviour
{
    public bool isGreen = false;

    // Update is called once per frame
    void Start()
    {
        float startingLight = Random.Range(1, 9);

        if( startingLight < 4)
        {
            StartCoroutine(greenLight());
        }
        else if (startingLight >=4 && startingLight < 7)
        {
            StartCoroutine(yellowLight());
        }
        else if (startingLight >= 7)
        {
            StartCoroutine(redLight());
        }
    }

    public IEnumerator greenLight()
    {

        GetComponent<Renderer>().material.color = Color.green;
        isGreen = true;

        yield return new WaitForSeconds(Random.Range(5f, 10f));

        StartCoroutine(yellowLight());
    }

    public IEnumerator yellowLight()
    {
        GetComponent<Renderer>().material.color = Color.yellow;
        isGreen = false;

        yield return new WaitForSeconds(4f);

        StartCoroutine(redLight());
    }

    public IEnumerator redLight()
    {
        GetComponent<Renderer>().material.color = Color.red;
        isGreen = false;

        yield return new WaitForSeconds(Random.Range(5f, 10f));

        StartCoroutine(greenLight());
    }
}
