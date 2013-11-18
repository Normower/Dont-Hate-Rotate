using UnityEngine;
using System.Collections;

public class ThrusterControl : MonoBehaviour {

    public ThrusterID thrusterID;
    private float Power = 1.0f;
    private Thruster thrusterClass;

	// Use this for initialization
	void Start () {
        thrusterClass = ThrusterFactory.Get(thrusterID);
        renderer.material.color = thrusterClass.ThrusterColor;
	}
	
	// Update is called once per frame
	void Update () {
        FireThruster();	
	}

    void FireThruster()
    {
        if (thrusterClass.ThrusterUp)
            rigidbody2D.AddForce(transform.up * Power);
        if (thrusterClass.ThrusterDown)
            rigidbody2D.AddForce(-transform.up * Power);
    }

    void OnCollisionEnter2D (Collision2D asteroid)
    {
        if (asteroid.gameObject.renderer.material.color == thrusterClass.ThrusterColor)
        {
            print("SAME COLOUR COLLISION");
            Destroy(asteroid.gameObject);
        }
    }
}
