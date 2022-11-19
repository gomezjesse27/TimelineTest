using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class ClickableObjectHandler : MonoBehaviour
{
    //[SerializeField] private DialogueUI dialogueUI;
    [SerializeField] private GameObject[] clickableObjects;
    //[SerializeField] private UnityEvent[] objectEvents;
    [SerializeField] private GameObject backButton;
    //[SerializeField] private puzzleScreens;
    private bool puzzleStatus;
    private bool UIStatus;
    // Ignore this comment below, but I find it too funny to get rid of v

    // Yes, I'm too lazy to figure out how to find and call an event through these scripts. Bite me.
    //[SerializeField] private UnityEvent backButtonPress;
    public bool imOutOfVariableNames = true;
    public bool buttonStatus;
    //public bool dialogueOpen => dialogueUI.IsOpen;
    // Start is called before the first frame update
    private void Awake(){
        UIManager.AreUIOpen += UpdateButtonUI;
    }
    private void Start()
    {
        
        for (int i=0; i < clickableObjects.Length; i++){
            //WHY IN THE WORLD IS THE LAST I ENDING UP AS A 1???? HOW THE HELL
            int num = i;
            clickableObjects[i].GetComponentInChildren<Button>().onClick.AddListener( () => OnPickedResponse(num));
        }
        //backButton.GetComponentInChildren<Button>().onClick.AddListener( () => OnPickedBack());
        
    }
    private void LateUpdate(){
        //backButton.SetActive(!dialogueOpen && imOutOfVariableNames);
    }
    private void OnPickedResponse(int index){
        if (!imOutOfVariableNames) return;
        //if (dialogueOpen) return;
        //if (index >= objectEvents.Length) return;
        //Debug.Log();
        //if (!dialogueUI.IsOpen && index < objectEvents.Length) objectEvents[index].Invoke();
        //objectEvents[index].Invoke();
    }
    public void clearButtonStatus()
    {
        puzzleStatus=false;
        UIStatus=false;
        UpdateButtonActive();
    }
    private void UpdateButtonUI(bool givenStatus, UIName temp)
    {
        UIStatus = givenStatus;
        UpdateButtonActive();
    }
    private void UpdateButtonActive()
    {
        // if buttonstatus is active but uiStatus and puzzle status are both false
        //if (buttonStatus && !(UIStatus || puzzleStatus)) return;
        buttonStatus = !(UIStatus || puzzleStatus);
        foreach (GameObject button in clickableObjects)
        {
            //button.SetActive(buttonStatus);
            if (!button.Equals(null)) button.GetComponent<Button>().interactable=buttonStatus;
        }
        if (backButton.Equals(null)) return;
        backButton.SetActive(buttonStatus);
        //Debug.Log(buttonStatus);
    }
    public void UpdateButtonPuzzle(bool status)
    {
        puzzleStatus = status;
        UpdateButtonActive();
    }

}
