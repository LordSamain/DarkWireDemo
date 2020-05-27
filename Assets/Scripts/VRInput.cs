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

    public float leftGrip = 0f;
    public float rightGrip = 0f;
    public float leftTriggerFloat = 0f;
    public float rightTriggerFloat = 0f;

    public bool leftTriggerDown = false;
    public float rightTriggerDown = 0f;


    public bool leftTriggerUp = false;
    public bool rightTriggerUp = false;

    public bool XButtonDown = false;
    public bool AButtonDown = false;
    public bool BButtonDown = false;
    public bool YButtonDown = false;

    public bool leftThumbstickClick = false;
    public bool rightThumbstickClick = false;

    public bool menuButton = false;

    public Vector2 leftThumbStick = Vector2.zero;
    public Vector2 rightThumbStick = Vector2.zero;



    bool _preBoolValue = false;
    bool _butonnPressed = false;
    bool _isPressed;

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
       

        List<InputDevice> allLeftHandedControllers = new List<InputDevice>();
        var leftControllerCharacteristics = InputDeviceCharacteristics.Controller | InputDeviceCharacteristics.Left | InputDeviceCharacteristics.HeldInHand;
        InputDevices.GetDevicesWithCharacteristics(leftControllerCharacteristics, allLeftHandedControllers);
        InputDevice leftController = allLeftHandedControllers.FirstOrDefault();

        List<InputDevice> allRightHandedControllers = new List<InputDevice>();
        var rightControllerCharacteristics = InputDeviceCharacteristics.Controller | InputDeviceCharacteristics.Right | InputDeviceCharacteristics.HeldInHand;
        InputDevices.GetDevicesWithCharacteristics(rightControllerCharacteristics, allRightHandedControllers);
        InputDevice rightController = allRightHandedControllers.FirstOrDefault();

        leftGrip = GetfeatureFloatValue(leftController, CommonUsages.grip);
        rightGrip = GetfeatureFloatValue(rightController, CommonUsages.grip);

        leftTriggerFloat = GetfeatureFloatValue(leftController, CommonUsages.trigger); 
        rightTriggerFloat = GetfeatureFloatValue(rightController, CommonUsages.trigger);

        
        XButtonDown = GetfeatureBoolValue(leftController, CommonUsages.primaryButton,false);        
        YButtonDown = GetfeatureBoolValue(leftController, CommonUsages.secondaryButton);
        AButtonDown = GetfeatureBoolValue(rightController, CommonUsages.primaryButton);
        BButtonDown = GetfeatureBoolValue(rightController, CommonUsages.secondaryButton);



        
        //Debug.Log(AButtonDown + " A");
        Debug.Log(XButtonDown + " X");

        //Debug.Log(YButtonDown + " y");
        //Debug.Log(BButtonDown + " b");



    }

    bool GetfeatureBoolValue( InputDevice device, InputFeatureUsage<bool> inputFeatureUsage)
    {
        bool isPressed;
        if (device.TryGetFeatureValue(inputFeatureUsage, out isPressed))
        {
            return isPressed;
        }
            

        return isPressed;
        
    }

    float GetfeatureFloatValue(InputDevice device, InputFeatureUsage<float> inputFeatureUsage)
    {
        float isPressed;
        if (device.TryGetFeatureValue(inputFeatureUsage, out isPressed))
            return isPressed;

        return isPressed;

    }

    bool GetfeatureBoolValue(InputDevice device, InputFeatureUsage<bool> inputFeatureUsage, bool isContinue = false)
    {
       
        device.TryGetFeatureValue(inputFeatureUsage, out _isPressed);
        Debug.Log(_isPressed + " isPressed");
        
        if (_isPressed && !_preBoolValue)
        {
            Debug.Log(_preBoolValue + " _preBoolValue dans if");
            _preBoolValue = false;
            return true;
        }
        _preBoolValue = _isPressed;
        Debug.Log(_preBoolValue + " _preBoolValue");
      
        return false;

    }
    //bool GetButtonDown()
    //{
    //    bool preValue;

    //}

    void DevicesConntected()
    {
       
    }

    void DevicesDisConntected()
    {

    }
}
