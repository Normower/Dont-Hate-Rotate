using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {

    private bool fireUpRed          = false;
    private bool fireDownRed        = false;
    private bool fireUpBlue         = false;
    private bool fireDownBlue       = false;
    private bool fireUpGreen        = false;
    private bool fireDownGreen      = false;
    private bool fireUpYellow       = false;
    private bool fireDownYellow     = false;

    public bool FireUpRed { get { return fireUpRed; } }
    public bool FireDownRed { get { return fireDownRed; } }
    public bool FireUpBlue { get { return fireUpBlue; } }
    public bool FireDownBlue { get { return fireDownBlue; } }
    public bool FireUpGreen { get { return fireUpGreen; } }
    public bool FireDownGreen { get { return fireDownGreen; } }
    public bool FireUpYellow { get { return fireUpYellow; } }
    public bool FireDownYellow { get { return fireDownYellow; } }

    public static InputManager Instance;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        GameControls();	
	}

    private void GameControls()
    {
        RedThrusterInput();
        BlueThrusterInput();
        GreenThrusterInput();
        YellowThrusterInput();
    }

    private void RedThrusterInput()
    {
        ThrusterControls(KeyCode.A, KeyCode.S, ref fireUpRed, ref fireDownRed);
    }

    private void BlueThrusterInput()
    {
        ThrusterControls(KeyCode.Z, KeyCode.X, ref fireUpBlue, ref fireDownBlue);
    }

    private void GreenThrusterInput()
    {
        ThrusterControls(KeyCode.N, KeyCode.M, ref fireUpGreen, ref fireDownGreen);
    }

    private void YellowThrusterInput()
    {
        ThrusterControls(KeyCode.K, KeyCode.L, ref fireUpYellow, ref fireDownYellow);
    }

    private void ThrusterControls(KeyCode inputUp, KeyCode inputDown, ref bool thrusterUp, ref bool thrusterDown)
    {
        if (Input.GetKeyDown(inputUp) && !Input.GetKey(inputDown))
        {
            thrusterUp = true;
            return;
        }
        else if (Input.GetKeyDown(inputDown) && !Input.GetKey(inputUp))
        {
            thrusterDown = true;
            return;
        }

        if (Input.GetKeyUp(inputUp))
            thrusterUp = false;
        if (Input.GetKeyUp(inputDown))
            thrusterDown = false;
    }
}
