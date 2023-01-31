using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Articy.Unity;
using Articy.Unity.Interfaces;


public class BranchChoice : MonoBehaviour
{
    private Branch branch;
    private ArticyFlowPlayer flowPlayer;

    [SerializeField]
    Text buttonText;

    // Called when a button is created to represent a single branch
    public void AssignBranch(ArticyFlowPlayer aFlowPlayer, Branch aBranch)
    {
        branch = aBranch;
        flowPlayer = aFlowPlayer;
        IFlowObject Target = aBranch.Target;
        buttonText.text = string.Empty;

        // Check if the object has a "MenuText" property.
        // If yes, set the button text to that "MenuText"
        var objectWithMenuText = Target as IObjectWithMenuText;
        if (objectWithMenuText != null)
        {
            buttonText.text = objectWithMenuText.MenuText;
        }

        // If there is no text from a "MenuText" property set,
        // we place "continue" on the button as a "Continue" symbol 
        if (string.IsNullOrEmpty(buttonText.text))
        {
            buttonText.text = "continue";
        }
    }

    // What happens when button is clicked
    public void OnBranchSelected()
    {
        flowPlayer.Play(branch);
    }
}
