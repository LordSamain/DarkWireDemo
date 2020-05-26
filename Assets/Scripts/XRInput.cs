using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.Events;
using System;

public class XRInput : MonoBehaviour
{
    [SerializeField] XRController controller;
    [SerializeField] XRBinding[] xrBindings;
    [SerializeField] InputDevices inputDevice;


    VRInput input;

    bool isPressed;

    private void Start()
    {
        input = VRInput.Instance;
    }

    void Update()
    {
        input = VRInput.Instance;
        //controller.inputDevice.TryGetFeatureValue(CommonUsages.triggerButton, out isPressed);
        //if (isPressed)
        //    onTriggerPressed.Invoke();
    }
}

[Serializable] 
public class XRBinding
{

    [SerializeField] InputDevice inputDevice;
    [SerializeField] UnityEvent onButtonPressed;


}