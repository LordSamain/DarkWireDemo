﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrintConsole : MonoBehaviour
{
    [SerializeField] string message;

    VRInput VRInput;

    private void Start()
    {
        VRInput = VRInput.Instance;
    }
    public void PrintMessage(string message)
    {
        Debug.Log(message);
    }
}
