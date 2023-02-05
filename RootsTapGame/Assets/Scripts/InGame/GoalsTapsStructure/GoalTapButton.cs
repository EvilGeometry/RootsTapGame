using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalTapButton : MonoBehaviour
{
    Button tapButton;

    [SerializeField]
    private int tapsToAchieve;

    [SerializeField]
    private int currentTapsButton;

    ControllerStep controllerStep;

    public int TapsToAchieve { get => tapsToAchieve; set => tapsToAchieve = value; }
    public ControllerStep ControllerStep { get => controllerStep; set => controllerStep = value; }

    // Start is called before the first frame update
    void Start()
    {
        tapButton = GetComponent<Button>();
    }

    /// <summary>
    /// Method called from the button OnClick event.
    /// </summary>
    public void Tapping()
    {
        if (GameController.Instance.CurrentStatusGame != StatusGame.Play)
            return;
        
        ControllerStep.CurrentTaps++;
        currentTapsButton++;
        if(currentTapsButton >= TapsToAchieve)
        {
            tapButton.interactable = false;
            Debug.Log("==>Tap button disabled!, check step mission status!");
            ControllerStep.CheckStatusStep();
        }
    }
}
