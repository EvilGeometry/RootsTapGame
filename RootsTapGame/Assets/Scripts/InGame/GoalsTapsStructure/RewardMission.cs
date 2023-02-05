using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TypeReward {ShipParts, HumanityTreasure, PowerUps}
public enum StatusReward {NoObtained, Obtained}

public class RewardMission : ScriptableObject
{
    [SerializeField]
    private StatusReward currentStatusReward;

    [SerializeField]
    private TypeReward typeReward;

    public TypeReward TypeReward { get => typeReward; set => typeReward = value; }
    public StatusReward CurrentStatusReward { get => currentStatusReward; set => currentStatusReward = value; }

    public virtual void UnlockReward(){CurrentStatusReward = StatusReward.Obtained;}
}
