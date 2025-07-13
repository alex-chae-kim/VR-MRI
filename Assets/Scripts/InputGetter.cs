using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

[RequireComponent(typeof(InputData))]
public class InputGetter : MonoBehaviour
{
    private InputData _inputData;
    private float _leftInput = 0f;
    private float _rightInput = 0f;
    private void Start()
    {
        _inputData = GetComponent<InputData>();
    }

    public float GetLeftTrigger()
    {
        if (_inputData._leftController.TryGetFeatureValue(CommonUsages.trigger, out float leftTrigger))
        {
            return leftTrigger;
        } else
        {
            return 0f;
        }
    }

    public float GetRightTrigger()
    {
        if (_inputData._rightController.TryGetFeatureValue(CommonUsages.trigger, out float rightTrigger))
        {
            return rightTrigger;
        }
        else
        {
            return 0f;
        }
    }
}
