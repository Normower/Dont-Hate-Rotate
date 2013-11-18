using UnityEngine;
using System.Collections;

public class AsteroidBoundary : MonoBehaviour {

    public Vector2 velocityFactorChange;

    void OnTriggerEnter2D(Collider2D asteroid)
    {
        //asteroid.transform.position = Vector3.Scale(asteroid.transform.position, velocityFactorChange);
        Destroy(asteroid.gameObject);
        AsteroidManager.Instance.AsteroidSpawn();
    }
}
