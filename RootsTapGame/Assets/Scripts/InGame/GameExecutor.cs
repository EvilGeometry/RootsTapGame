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

    [SerializeField]
    private Transform canvasGame;

    public int IndexStepMission { get => indexStepMission; set => indexStepMission = value; }

    IEnumerator Start()
    {
        GameController.Instance.CurrentStatusGame = StatusGame.Idle;
        yield return new WaitForSeconds(0.5f);
        SetStepMission();

        if (CanvasGeneralGame.Instance != null)
        {
            CanvasGeneralGame.Instance.Fade.FadeOut();
        }
    }

    /// <summary>
    /// Setup the mission to be played.
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
        backgroundGame.sprite = currentStepMisison.MissionsList[IndexStepMission].backgroundMissionStep;
        GameObject gameObjStepMission = Instantiate(currentStepMisison.MissionStepGame, canvasGame);
        gameObjStepMission.transform.SetParent(canvasGame);
        
        ControllerStep stepMission = gameObjStepMission.GetComponent<ControllerStep>();
        stepMission.GameExecutor = this;
        stepMission.SetTapButtons();

        GameController.Instance.CurrentStatusGame = StatusGame.Play;
    }
}
