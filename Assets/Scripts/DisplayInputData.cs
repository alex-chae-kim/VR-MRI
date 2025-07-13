using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

[RequireComponent(typeof(InputData))]
public class DisplayInputData : MonoBehaviour
{
    private InputData _inputData;
    private float _leftInput = 0f;
    private float _rightInput = 0f;

    private void Start()
    {
        _inputData = GetComponent<InputData>();
    }
    // Update is called once per frame
    void Update()
    {
        if (_inputData._leftController.TryGetFeatureValue(CommonUsages.trigger, out float leftTrigger))
        {
            _leftInput = leftTrigger;
            Debug.Log($"Left Trigger Value: {_leftInput}");
        }
        if (_inputData._rightController.TryGetFeatureValue(CommonUsages.trigger, out float rightTrigger))
        {
            _rightInput = rightTrigger;
            Debug.Log($"Right Trigger Value: {_rightInput}");
        }
    }
}
