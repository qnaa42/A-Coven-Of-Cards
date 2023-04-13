using UnityEngine;
using UnityEngine.SceneManagement;
using Articy.Unity;
using Articy.A_Coven_Of_Cards.GlobalVariables;

public class PlayerController : MonoBehaviour
{
    private DialogueManager dialogueManager;
    private ArticyObject availableDialogue;

    void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
        // creates listener for the playerInventory Global namespace
        ArticyDatabase.DefaultGlobalVariables.Notifications.AddListener("playerInventory.*", MyGameStateVariablesChanged);
    }

    void Update()
    {
        PlayerInteraction();
    }

    // here we handle every variable change inside the articy "playerInventory" namespace
    void MyGameStateVariablesChanged(string aVariableName, object aValue)
    {
        if (aVariableName == "playerInventory.genericHerbAmount")
            Debug.Log("herbs changed");
    }

    // All interactions and key inputs player can use
    void PlayerInteraction()
    {
        // interacting with articy global variables
        if (Input.GetKeyDown(KeyCode.V) )
        {
            ArticyGlobalVariables.Default.playerInventory.genericHerbAmount += 1;
        }
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

    public void HerbAdded()
    {
        ArticyGlobalVariables.Default.playerInventory.genericHerbAmount += 1;
    }
}
