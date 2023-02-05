using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MissionStatus{Disable, Enable, Completed }

[CreateAssetMenu(menuName = "Mission/MissionData", fileName = "MissionData")]
public class MissionInfo_SO : ScriptableObject
{
    [SerializeField]
    private MissionStatus missionStatus;

    /// <summary>
    /// The prefab tha will be played.
    /// </summary>
    [SerializeField]
    private GameObject missionStepGame;

    /// <summary>
    /// A list with the missions steps to be played.
    /// </summary>
    [SerializeField]
    private MissionStepStructure[] missionsList;

    public MissionStepStructure[] MissionsList { get => missionsList;}
    public GameObject MissionStepGame { get => missionStepGame; set => missionStepGame = value; }
}

[System.Serializable]
public class MissionStepStructure
{
    /// <summary>
    /// The background of the step mission.
    /// </summary>
    public Sprite backgroundMissionStep;
    /// <summary>
    /// The mission goal to achieve and get rewards.
    /// </summary>
    public MissionGoalToAchieve_SO missionGoalToAchieve;
}
