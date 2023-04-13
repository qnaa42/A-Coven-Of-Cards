using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KinematicCharacterController;
using System;
using Articy.Unity;
using Assets.Scripts.Character_Controller_Layer.Base.Data;
using Assets.Scripts.Core_Layer;
using UnityEngine.Serialization;
using Assets.Scripts.Spells_Control_Layer;
using DevionGames.InventorySystem;

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

        [Header("Stable Movement")]
        public OrientationMethod OrientationMethod = OrientationMethod.TowardsCamera;
        
        
        [Header("Articy Dialogue")]
        private DialogueManager dialogueManager;
        private  ArticyObject availableDialogue;
        [HideInInspector] public bool dialogueFinished = false;
        [HideInInspector] public bool itemCollected = false;
        

        [Header("Air Movement")] public float MaxAirMoveSpeed = 15f;
        public float AirAccelerationSpeed = 15f;
        public float Drag = 0.1f;


        [Header("Misc")] public List<Collider> IgnoredColliders = new List<Collider>();
        public BonusOrientationMethod BonusOrientationMethod = BonusOrientationMethod.None;
        public float BonusOrientationSharpness = 10f;
        public Vector3 Gravity = new Vector3(0, -30f, 0);
        public Transform MeshRoot;
        public Transform CameraFollowPoint;

        public CharacterState CurrentCharacterState { get; private set; }

        private Collider[] _probedColliders = new Collider[8];
        private RaycastHit[] _probedHits = new RaycastHit[8];
        private Vector3 _moveInputVector;
        private Vector3 _lookInputVector;
        private Vector3 _internalVelocityAdd = Vector3.zero;

        private Vector3 lastInnerNormal = Vector3.zero;
        private Vector3 lastOuterNormal = Vector3.zero;

        //Light Melee Attack Privates
        private float _timeSinceStartedLightMeleeAttack = 0f;
        private float _timeSinceLastLightMeleeAttack = 0f;
        public int _consecutiveLightMeleeAttacks = 0;
        
        //Heavy Melee Attack Privates
        private float _timeSinceStartedHeavyMeleeAttack = 0f;
        private float _timeSinceLastHeavyMeleeAttack = 0f;
        
        
        [Header("Charge Privates")]
        //Charge Privates
        public Vector3 _currentChargeVelocity;
        public bool _isStopped;
        public bool _mustStopVelocity;
        public float _timeSinceStartedCharge;
        public float _timeSinceStopped;
        public bool _secondChargePossible;
        public float _timeSinceLastCharge = 0.0f;
        
        //Casting Spell Privates
        private float _timeSinceStartedCastingSpell = 0f;
        private float _timeSinceLastCastingSpell = 0f;


        public CharacterState _lastState;

        private void Awake()
        {
            // Handle initial state
            TransitionToState(CharacterState.MeleeStance);

            // Assign the characterController to the motor
            Motor.CharacterController = this;
        }
        
        private void Start()
        {
            dialogueManager = FindObjectOfType<DialogueManager>();
            ArticyDatabase.DefaultGlobalVariables.Notifications.AddListener("playerInventory.*", MyGameStateVariablesChanged);
        }

        /// <summary>
        /// Handles movement state transitions and enter/exit callbacks
        /// </summary>
        public void TransitionToState(CharacterState newState)
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
                    switch (fromState)
                    {
                        case CharacterState.Charging:
                            _timeSinceLastCharge = 0f;
                            break;
                        case CharacterState.LightMeleeAttack:
                            _timeSinceLastLightMeleeAttack = 0f;
                            break;
                        case CharacterState.HeavyMeleeAttack:
                            _timeSinceLastHeavyMeleeAttack = 0f;
                            break;
                    }
                    break;
                }

                case CharacterState.LightMeleeAttack:
                {
                    _timeSinceStartedLightMeleeAttack = 0f;
                    _consecutiveLightMeleeAttacks++;
                    GameManager.instance.combatManager.ShowLightAttackDebugCone();
                    break;
                }

                case CharacterState.HeavyMeleeAttack:
                {
                    _timeSinceStartedHeavyMeleeAttack = 0f;
                    GameManager.instance.combatManager.SowHeavyAttackDebugCone();
                    break;
                }

                case CharacterState.Charging:
                {
                    _currentChargeVelocity = Motor.CharacterForward * GameManager.instance.userManager.GetChargeSpeed();
                    _isStopped = false;
                    _timeSinceStartedCharge = 0f;
                    _timeSinceStopped = 0f;
                    break;
                }

                //Casting Stance
                case CharacterState.CastingStance:
                {
                    switch (fromState)
                    {
                        case CharacterState.CastingSpell:
                            _timeSinceLastCastingSpell = 0f;
                            break;
                    }
                    break;
                }

                case CharacterState.CastingSpell:
                {
                    if (GameManager.instance.spellsManager.GetSpellType() == 3)
                    {
                        _currentChargeVelocity = Motor.CharacterForward * GameManager.instance.spellsManager.GetDashChargeSpeed();
                        _isStopped = false;
                        _timeSinceStartedCharge = 0f;
                        _timeSinceStopped = 0f;
                    }
                    _timeSinceStartedCastingSpell = 0f;
                    break;
                }

                case CharacterState.CastingCombo:
                {
                    break;
                }

                //No Movement States
                case CharacterState.InteractingWithObject:
                {
                    _lastState = fromState;
                    if (availableDialogue)
                    {
                        dialogueManager.StartDialogue(availableDialogue);
                    }
                    break;
                }

                default:
                {
                    throw new ArgumentOutOfRangeException(nameof(state), state, null);
                }
            }
        }

        /// <summary>
        /// Event when exiting a state
        /// </summary>
        protected virtual void OnStateExit(CharacterState state, CharacterState toState)
        {
            switch (state)
            {
                //Melee Stance
                case CharacterState.MeleeStance:
                {
                    break;
                }
                
                case CharacterState.LightMeleeAttack:
                {
                    
                    switch (_consecutiveLightMeleeAttacks)
                    {
                        case 3:
                            GameManager.instance.combatManager.LightAttack(true);
                            _consecutiveLightMeleeAttacks = 0;
                            break;
                        case < 3:
                            GameManager.instance.combatManager.LightAttack(false);
                            break;
                    }
                    GameManager.instance.combatManager.HideLightAttackDebugCone();
                    break;
                }
                
                case CharacterState.HeavyMeleeAttack:
                {
                    switch (_consecutiveLightMeleeAttacks)
                    {
                        case 2:
                            GameManager.instance.combatManager.HeavyAttack(true);
                            _consecutiveLightMeleeAttacks = 0;
                            break;
                        case < 2:
                            GameManager.instance.combatManager.HeavyAttack(false);
                            break;
                    }
                    GameManager.instance.combatManager.HideHeavyAttackDebugCone();
                    break;
                }
                
                case CharacterState.Charging:
                {
                    break;
                }
                
                //Casting Stance
                case CharacterState.CastingStance:
                {
                    break;
                }
                
                case CharacterState.CastingSpell:
                {
                    GameManager.instance.spellsControlManager.CastSpell();
                    break;
                }
                
                case CharacterState.CastingCombo:
                {
                    break;
                }
                
                //No Movement States
                case CharacterState.InteractingWithObject:
                {
                    dialogueManager.CloseDialogueBox();
                    dialogueFinished = false;
                    itemCollected = false;
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
            if (inputs.UpArrowInput)
            {
                switch (CurrentCharacterState)
                {
                    case CharacterState.MeleeStance when (_timeSinceLastHeavyMeleeAttack > GameManager.instance.userManager.GetHeavyAttackCooldown()):
                        TransitionToState(CharacterState.HeavyMeleeAttack);
                        break;
                    case CharacterState.CastingStance when (_timeSinceLastCastingSpell > GameManager.instance.spellsManager.GetCastingSpellCooldown()):
                        var item = GameManager.instance.spellsControlManager.SpellSlot1.GetComponent<ItemContainer>().GetItems<Item>();
                        var itemID = item[0].FindProperty("ID").intValue;
                        GameManager.instance.spellsControlManager.spellsStatsManager.SetSpellDetails(itemID);
                        TransitionToState(CharacterState.CastingSpell);
                        break;
                }
            }
            else if (inputs.RightArrowInput)
            {
                switch (CurrentCharacterState)
                {
                    case CharacterState.MeleeStance when (_timeSinceLastLightMeleeAttack > GameManager.instance.userManager.GetLightAttackCooldown()):
                        TransitionToState(CharacterState.LightMeleeAttack);
                        break;
                    case CharacterState.CastingStance when (_timeSinceLastCastingSpell > GameManager.instance.spellsManager.GetCastingSpellCooldown()):
                        var item = GameManager.instance.spellsControlManager.SpellSlot2.GetComponent<ItemContainer>().GetItems<Item>();
                        var itemID = item[0].FindProperty("ID").intValue;
                        GameManager.instance.spellsControlManager.spellsStatsManager.SetSpellDetails(itemID);
                        TransitionToState(CharacterState.CastingSpell);
                        break;
                }
            }
            else if (inputs.DownArrowInput)
            {
                switch (CurrentCharacterState)
                {
                    case CharacterState.MeleeStance or CharacterState.Charging or CharacterState.LightMeleeAttack or CharacterState.HeavyMeleeAttack when CurrentCharacterState != CharacterState.Charging && (_timeSinceLastCharge > GameManager.instance.userManager.GetChargeCooldown()):
                    {
                        if (GameManager.instance.userManager.GetCanDoubleCharge())
                        {
                            _secondChargePossible = true;
                        }

                        TransitionToState(CharacterState.Charging);
                        break;
                    }
                    case CharacterState.MeleeStance or CharacterState.Charging or CharacterState.LightMeleeAttack or CharacterState.HeavyMeleeAttack:
                    {
                        if (CurrentCharacterState != CharacterState.Charging && (_timeSinceLastCharge < GameManager.instance.userManager.GetChargeCooldown()) &&
                            _secondChargePossible)
                        {
                            _secondChargePossible = false;
                            TransitionToState(CharacterState.Charging);
                        }

                        break;
                    }
                    case CharacterState.CastingStance when (_timeSinceLastCastingSpell > GameManager.instance.spellsManager.GetCastingSpellCooldown()):
                        var item = GameManager.instance.spellsControlManager.SpellSlot3.GetComponent<ItemContainer>().GetItems<Item>();
                        var itemID = item[0].FindProperty("ID").intValue;
                        GameManager.instance.spellsControlManager.spellsStatsManager.SetSpellDetails(itemID);
                        TransitionToState(CharacterState.CastingSpell);
                        break;
                }
            }
            else if (inputs.LeftArrowInput)
            {
                switch (CurrentCharacterState)
                {
                    case CharacterState.MeleeStance or CharacterState.CastingStance:
                        Debug.Log(GameManager.instance.baseSpellManager.GetSpellList().ToString());
                        TransitionToState(CharacterState.InteractingWithObject);
                        break;
                    case CharacterState.InteractingWithObject:
                        TransitionToState(_lastState);
                        break;
                }
            }
            else if (inputs.SpaceInput)
            {
                switch (CurrentCharacterState)
                {
                    case CharacterState.MeleeStance:
                        TransitionToState(CharacterState.CastingStance);
                        break;
                    case CharacterState.CastingStance:
                        TransitionToState(CharacterState.MeleeStance);
                        break;
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
                //Melee Stance
                case CharacterState.MeleeStance:
                {
                    // Move and look inputs
                    HandleInputs(moveInputVector, cameraPlanarDirection, cameraPlanarRotation);
                    break;
                }

                case CharacterState.LightMeleeAttack:
                {
                    // Move and look inputs
                    HandleInputs(moveInputVector, cameraPlanarDirection, cameraPlanarRotation);
                    break;
                }

                case CharacterState.HeavyMeleeAttack:
                {
                    HandleInputs(moveInputVector, cameraPlanarDirection, cameraPlanarRotation);
                    break;
                }

                case CharacterState.Charging:
                {
                    // Move and look inputs
                    HandleInputs(moveInputVector, cameraPlanarDirection, cameraPlanarRotation);

                    break;
                }
                
                //Casting Stance
                case CharacterState.CastingStance:
                {
                    // Move and look inputs
                    HandleInputs(moveInputVector, cameraPlanarDirection, cameraPlanarRotation);
                    break;
                }

                case CharacterState.CastingSpell:
                {
                    // Move and look inputs
                    HandleInputs(moveInputVector, cameraPlanarDirection, cameraPlanarRotation);
                    break;
                }

                case CharacterState.CastingCombo:
                {
                    // Move and look inputs
                    HandleInputs(moveInputVector, cameraPlanarDirection, cameraPlanarRotation);
                    break;
                }
                
                //No Movement States
                case CharacterState.InteractingWithObject:
                {
                    // Move and look inputs
                    HandleInputs(moveInputVector, cameraPlanarDirection, cameraPlanarRotation);
                    break;
                }

                default:
                {
                    throw new ArgumentOutOfRangeException();
                }
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
                //Melee Stance
                case CharacterState.MeleeStance:
                {
                    break;
                }
                
                case CharacterState.LightMeleeAttack:
                {
                    _timeSinceStartedLightMeleeAttack += deltaTime;
                    break;
                }
                
                case CharacterState.HeavyMeleeAttack:
                {
                    _timeSinceStartedHeavyMeleeAttack += deltaTime;
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
                
                //Casting Stance
                case CharacterState.CastingStance:
                {
                    break;
                }
                
                case CharacterState.CastingSpell:
                {
                    if (GameManager.instance.spellsManager.GetSpellType() == 3)
                    {
                        _timeSinceStartedCharge += deltaTime;
                        if (_isStopped)
                        {
                            _timeSinceStopped += deltaTime;
                        }
                    }
                    _timeSinceStartedCastingSpell += deltaTime;
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
                
                default:
                {
                    throw new ArgumentOutOfRangeException();
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
                //Melee Stance
                case CharacterState.MeleeStance:
                {
                    if (_timeSinceLastLightMeleeAttack > GameManager.instance.userManager.GetLightAttackDirectionLockDuration() && _timeSinceLastHeavyMeleeAttack > GameManager.instance.userManager.GetHeavyAttackDirectionLockDuration())
                    {
                        _consecutiveLightMeleeAttacks = 0;
                        HandleRotation(ref currentRotation, deltaTime);
                    }
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
                    if (_isStopped)
                    {
                        HandleRotation(ref currentRotation, deltaTime);
                    }
                    break;
                }

                //Casting Stance
                case CharacterState.CastingStance:
                {
                    if (_timeSinceLastCastingSpell > GameManager.instance.spellsManager.GetCastingSpellDirectionLockDuration())
                    {
                        HandleRotation(ref currentRotation, deltaTime);
                    }
                    break;
                }
                
                case CharacterState.CastingSpell:
                {
                    if (GameManager.instance.spellsManager.GetSpellType() == 3)
                    {
                        if (_isStopped)
                        {
                            HandleRotation(ref currentRotation, deltaTime);
                        }
                    }
                    
                    break;
                }
                
                case CharacterState.CastingCombo:
                {
                    break;
                }
                
                //No Movement Stance
                case CharacterState.InteractingWithObject:
                {
                    break;
                }
                
                default:
                {
                    throw new ArgumentOutOfRangeException();
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
            var maxStableMoveSpeed = GameManager.instance.userManager.GetMovementSpeed();
            var globalMovementSpeedMultiplier = GameManager.instance.userManager.GetGlobalMovementSpeedMultiplier();
            var meleeMovementMultiplier = GameManager.instance.userManager.GetMeleeMovementSpeedMultiplier();
            var lightMeleeAttackMovementMultiplier =
                GameManager.instance.userManager.GetLightAttackMovementSpeedMultiplier();
            var heavyMeleeAttackMovementMultiplier =
                GameManager.instance.userManager.GetHeavyAttackMovementSpeedMultiplier();
            var castingMovementMultiplier = GameManager.instance.userManager.GetCastingMovementSpeedMultiplier();
            switch (CurrentCharacterState)
            {
                //Melee Stance
                case CharacterState.MeleeStance:
                {
                    HandleVelocity(ref currentVelocity, deltaTime, maxStableMoveSpeed, meleeMovementMultiplier, globalMovementSpeedMultiplier);
                    break;
                }
                
                case CharacterState.LightMeleeAttack:
                {
                    HandleVelocity(ref currentVelocity, deltaTime, maxStableMoveSpeed, lightMeleeAttackMovementMultiplier, globalMovementSpeedMultiplier);
                    break;
                }
                
                case CharacterState.HeavyMeleeAttack:
                {
                    HandleVelocity(ref currentVelocity, deltaTime, maxStableMoveSpeed, heavyMeleeAttackMovementMultiplier, globalMovementSpeedMultiplier);
                    break;
                }
                
                case CharacterState.Charging:
                {
                    HandleCharging(ref currentVelocity, deltaTime);

                    break;
                }
                
                //Casting Stance
                case CharacterState.CastingStance:
                {
                    HandleVelocity(ref currentVelocity, deltaTime, maxStableMoveSpeed, castingMovementMultiplier, globalMovementSpeedMultiplier);
                    break;
                }
                
                case CharacterState.CastingSpell:
                {
                    if (GameManager.instance.spellsManager.GetSpellType() == 3)
                    {
                        HandleCharging(ref currentVelocity, deltaTime);
                    }
                    else
                    {
                        HandleVelocity(ref currentVelocity, deltaTime, maxStableMoveSpeed, GameManager.instance.spellsManager.GetCastingSpellMovementSpeedMultiplier(), globalMovementSpeedMultiplier);
                    }
                    break;
                }
                
                case CharacterState.CastingCombo:
                {
                    break;
                }
                
                //No Movement Stance
                case CharacterState.InteractingWithObject:
                {
                    currentVelocity = Vector3.zero;
                    break;
                }

                default:
                {
                    throw new ArgumentOutOfRangeException();
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
                //Melee Stance
                case CharacterState.MeleeStance:
                {
                    if (_timeSinceLastHeavyMeleeAttack <= GameManager.instance.userManager.GetHeavyAttackDirectionLockDuration())
                    {
                        _timeSinceLastHeavyMeleeAttack += deltaTime;
                    }

                    if (_timeSinceLastCharge <= GameManager.instance.userManager.GetChargeCooldown())
                    {
                        _timeSinceLastCharge += deltaTime;
                    }

                    if (_timeSinceLastLightMeleeAttack <= GameManager.instance.userManager.GetLightAttackDirectionLockDuration())
                    {
                        _timeSinceLastLightMeleeAttack += deltaTime;
                    }

                    break;
                }
                
                case CharacterState.LightMeleeAttack:
                {
                    if(_timeSinceStartedLightMeleeAttack > GameManager.instance.userManager.GetLightAttackDuration())
                        TransitionToState(CharacterState.MeleeStance);
                    break;
                }
                
                case CharacterState.HeavyMeleeAttack:
                {
                    if(_timeSinceStartedHeavyMeleeAttack > GameManager.instance.userManager.GetHeavyAttackDuration())
                        TransitionToState(CharacterState.MeleeStance);
                    break;
                }
                
                case CharacterState.Charging:
                {
                    // Detect being stopped by elapsed time
                    if (!_isStopped && _timeSinceStartedCharge > GameManager.instance.userManager.GetMaxChargeTime())
                    {
                        _mustStopVelocity = true;
                        _isStopped = true;
                    }

                    // Detect end of stopping phase and transition back to default movement state
                    if (_timeSinceStopped > GameManager.instance.userManager.GetStoppedTime())
                    {
                        TransitionToState(CharacterState.MeleeStance);
                    }

                    break;
                }
                
                //Casting Stance
                case CharacterState.CastingStance:
                {
                    if (_timeSinceLastCastingSpell <= GameManager.instance.spellsManager.GetCastingSpellDirectionLockDuration())
                    {
                        _timeSinceLastCastingSpell += deltaTime;
                    }
                    break;
                }
                
                case CharacterState.CastingSpell:
                {
                    if (GameManager.instance.spellsManager.GetSpellType() == 3)
                    {
                        if (!_isStopped && _timeSinceStartedCharge > GameManager.instance.spellsManager.GetDashMaxChargeTime())
                        {
                            _mustStopVelocity = true;
                            _isStopped = true;
                        }

                        // Detect end of stopping phase and transition back to default movement state
                        if (_timeSinceStopped > GameManager.instance.spellsManager.GetDashStoppedTime())
                        {
                            TransitionToState(CharacterState.CastingStance);
                        }
                    }
                    else
                    {
                        if(_timeSinceStartedCastingSpell > GameManager.instance.spellsManager.GetCastingSpellDuration())
                            TransitionToState(CharacterState.CastingStance);
                    }
                    break;
                }
                
                case CharacterState.CastingCombo:
                {
                    break;
                }
                
                //No Movement Stance
                case CharacterState.InteractingWithObject:
                {
                    if (dialogueFinished)
                    {
                        TransitionToState(_lastState);
                    }

                    if (itemCollected)
                    {
                        TransitionToState(_lastState);
                    }
                    break;
                }

                default:
                {
                    throw new ArgumentOutOfRangeException();
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

            return !IgnoredColliders.Contains(coll);
        }

        public void OnGroundHit(Collider hitCollider, Vector3 hitNormal, Vector3 hitPoint,
            ref HitStabilityReport hitStabilityReport)
        {
        }

        public void OnMovementHit(Collider hitCollider, Vector3 hitNormal, Vector3 hitPoint,
            ref HitStabilityReport hitStabilityReport)
        {
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
                case CharacterState.LightMeleeAttack:
                    break;
                case CharacterState.HeavyMeleeAttack:
                    break;
                case CharacterState.Charging:
                    break;
                case CharacterState.CastingStance:
                    break;
                case CharacterState.CastingSpell:
                    break;
                case CharacterState.CastingCombo:
                    break;
                case CharacterState.InteractingWithObject:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        
        private void HandleInputs(Vector3 moveInputVector, Vector3 cameraPlanarDirection, Quaternion cameraPlanarRotation)
        {// Move and look inputs
            _moveInputVector = cameraPlanarRotation * moveInputVector;

            _lookInputVector = OrientationMethod switch
            {
                OrientationMethod.TowardsCamera => cameraPlanarDirection,
                OrientationMethod.TowardsMovement => _moveInputVector.normalized,
                _ => _lookInputVector
            };
            
        }

        private void HandleRotation(ref Quaternion currentRotation, float deltaTime)
        {
            var orientationSharpness = GameManager.instance.userManager.GetOrientationSharpness();
            if (_lookInputVector.sqrMagnitude > 0f && orientationSharpness > 0f)
            {
                // Smoothly interpolate from current to target look direction
                var smoothedLookInputDirection = Vector3.Slerp(Motor.CharacterForward, _lookInputVector,
                    1 - Mathf.Exp(-orientationSharpness * deltaTime)).normalized;

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
                case BonusOrientationMethod.None:
                default:
                {
                    var smoothedGravityDir = Vector3.Slerp(currentUp, Vector3.up,
                        1 - Mathf.Exp(-BonusOrientationSharpness * deltaTime));
                    currentRotation = Quaternion.FromToRotation(currentUp, smoothedGravityDir) * currentRotation;
                    break;
                }
            }
        }

        private void HandleVelocity(ref Vector3 currentVelocity, float deltaTime, float movementSpeed, float movementSpeedMultiplier, float globalMovementSpeedMultiplier)
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
                        var targetMovementVelocity = reorientedInput * (movementSpeed * movementSpeedMultiplier * globalMovementSpeedMultiplier);

                        // Smooth movement Velocity
                        currentVelocity = Vector3.Lerp(currentVelocity, targetMovementVelocity,
                            1f - Mathf.Exp(-GameManager.instance.userManager.GetStableMovementSharpness() * deltaTime));
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

        }

        private void HandleCharging(ref Vector3 currentVelocity, float deltaTime)
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

        private void OnTriggerEnter(Collider other)
        {
            var articyReference = other.GetComponent<ArticyReference>();
            if (articyReference)
            {
                availableDialogue = articyReference.reference.GetObject();
            }
        }
        
        private void OnTriggerExit(Collider other)
        {
            if (other.GetComponent<ArticyReference>())
            {
                availableDialogue = null;
            }
        }
        
        void MyGameStateVariablesChanged(string aVariableName, object aValue)
        {
            if (aVariableName == "playerInventory.genericHerbAmount")
                Debug.Log("herbs changed");
        }
        
        
    }
}