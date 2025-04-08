using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using Bhaptics.SDK2;
using System;

public class Haptics : MonoBehaviour
{
    [Serializable]
    public class Motor
    {
        public GameObject location;
        public int intensity;
        private MotorCheck motorCheck;

        
        public void Initialize()
        {
            motorCheck = location.GetComponent<MotorCheck>();
            if (motorCheck != null)
            {
                intensity = motorCheck.intensity;
            }
            else
            {
                Debug.LogWarning("MotorCheck script not found on location: " + location.name);
            }
        }

        public void UpdateIntensity()
        {
            if (motorCheck != null)
            {
                intensity = motorCheck.intensity;
            }
        }
    }

    public Motor[] jacketMotors;

    private void Start()
    {
        foreach (Motor motor in jacketMotors)
        {
            motor.Initialize();
        }
    }


    private void Update()
    {
        foreach (Motor motor in jacketMotors)
        {
            motor.UpdateIntensity();
        }
        OnCall();
    }
    //void OnTriggerEnter(Collider collider)
    //{
    //    Debug.Log("Collided");
    //    OnCall();
    //}
    private void OnCall()
    {
        // TactSuit has 40 motors, so length of array should be 40 too.
        int[] MotorValueArray = new int[40];
        for (int i = 0; i < jacketMotors.Length; i++)
        {
            MotorValueArray[i] = jacketMotors[i].intensity;
        }

        BhapticsLibrary.PlayMotors(
            (int)PositionType.Vest, // Device type
            MotorValueArray,        // Haptic intensities
            500                     // Haptic duration (millisecond)
        );
    }

}