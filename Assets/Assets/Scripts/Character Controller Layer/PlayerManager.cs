using System.Linq;
using Assets.Scripts.Core_Layer;
using UnityEngine;
using CharacterController = UnityEngine.CharacterController;
namespace Assets.Scripts.Character_Controller_Layer
{
    public class PlayerManager : MonoBehaviour
    {
        // Start is called before the first frame update
        public CharacterCamera OrbitCamera;
        public Transform CameraFollowPoint;
        public CharacterController Character;
    
        private const string HorizontalInput = "Horizontal";
        private const string VerticalInput = "Vertical";

        void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
        
            OrbitCamera.SetFollowTransform(CameraFollowPoint);
            OrbitCamera.IgnoredColliders.Clear();
            OrbitCamera.IgnoredColliders = Character.GetComponentsInChildren<Collider>().ToList();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
            

            HandleCharacterInput();
        }

        private void LateUpdate()
        {
            HandleCameraInput();
        }
    
        private void HandleCharacterInput()
        {
            PlayerCharacterInputs characterInputs = new PlayerCharacterInputs();

            // Build the CharacterInputs struct
            characterInputs.MoveAxisForward = Input.GetAxisRaw(VerticalInput);
            characterInputs.MoveAxisRight = Input.GetAxisRaw(HorizontalInput);
            characterInputs.CameraRotation = OrbitCamera.Transform.rotation;
            characterInputs.ChargingDown = Input.GetKeyDown(KeyCode.Space);

            // Apply inputs to character
            Character.SetInputs(ref characterInputs);
        }

        private void HandleCameraInput()
        {
            // Create the look input vector for the camera
        
            Vector3 lookInputVector = new Vector3(0, 0, 0f);

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
