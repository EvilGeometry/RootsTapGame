using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerStep : MonoBehaviour
{
    [SerializeField]
    private List<GoalTapButton> tapsButtons;

    [SerializeField]
    private List<GoalTapButton> tapButtonsDisabled;

    [SerializeField]
    private GameExecutor gameExecutor;

    public GameExecutor GameExecutor { get => gameExecutor; set => gameExecutor = value; }

    int totalTapsStepMission;

    [ContextMenu("SetTapButtons")]
    public void SetTapButtons()
    {
        totalTapsStepMission = GameController.Instance.CurrentMissionToPlay.MissionsList[gameExecutor.IndexStepMission].missionGoalToAchieve.TotalTaps;

        int buttonsToUse = Random.Range(4, tapsButtons.Count + 1);
        Debug.Log("==>Buttons to use: " + buttonsToUse);

        int tapsPerButton = totalTapsStepMission / buttonsToUse;
        Debug.Log("==>Tap per button: " + tapsPerButton);

        int missingTaps = totalTapsStepMission - (buttonsToUse * tapsPerButton);
        Debug.Log("==>Missing taps: " + missingTaps);

        int buttonsToDisable = tapsButtons.Count - buttonsToUse;
        Debug.Log("==>Buttons to Disable: " + buttonsToDisable);

        int countButtonsDisabled = 0;
        //Disable buttons randomly
        while (countButtonsDisabled < buttonsToDisable)
        {
            int randButton = Random.Range(0, tapsButtons.Count);

            if (tapsButtons[randButton].gameObject.activeInHierarchy)
            {
                tapsButtons[randButton].gameObject.SetActive(false);
                tapButtonsDisabled.Add(tapsButtons[randButton]);
                tapsButtons.RemoveAt(randButton);

                countButtonsDisabled++;
            }
        }

        foreach (var tapButton in tapsButtons)
        {

        }
    }
}
