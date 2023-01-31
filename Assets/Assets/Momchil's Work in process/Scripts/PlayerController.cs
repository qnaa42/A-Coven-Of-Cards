using UnityEngine;
using UnityEngine.SceneManagement;
using Articy.Unity;

public class PlayerController : MonoBehaviour
{
    private DialogueManager dialogueManager;
    private ArticyObject availableDialogue;

    void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
    }

    void Update()
    {
        PlayerInteraction();
    }


    // All interactions and key inputs player can use
    void PlayerInteraction()
    {
        // Key option to start dialogue when near NPC and if there is dialogue available
        if (Input.GetKeyDown(KeyCode.LeftArrow) && availableDialogue)
        {
            dialogueManager.StartDialogue(availableDialogue);
        }

        // Key option to abort dialogue
        if (dialogueManager.DialogueActive && Input.GetKeyDown(KeyCode.F))
        {
            dialogueManager.CloseDialogueBox();
        }

        // Key option to reset entire scene
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartScene();
        }
    }

    // Simple scene restart for testing purposes
    void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Trigger Enter/Exit used to determine if interaction with NPC is possible
    void OnTriggerEnter(Collider aOther)
    {
        
        
        var articyReferenceComp = aOther.GetComponent<ArticyReference>();
        if (articyReferenceComp)
        {
            availableDialogue = articyReferenceComp.reference.GetObject();
        }
      
    }

    void OnTriggerExit(Collider aOther)
    {
        if (aOther.GetComponent<ArticyReference>() !=null)
        {
            availableDialogue = null;
        }
    }
}
