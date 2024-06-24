using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    private float forceAppliedTime = 3f;
    private bool launched = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void launch()
    {
        launched = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(launched && forceAppliedTime > 0f)
        {
            transform.GetComponent<Rigidbody>().AddForce(transform.forward * 50f);

            forceAppliedTime -= Time.deltaTime;
        }
    }
}
