using System;
using System.Linq;
using Assets.Scripts.Core_Layer;
using UnityEngine;
using CharacterController = UnityEngine.CharacterController;
namespace Assets.Scripts.Character_Controller_Layer
{
    public class PlayerManager : MonoBehaviour
    {
        public GameObject Athame;
        public GameObject Wand;
        
        // Start is called before the first frame update
        public CharacterCamera OrbitCamera;
        public Transform CameraFollowPoint;
        public CharacterController Character;
    
        private const string HorizontalInput = "Horizontal";
        private const string VerticalInput = "Vertical";

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
        
            OrbitCamera.SetFollowTransform(CameraFollowPoint);
            OrbitCamera.IgnoredColliders.Clear();
            OrbitCamera.IgnoredColliders = Character.GetComponentsInChildren<Collider>().ToList();
        }

        // Update is called once per frame
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
            
            switch (Character.CurrentCharacterState)
            {
                case CharacterState.MeleeStance:
                case CharacterState.LightMeleeAttack:
                case CharacterState.HeavyMeleeAttack:
                case CharacterState.Charging:
                    Athame.SetActive(true);
                    Wand.SetActive(false);
                    break;
                case CharacterState.CastingStance:
                case CharacterState.CastingSpell:
                case CharacterState.CastingCombo:
                    Athame.SetActive(false);
                    Wand.SetActive(true);
                    break;
                case CharacterState.InteractingWithObject:
                    Athame.SetActive(false);
                    Wand.SetActive(false);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            HandleCharacterInput();
        }

        private void LateUpdate()
        {
            HandleCameraInput();
        }
    
        private void HandleCharacterInput()
        {
            var characterInputs = new PlayerCharacterInputs
            {
                // Build the CharacterInputs struct
                MoveAxisForward = Input.GetAxisRaw(VerticalInput),
                MoveAxisRight = Input.GetAxisRaw(HorizontalInput),
                CameraRotation = OrbitCamera.Transform.rotation,
                LeftArrowInput = Input.GetKeyDown(KeyCode.LeftArrow),
                UpArrowInput = Input.GetKeyDown(KeyCode.UpArrow),
                RightArrowInput = Input.GetKeyDown(KeyCode.RightArrow),
                DownArrowInput = Input.GetKeyDown(KeyCode.DownArrow),
                SpaceInput = Input.GetKeyDown(KeyCode.Space),
            };

            // Apply inputs to character
            Character.SetInputs(ref characterInputs);
        }

        private void HandleCameraInput()
        {
            // Create the look input vector for the camera
        
            var lookInputVector = new Vector3(0, 0, 0f);

            // Prevent moving the camera while the cursor isn't locked
            if (Cursor.lockState != CursorLockMode.Locked)
            {
                lookInputVector = Vector3.zero;
            }

            // Apply inputs to the camera
            OrbitCamera.UpdateWithInput(Time.deltaTime, 0f, lookInputVector);

            // Handle toggling zoom level
            if (Input.GetMouseButtonDown(1))
            {
                OrbitCamera.TargetDistance = (OrbitCamera.TargetDistance == 0f) ? OrbitCamera.DefaultDistance : 0f;
            }
        }

        
        
    
    
    

    

    
    }
}
