using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameExecutor : MonoBehaviour
{
    [SerializeField]
    private Image backgroundGame;

    [SerializeField]
    private int indexStepMission = 0;

    [SerializeField]
    private Transform canvasGame;

    [SerializeField]
    private GameObject panelMissionFinished;

    ControllerStep stepMission;

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
        if (IndexStepMission >= currentStepMisison.MissionsList.Length)
        {
            Debug.Log("==>Mission finished, all steps finished");
            //Back to map menu
            panelMissionFinished.gameObject.SetActive(true);
        }
        else
        {
            backgroundGame.sprite = currentStepMisison.MissionsList[IndexStepMission].backgroundMissionStep;
            GameObject gameObjStepMission = Instantiate(currentStepMisison.MissionStepGame, canvasGame);
            gameObjStepMission.transform.SetParent(canvasGame);

            stepMission = gameObjStepMission.GetComponent<ControllerStep>();
            stepMission.GameExecutor = this;
            stepMission.SetTapButtons();
        }
    }

    public void StepMissionFinished()
    {
        IndexStepMission++;

        if (CanvasGeneralGame.Instance != null)
        {
            CanvasGeneralGame.Instance.Fade.FadeIn();
        }
        StartCoroutine(PrepareGameWhenFinish());
    }

    IEnumerator PrepareGameWhenFinish()
    {
        yield return new WaitForSeconds(1f);

        if (stepMission != null)
        {
            Destroy(stepMission.gameObject);
            stepMission = null;
        }

        StartCoroutine(Start());
    }

    /// <summary>
    /// When the button is pressed and assign the mission to be played
    /// and loads the game scene.
    /// </summary>
    public void LoadSceneString(string sceneName)
    {
        //CanvasGeneralGame.Instance.Fade.FadeIn();
        GameController.Instance.CurrentStatusGame = StatusGame.Idle;
        StartCoroutine(LoadScene(sceneName));
    }

    IEnumerator LoadScene(string sceneName)
    {
        yield return new WaitForSeconds(1.5f);

        AsyncOperation async = SceneManager.LoadSceneAsync(sceneName);

        while (!async.isDone)
        {
            yield return null;
        }
    }
}
