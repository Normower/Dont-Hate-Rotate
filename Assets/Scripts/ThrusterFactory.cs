using UnityEngine;
using System.Collections;

public enum ThrusterID
{
    Red,
    Blue,
    Green,
    Yellow
}

static class ThrusterFactory {

    public static Thruster Get(ThrusterID ID)
    {
        switch(ID)
        {
            case ThrusterID.Red:
                return new RedThruster();
            case ThrusterID.Blue:
                return new BlueThruster();
            case ThrusterID.Green:
                return new GreenThruster();
            case ThrusterID.Yellow:
                return new YellowThruster();               
        }
        // Should be unreachable
        Debug.LogError("ERROR ::::: No Matching ThrusterID :::::: ID = " + ID);
        return null;

    }
}

abstract class Thruster
{
    public abstract bool ThrusterUp { get; }
    public abstract bool ThrusterDown { get; }
    public abstract Color ThrusterColor { get; }
}

class RedThruster : Thruster 
{
    public override bool ThrusterUp { get { return InputManager.Instance.FireUpRed; } }
    public override bool ThrusterDown { get { return InputManager.Instance.FireDownRed; } }
    public override Color ThrusterColor { get { return new Color(0.8f, 0.0f, 0.0f); } }
}

class BlueThruster : Thruster
{
    public override bool ThrusterUp { get { return InputManager.Instance.FireUpBlue; } }
    public override bool ThrusterDown { get { return InputManager.Instance.FireDownBlue; } }
    public override Color ThrusterColor { get { return new Color(0.0f, 0.0f, 0.8f); } }
}

class GreenThruster : Thruster
{
    public override bool ThrusterUp { get { return InputManager.Instance.FireUpGreen; } }
    public override bool ThrusterDown { get { return InputManager.Instance.FireDownGreen; } }
    public override Color ThrusterColor { get { return new Color(0.0f, 0.8f, 0.0f); } }
}

class YellowThruster : Thruster
{
    public override bool ThrusterUp { get { return InputManager.Instance.FireUpYellow; } }
    public override bool ThrusterDown { get { return InputManager.Instance.FireDownYellow; } }
    public override Color ThrusterColor { get { return new Color(0.8f, 0.8f, 0.0f); } }
}
