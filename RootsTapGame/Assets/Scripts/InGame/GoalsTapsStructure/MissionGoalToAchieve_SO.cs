using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Mission/GoalToAchieve", fileName = "_MissionGoal")]
public class MissionGoalToAchieve_SO : ScriptableObject
{
    /// <summary>
    /// Total taps to achieve the mission goal.
    /// </summary>
    [SerializeField]
    private int totalTaps;

    public int TotalTaps { get => totalTaps; set => totalTaps = value; }

    [SerializeField]
    private List<RewardMission> rewards;
}
