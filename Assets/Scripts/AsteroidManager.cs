using UnityEngine;
using System.Collections;

public class AsteroidManager : MonoBehaviour {

    private Vector2 cameraPos;
    private Vector2 spawnMax;
    private float spawnOffset = 2.5f;

    //private GameObject[] asteriodList;
    private int maxNoOfAsteroids = 20;
    private Color[] colorList = {
                                    new Color(0.8f,0.0f,0.0f),
                                    new Color(0.0f,0.8f,0.0f),
                                    new Color(0.0f,0.0f,0.8f),
                                    new Color(0.8f,0.8f,0.0f)
                                };

    public GameObject asteroidPrefab;
    private float velocityScale = 2.0f;

    public static AsteroidManager Instance;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);
    }

	// Use this for initialization
	void Start () {
        cameraPos = new Vector2(Camera.main.transform.position.x, Camera.main.transform.position.y);
        spawnMax = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        //asteriodList = new GameObject[maxNoOfAsteroids];

        InitialSpawn();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private bool RandomBool()
    {
        if (Random.value > 0.5)
            return true;
        else
            return false;
    }

    private Vector2 SpawnPosition()
    {
        bool spawnOnSide = RandomBool();
        if (spawnOnSide)
        {
            bool spawnOnLeft = RandomBool();
            if (spawnOnLeft)
                return new Vector2(cameraPos.x - (spawnMax.x + spawnOffset), Random.Range(cameraPos.y - spawnMax.y, cameraPos.y + spawnMax.y));
            else
                return new Vector2(cameraPos.x + (spawnMax.x + spawnOffset), Random.Range(cameraPos.y - spawnMax.y, cameraPos.y + spawnMax.y));
        }
        else
        {
            bool spawnOnBottom = RandomBool();
            if (spawnOnBottom)
                return new Vector2(Random.Range(cameraPos.x - spawnMax.x, cameraPos.x + spawnMax.x), cameraPos.y - (spawnMax.y + spawnOffset));
            else
                return new Vector2(Random.Range(cameraPos.x - spawnMax.x, cameraPos.x + spawnMax.x), cameraPos.y + (spawnMax.y + spawnOffset));
        }
    }

    private void InitialSpawn()
    {
        for (int i = 0; i < maxNoOfAsteroids; i++)
        {
            AsteroidSpawn();
        }
    }

    public void AsteroidSpawn ()
    {
        GameObject asteroid;
        asteroid = Instantiate(asteroidPrefab, SpawnPosition(), Quaternion.Euler(90, 0, 0)) as GameObject;
        asteroid.renderer.material.color = colorList[Random.Range(0, colorList.Length)];
        float sizeChange = Random.value;
        asteroid.transform.localScale = new Vector3(asteroid.transform.localScale.x + sizeChange, asteroid.transform.localScale.y, asteroid.transform.localScale.z + sizeChange);
        asteroid.rigidbody2D.velocity = Random.onUnitSphere * velocityScale;
    }
}
