using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameExecutor : MonoBehaviour
{
    [SerializeField]
    private Image backgroundGame;

    [SerializeField]
    private int indexStepMission = 0;

    IEnumerator Start()
    {
        yield return new WaitForSeconds(0.5f);
        SetStepMission();

        if (CanvasGeneralGame.Instance != null)
        {
            CanvasGeneralGame.Instance.Fade.FadeOut();
        }
    }

    /// <summary>
    /// Method called from a signal in timeline.
    /// </summary>
    [ContextMenu("SetStepMission")]
    public void SetStepMission()
    {
        if (GameController.Instance != null)
        {
            SetStepMission(GameController.Instance.CurrentMissionToPlay);
        }
    }

    public void SetStepMission(MissionInfo_SO currentStepMisison)
    {
        backgroundGame.sprite = currentStepMisison.MissionsList[indexStepMission].backgroundMissionStep;
    }
}
