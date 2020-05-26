using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using System.Linq;
public class VRInput : MonoBehaviour
{
    private static VRInput _instance;

    public static VRInput Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<VRInput>();
                if (_instance == null)
                {
                    _instance = new GameObject("VRInput").AddComponent<VRInput>();
                }
            }
            return _instance;
        }
    }

    static List<InputDevice> inputDevices = new List<InputDevice>();
    
    

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this);
            return;
        }

        _instance = this;

        DontDestroyOnLoad(gameObject);

    }

    private void OnEnable()
    {
       
        Debug.Log("Enable Script");
    }

    private void OnDisable()
    {
        Debug.Log("Disable Script");
    }

    void Start()
    {



    }

    void Update()
    {
        InputDevices.GetDevices(inputDevices);

        var leftControllerCharacteristics = InputDeviceCharacteristics.Controller | InputDeviceCharacteristics.Left | InputDeviceCharacteristics.HeldInHand;
        InputDevices.GetDevicesWithCharacteristics(leftControllerCharacteristics, inputDevices);

        Debug.Log(inputDevices.FirstOrDefault().name);


    }

    void DevicesConntected()
    {
        inputDevices = new List<InputDevice>();
        

        foreach (var device in inputDevices)
        {

        }


    }

    void DevicesDisConntected()
    {

    }
}
