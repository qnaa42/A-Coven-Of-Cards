using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KinematicCharacterController;
using System;
using Assets.Scripts.Core_Layer;

namespace Assets.Scripts.Character_Controller_Layer
{
    public enum CharacterState
    {
        MeleeStance,
        LightMeleeAttack,
        HeavyMeleeAttack,
        Charging,
        CastingStance,
        CastingSpell,
        CastingCombo,
        InteractingWithObject,
    }

    public enum OrientationMethod
    {
        TowardsCamera,
        TowardsMovement,
    }

    public struct PlayerCharacterInputs
    {
        public float MoveAxisForward;
        public float MoveAxisRight;
        public Quaternion CameraRotation;
        public bool LeftArrowInput;
        public bool UpArrowInput;
        public bool RightArrowInput;
        public bool DownArrowInput;

        public bool SpaceInput;
    }

    public struct AICharacterInputs
    {
        public Vector3 MoveVector;
        public Vector3 LookVector;
    }

    public enum BonusOrientationMethod
    {
        None,
        TowardsGravity,
        TowardsGroundSlopeAndGravity,
    }

    public class CharacterController : MonoBehaviour, ICharacterController
    {
        public KinematicCharacterMotor Motor;
        [Header("Debug Mode")] public bool DebugMode = true;

        [Header("Stable Movement")] public float MaxStableMoveSpeed = 10f;
        public float StableMovementSharpness = 15f;
        public float OrientationSharpness = 10f;
        public OrientationMethod OrientationMethod = OrientationMethod.TowardsCamera;

        [Header("Charging")] public float ChargeSpeed = 15f;
        public float MaxChargeTime = 1.5f;
        public float StoppedTime = 1.0f;
        public float ChargeCooldown = 1.0f;
        public bool CanDoubleCharge = false;

        [Header("Air Movement")] public float MaxAirMoveSpeed = 15f;
        public float AirAccelerationSpeed = 15f;
        public float Drag = 0.1f;


        [Header("Misc")] public List<Collider> IgnoredColliders = new List<Collider>();
        public BonusOrientationMethod BonusOrientationMethod = BonusOrientationMethod.None;
        public float BonusOrientationSharpness = 10f;
        public Vector3 Gravity = new Vector3(0, -30f, 0);
        public Transform MeshRoot;
        public Transform CameraFollowPoint;

        private CharacterState CurrentCharacterState { get; set; }

        private Collider[] _probedColliders = new Collider[8];
        private RaycastHit[] _probedHits = new RaycastHit[8];
        private Vector3 _moveInputVector;
        private Vector3 _lookInputVector;
        private Vector3 _internalVelocityAdd = Vector3.zero;

        private Vector3 lastInnerNormal = Vector3.zero;
        private Vector3 lastOuterNormal = Vector3.zero;

        //Charge Privates
        private Vector3 _currentChargeVelocity;
        private bool _isStopped;
        private bool _mustStopVelocity;
        private float _timeSinceStartedCharge;
        private float _timeSinceStopped;

        private bool _secondChargePossible;
        private float _timeSinceLastCharge = 0.0f;

        private void Awake()
        {
            // Handle initial state
            TransitionToState(CharacterState.MeleeStance);
            if (DebugMode == false)
            {
                StatsUpdate();
            }

            // Assign the characterController to the motor
            Motor.CharacterController = this;
        }

        /// <summary>
        /// Handles movement state transitions and enter/exit callbacks
        /// </summary>
        private void TransitionToState(CharacterState newState)
        {
            var tmpInitialState = CurrentCharacterState;
            OnStateExit(tmpInitialState, newState);
            CurrentCharacterState = newState;
            OnStateEnter(newState, tmpInitialState);
        }

        /// <summary>
        /// Event when entering a state
        /// </summary>
        private void OnStateEnter(CharacterState state, CharacterState fromState)
        {
            switch (state)
            {
                //Melee Stance
                case CharacterState.MeleeStance:
                {
                    _timeSinceLastCharge = 0f;
                    break;
                }

                case CharacterState.LightMeleeAttack:
                {
                    break;
                }

                case CharacterState.HeavyMeleeAttack:
                {
                    break;
                }

                case CharacterState.Charging:
                {
                    _currentChargeVelocity = Motor.CharacterForward * ChargeSpeed;
                    _isStopped = false;
                    _timeSinceStartedCharge = 0f;
                    _timeSinceStopped = 0f;
                    break;
                }

                //Casting Stance
                case CharacterState.CastingStance:
                {
                    break;
                }

                case CharacterState.CastingSpell:
                {
                    break;
                }

                case CharacterState.CastingCombo:
                {
                    break;
                }

                //No Movement States
                case CharacterState.InteractingWithObject:
                {
                    break;
                }

            }
        }

        /// <summary>
        /// Event when exiting a state
        /// </summary>
        private static void OnStateExit(CharacterState state, CharacterState toState)
        {
            switch (state)
            {
                case CharacterState.MeleeStance:
                {
                    break;
                }
                case CharacterState.Charging:
                {
                    break;
                }
            }
        }

        /// <summary>
        /// This is called every frame by ExamplePlayer in order to tell the character what its inputs are
        /// </summary>
        public void SetInputs(ref PlayerCharacterInputs inputs)
        {
            //Handle state transition from Input
            if (inputs.DownArrowInput && CurrentCharacterState is CharacterState.MeleeStance or CharacterState.Charging)
            {
                if (CurrentCharacterState != CharacterState.Charging && (_timeSinceLastCharge > ChargeCooldown))
                {
                    if (CanDoubleCharge)
                    {
                        _secondChargePossible = true;
                    }

                    TransitionToState(CharacterState.Charging);
                }
                else if (CurrentCharacterState != CharacterState.Charging && (_timeSinceLastCharge < ChargeCooldown) &&
                         _secondChargePossible)
                {
                    _secondChargePossible = false;
                    TransitionToState(CharacterState.Charging);
                }

            }



            // Clamp input
            var moveInputVector =
                Vector3.ClampMagnitude(new Vector3(inputs.MoveAxisRight, 0f, inputs.MoveAxisForward), 1f);

            // Calculate camera direction and rotation on the character plane
            var cameraPlanarDirection =
                Vector3.ProjectOnPlane(inputs.CameraRotation * Vector3.forward, Motor.CharacterUp).normalized;
            if (cameraPlanarDirection.sqrMagnitude == 0f)
            {
                cameraPlanarDirection = Vector3.ProjectOnPlane(inputs.CameraRotation * Vector3.up, Motor.CharacterUp)
                    .normalized;
            }

            var cameraPlanarRotation = Quaternion.LookRotation(cameraPlanarDirection, Motor.CharacterUp);

            switch (CurrentCharacterState)
            {
                case CharacterState.MeleeStance:
                {
                    // Move and look inputs
                    _moveInputVector = cameraPlanarRotation * moveInputVector;

                    switch (OrientationMethod)
                    {
                        case OrientationMethod.TowardsCamera:
                            _lookInputVector = cameraPlanarDirection;
                            break;
                        case OrientationMethod.TowardsMovement:
                            _lookInputVector = _moveInputVector.normalized;
                            break;
                    }

                    break;
                }
                case CharacterState.Charging:
                    // Move and look inputs
                    _moveInputVector = cameraPlanarRotation * moveInputVector;
                    switch (OrientationMethod)
                    {

                        case OrientationMethod.TowardsCamera:
                            _lookInputVector = cameraPlanarDirection;
                            break;
                        case OrientationMethod.TowardsMovement:
                            _lookInputVector = _moveInputVector.normalized;
                            break;
                    }

                    break;
            }
        }

        /// <summary>
        /// This is called every frame by the AI script in order to tell the character what its inputs are
        /// </summary>
        public void SetInputs(ref AICharacterInputs inputs)
        {
            _moveInputVector = inputs.MoveVector;
            _lookInputVector = inputs.LookVector;
        }

        private Quaternion _tmpTransientRot;

        /// <summary>
        /// (Called by KinematicCharacterMotor during its update cycle)
        /// This is called before the character begins its movement update
        /// </summary>
        public void BeforeCharacterUpdate(float deltaTime)
        {
            switch (CurrentCharacterState)
            {
                case CharacterState.MeleeStance:
                {
                    break;
                }
                case CharacterState.Charging:
                {
                    _timeSinceStartedCharge += deltaTime;
                    if (_isStopped)
                    {
                        _timeSinceStopped += deltaTime;
                    }

                    break;
                }
            }
        }

        /// <summary>
        /// (Called by KinematicCharacterMotor during its update cycle)
        /// This is where you tell your character what its rotation should be right now. 
        /// This is the ONLY place where you should set the character's rotation
        /// </summary>
        public void UpdateRotation(ref Quaternion currentRotation, float deltaTime)
        {
            switch (CurrentCharacterState)
            {
                case CharacterState.MeleeStance:
                {
                    if (_lookInputVector.sqrMagnitude > 0f && OrientationSharpness > 0f)
                    {
                        // Smoothly interpolate from current to target look direction
                        var smoothedLookInputDirection = Vector3.Slerp(Motor.CharacterForward, _lookInputVector,
                            1 - Mathf.Exp(-OrientationSharpness * deltaTime)).normalized;

                        // Set the current rotation (which will be used by the KinematicCharacterMotor)
                        currentRotation = Quaternion.LookRotation(smoothedLookInputDirection, Motor.CharacterUp);
                    }

                    var currentUp = (currentRotation * Vector3.up);
                    if (BonusOrientationMethod == BonusOrientationMethod.TowardsGravity)
                    {
                        // Rotate from current up to invert gravity
                        var smoothedGravityDir = Vector3.Slerp(currentUp, -Gravity.normalized,
                            1 - Mathf.Exp(-BonusOrientationSharpness * deltaTime));
                        currentRotation = Quaternion.FromToRotation(currentUp, smoothedGravityDir) * currentRotation;
                    }
                    else if (BonusOrientationMethod == BonusOrientationMethod.TowardsGroundSlopeAndGravity)
                    {
                        if (Motor.GroundingStatus.IsStableOnGround)
                        {
                            var initialCharacterBottomHemCenter =
                                Motor.TransientPosition + (currentUp * Motor.Capsule.radius);

                            var smoothedGroundNormal = Vector3.Slerp(Motor.CharacterUp,
                                Motor.GroundingStatus.GroundNormal,
                                1 - Mathf.Exp(-BonusOrientationSharpness * deltaTime));
                            currentRotation = Quaternion.FromToRotation(currentUp, smoothedGroundNormal) *
                                              currentRotation;

                            // Move the position to create a rotation around the bottom hem center instead of around the pivot
                            Motor.SetTransientPosition(initialCharacterBottomHemCenter +
                                                       (currentRotation * Vector3.down * Motor.Capsule.radius));
                        }
                        else
                        {
                            var smoothedGravityDir = Vector3.Slerp(currentUp, -Gravity.normalized,
                                1 - Mathf.Exp(-BonusOrientationSharpness * deltaTime));
                            currentRotation = Quaternion.FromToRotation(currentUp, smoothedGravityDir) *
                                              currentRotation;
                        }
                    }
                    else
                    {
                        var smoothedGravityDir = Vector3.Slerp(currentUp, Vector3.up,
                            1 - Mathf.Exp(-BonusOrientationSharpness * deltaTime));
                        currentRotation = Quaternion.FromToRotation(currentUp, smoothedGravityDir) * currentRotation;
                    }

                    break;
                }
                case CharacterState.Charging:
                {
                    if (_lookInputVector.sqrMagnitude > 0f && OrientationSharpness > 0f)
                    {
                        // Smoothly interpolate from current to target look direction
                        Vector3 smoothedLookInputDirection = Vector3.Slerp(Motor.CharacterForward, _lookInputVector,
                            1 - Mathf.Exp(-OrientationSharpness * deltaTime)).normalized;

                        // Set the current rotation (which will be used by the KinematicCharacterMotor)
                        currentRotation = Quaternion.LookRotation(smoothedLookInputDirection, Motor.CharacterUp);
                    }

                    var currentUp = (currentRotation * Vector3.up);
                    switch (BonusOrientationMethod)
                    {
                        case BonusOrientationMethod.TowardsGravity:
                        {
                            // Rotate from current up to invert gravity
                            var smoothedGravityDir = Vector3.Slerp(currentUp, -Gravity.normalized,
                                1 - Mathf.Exp(-BonusOrientationSharpness * deltaTime));
                            currentRotation = Quaternion.FromToRotation(currentUp, smoothedGravityDir) * currentRotation;
                            break;
                        }
                        case BonusOrientationMethod.TowardsGroundSlopeAndGravity when Motor.GroundingStatus.IsStableOnGround:
                        {
                            var initialCharacterBottomHemCenter =
                                Motor.TransientPosition + (currentUp * Motor.Capsule.radius);

                            var smoothedGroundNormal = Vector3.Slerp(Motor.CharacterUp,
                                Motor.GroundingStatus.GroundNormal,
                                1 - Mathf.Exp(-BonusOrientationSharpness * deltaTime));
                            currentRotation = Quaternion.FromToRotation(currentUp, smoothedGroundNormal) *
                                              currentRotation;

                            // Move the position to create a rotation around the bottom hem center instead of around the pivot
                            Motor.SetTransientPosition(initialCharacterBottomHemCenter +
                                                       (currentRotation * Vector3.down * Motor.Capsule.radius));
                            break;
                        }
                        case BonusOrientationMethod.TowardsGroundSlopeAndGravity:
                        {
                            var smoothedGravityDir = Vector3.Slerp(currentUp, -Gravity.normalized,
                                1 - Mathf.Exp(-BonusOrientationSharpness * deltaTime));
                            currentRotation = Quaternion.FromToRotation(currentUp, smoothedGravityDir) *
                                              currentRotation;
                            break;
                        }
                        default:
                        {
                            var smoothedGravityDir = Vector3.Slerp(currentUp, Vector3.up,
                                1 - Mathf.Exp(-BonusOrientationSharpness * deltaTime));
                            currentRotation = Quaternion.FromToRotation(currentUp, smoothedGravityDir) * currentRotation;
                            break;
                        }
                    }

                    break;
                }
            }
        }

        /// <summary>
        /// (Called by KinematicCharacterMotor during its update cycle)
        /// This is where you tell your character what its velocity should be right now. 
        /// This is the ONLY place where you can set the character's velocity
        /// </summary>
        public void UpdateVelocity(ref Vector3 currentVelocity, float deltaTime)
        {
            switch (CurrentCharacterState)
            {
                case CharacterState.MeleeStance:
                {
                    // Ground movement
                    if (Motor.GroundingStatus.IsStableOnGround)
                    {
                        var currentVelocityMagnitude = currentVelocity.magnitude;

                        var effectiveGroundNormal = Motor.GroundingStatus.GroundNormal;
                        if (currentVelocityMagnitude > 0f && Motor.GroundingStatus.SnappingPrevented)
                        {
                            // Take the normal from where we're coming from
                            var groundPointToCharacter =
                                Motor.TransientPosition - Motor.GroundingStatus.GroundPoint;
                            effectiveGroundNormal = Vector3.Dot(currentVelocity, groundPointToCharacter) >= 0f ? Motor.GroundingStatus.OuterGroundNormal : Motor.GroundingStatus.InnerGroundNormal;
                        }

                        // Reorient velocity on slope
                        currentVelocity = Motor.GetDirectionTangentToSurface(currentVelocity, effectiveGroundNormal) *
                                          currentVelocityMagnitude;

                        // Calculate target velocity
                        var inputRight = Vector3.Cross(_moveInputVector, Motor.CharacterUp);
                        var reorientedInput = Vector3.Cross(effectiveGroundNormal, inputRight).normalized *
                                              _moveInputVector.magnitude;
                        var targetMovementVelocity = reorientedInput * MaxStableMoveSpeed;

                        // Smooth movement Velocity
                        currentVelocity = Vector3.Lerp(currentVelocity, targetMovementVelocity,
                            1f - Mathf.Exp(-StableMovementSharpness * deltaTime));
                    }
                    // Air movement
                    else
                    {
                        // Add move input
                        if (_moveInputVector.sqrMagnitude > 0f)
                        {
                            var addedVelocity = _moveInputVector * (AirAccelerationSpeed * deltaTime);

                            var currentVelocityOnInputsPlane = Vector3.ProjectOnPlane(currentVelocity, Motor.CharacterUp);

                            // Limit air velocity from inputs
                            if (currentVelocityOnInputsPlane.magnitude < MaxAirMoveSpeed)
                            {
                                // clamp addedVel to make total vel not exceed max vel on inputs plane
                                var newTotal = Vector3.ClampMagnitude(currentVelocityOnInputsPlane + addedVelocity,
                                    MaxAirMoveSpeed);
                                addedVelocity = newTotal - currentVelocityOnInputsPlane;
                            }
                            else
                            {
                                // Make sure added vel doesn't go in the direction of the already-exceeding velocity
                                if (Vector3.Dot(currentVelocityOnInputsPlane, addedVelocity) > 0f)
                                {
                                    addedVelocity = Vector3.ProjectOnPlane(addedVelocity,
                                        currentVelocityOnInputsPlane.normalized);
                                }
                            }

                            // Prevent air-climbing sloped walls
                            if (Motor.GroundingStatus.FoundAnyGround)
                            {
                                if (Vector3.Dot(currentVelocity + addedVelocity, addedVelocity) > 0f)
                                {
                                    var perpendicularObstructionNormal = Vector3
                                        .Cross(Vector3.Cross(Motor.CharacterUp, Motor.GroundingStatus.GroundNormal),
                                            Motor.CharacterUp).normalized;
                                    addedVelocity = Vector3.ProjectOnPlane(addedVelocity, perpendicularObstructionNormal);
                                }
                            }

                            // Apply added velocity
                            currentVelocity += addedVelocity;
                        }

                        // Gravity
                        currentVelocity += Gravity * deltaTime;

                        // Drag
                        currentVelocity *= (1f / (1f + (Drag * deltaTime)));
                    }


                    // Take into account additive velocity
                    if (_internalVelocityAdd.sqrMagnitude > 0f)
                    {
                        currentVelocity += _internalVelocityAdd;
                        _internalVelocityAdd = Vector3.zero;
                    }

                    break;
                }
                case CharacterState.Charging:
                {
                    // If we have stopped and need to cancel velocity, do it here
                    if (_mustStopVelocity)
                    {
                        currentVelocity = Vector3.zero;
                        _mustStopVelocity = false;
                    }

                    if (_isStopped)
                    {
                        // When stopped, do no velocity handling except gravity
                        currentVelocity += Gravity * deltaTime;
                    }
                    else
                    {
                        // When charging, velocity is always constant
                        var previousY = currentVelocity.y;
                        currentVelocity = _currentChargeVelocity;
                        currentVelocity.y = previousY;
                        currentVelocity += Gravity * deltaTime;
                    }

                    break;
                }
            }
        }

        /// <summary>
        /// (Called by KinematicCharacterMotor during its update cycle)
        /// This is called after the character has finished its movement update
        /// </summary>
        public void AfterCharacterUpdate(float deltaTime)
        {
            switch (CurrentCharacterState)
            {
                case CharacterState.MeleeStance:
                {
                    _timeSinceLastCharge += deltaTime;
                    break;
                }
                case CharacterState.Charging:
                {
                    // Detect being stopped by elapsed time
                    if (!_isStopped && _timeSinceStartedCharge > MaxChargeTime)
                    {
                        _mustStopVelocity = true;
                        _isStopped = true;
                    }

                    // Detect end of stopping phase and transition back to default movement state
                    if (_timeSinceStopped > StoppedTime)
                    {
                        TransitionToState(CharacterState.MeleeStance);
                    }

                    break;
                }
            }
        }

        public void PostGroundingUpdate(float deltaTime)
        {
            switch (Motor.GroundingStatus.IsStableOnGround)
            {
                // Handle landing and leaving ground
                case true when !Motor.LastGroundingStatus.IsStableOnGround:
                    OnLanded();
                    break;
                case false when Motor.LastGroundingStatus.IsStableOnGround:
                    OnLeaveStableGround();
                    break;
            }
        }

        public bool IsColliderValidForCollisions(Collider coll)
        {
            if (IgnoredColliders.Count == 0)
            {
                return true;
            }

            if (IgnoredColliders.Contains(coll))
            {
                return false;
            }

            return true;
        }

        public void OnGroundHit(Collider hitCollider, Vector3 hitNormal, Vector3 hitPoint,
            ref HitStabilityReport hitStabilityReport)
        {
        }

        public void OnMovementHit(Collider hitCollider, Vector3 hitNormal, Vector3 hitPoint,
            ref HitStabilityReport hitStabilityReport)
        {
        }

        public void StatsUpdate()
        {
            // Update the character's stats
            //Update Movement Stats
            MaxStableMoveSpeed = GameManager.instance.userManager.GetMovementSpeed();
            StableMovementSharpness = GameManager.instance.userManager.GetStableMovementSharpness();
            OrientationSharpness = GameManager.instance.userManager.GetOrientationSharpness();
            //Update Charge Stats
            ChargeSpeed = GameManager.instance.userManager.GetChargeSpeed();
            MaxChargeTime = GameManager.instance.userManager.GetMaxChargeTime();
            StoppedTime = GameManager.instance.userManager.GetStoppedTime();
            ChargeCooldown = GameManager.instance.userManager.GetChargeCooldown();
            CanDoubleCharge = GameManager.instance.userManager.GetCanDoubleCharge();
        }

        public void AddVelocity(Vector3 velocity)
        {
            switch (CurrentCharacterState)
            {
                case CharacterState.MeleeStance:
                {
                    _internalVelocityAdd += velocity;
                    break;
                }
            }
        }

        public void ProcessHitStabilityReport(Collider hitCollider, Vector3 hitNormal, Vector3 hitPoint,
            Vector3 atCharacterPosition, Quaternion atCharacterRotation, ref HitStabilityReport hitStabilityReport)
        {
        }

        private static void OnLanded()
        {
        }

        private static void OnLeaveStableGround()
        {
        }

        public void OnDiscreteCollisionDetected(Collider hitCollider)
        {
        }
    }
}