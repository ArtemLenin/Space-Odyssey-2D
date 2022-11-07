using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArduinoBridge : MonoBehaviour
{
    private bool _signal = false;
    private float _currentSpeed = 0;

    public bool Signal { get => _signal; set => _signal = value; }
    public float CurrentSpeed { get => _currentSpeed; set => _currentSpeed = value; }
}
