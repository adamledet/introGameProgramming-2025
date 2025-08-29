using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;
using Unity.Cinemachine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

namespace Exercises
{
    /// <summary>
    /// Do NOT change!
    /// This is the class that manages player input.
    /// This class manages two input values:
    ///     - X movement using A/D or Left/Right
    ///     - Z movement using W/S or Up/Down
    /// To access these values, read the rawInput as a Vector3.
    /// </summary>
    public class InputManager : MonoBehaviour, Unity.Cinemachine.IInputAxisOwner
    {
        [SerializeField] bool can_jump;
        [SerializeField] bool can_run;
        [SerializeField] bool zMovement;

        [Header("Input Axes")]
        [Tooltip("X Axis movement.  Value is -1..1.  Controls the sideways movement")]
        InputAxis MoveX = InputAxis.DefaultMomentary;

        [Tooltip("Z Axis movement.  Value is -1..1. Controls the forward movement")]
        InputAxis MoveZ = InputAxis.DefaultMomentary;

        public UnityEvent onJump;

        [Tooltip("Sprint movement.  Value is 0 or 1. If 1, then is sprinting")]
        public InputAxis Sprint = InputAxis.DefaultMomentary;

        [Tooltip("This vector returns movement along the X and Z axes")]
        public Vector3 rawInput;

        /// Report the available input axes to the input axis controller.
        /// We use the Input Axis Controller because it works with both the Input package
        /// and the Legacy input system.  This is sample code and we
        /// want it to work everywhere.
        void IInputAxisOwner.GetInputAxes(List<IInputAxisOwner.AxisDescriptor> axes)
        {
            axes.Add(new() { DrivenAxis = () => ref MoveX, Name = "Move X", Hint = IInputAxisOwner.AxisDescriptor.Hints.X });
            if (zMovement) axes.Add(new() { DrivenAxis = () => ref MoveZ, Name = "Move Z", Hint = IInputAxisOwner.AxisDescriptor.Hints.Y });

            if (can_run) axes.Add(new() { DrivenAxis = () => ref Sprint, Name = "Sprint" });
        }

        void Update()
        {
            // Get the reference frame for the input
            rawInput = new Vector3(MoveX.Value, 0, MoveZ.Value);
        }

        public void OnJump(InputValue value)
        {
            if (value.isPressed)
            {
                onJump?.Invoke();
            }
        }
    }
}