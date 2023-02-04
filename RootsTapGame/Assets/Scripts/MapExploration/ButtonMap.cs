using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonMap : MonoBehaviour
{
    [SerializeField]
    private Button button;

    /// <summary>
    /// The mission that is assigned to the button in the map.
    /// </summary>
    [SerializeField]
    private MissionInfo_SO missionInfo;

    IEnumerator Start()
    {
        yield return new WaitForSeconds(0.8f);
        button.onClick.AddListener(CanvasGeneralGame.Instance.Fade.FadeIn);    
    }
    
    /// <summary>
    /// When the button is pressed and assign the mission to be played
    /// and loads the game scene.
    /// </summary>
    public void StartMission(string sceneName)
    {
        GameController.Instance.CurrentMissionToPlay = missionInfo;
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
