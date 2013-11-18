using UnityEngine;
using System.Collections;

public class ShipBody : MonoBehaviour {

    private Vector2 cameraPos;
    private Vector2 screenSize;

    private float xBoundaryMin;
    private float xBoundaryMax;
    private float yBoundaryMin;
    private float yBoundaryMax;

    private float shipSizeOffset;

	// Use this for initialization
	void Start () {
        cameraPos = new Vector2(Camera.main.transform.position.x, Camera.main.transform.position.y);
        screenSize = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        shipSizeOffset = transform.lossyScale.x;

        xBoundaryMin = cameraPos.x - (screenSize.x + shipSizeOffset);
        xBoundaryMax = cameraPos.x + (screenSize.x + shipSizeOffset);
        yBoundaryMin = cameraPos.y - (screenSize.y + shipSizeOffset);
        yBoundaryMax = cameraPos.y + (screenSize.y + shipSizeOffset);
	}
	
	// Update is called once per frame
	void Update () {
        WrapPlayerPosition();
	}

    private void WrapPlayerPosition()
    {
        Vector2 currentPos = transform.position;

        if (currentPos.x > xBoundaryMax)
            transform.position = new Vector2(xBoundaryMin, currentPos.y);
        else if (currentPos.x < xBoundaryMin)
            transform.position = new Vector2(xBoundaryMax, currentPos.y);

        if (currentPos.y > yBoundaryMax)
            transform.position = new Vector2(currentPos.x, yBoundaryMin);
        else if (currentPos.y < yBoundaryMin)
            transform.position = new Vector2(currentPos.x, yBoundaryMax);
    }
}
