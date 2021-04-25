using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UpgradeType
{
    Hull,
    Weapons
}

[CreateAssetMenu(menuName = "Upgrade")]
public class SubmarineUpgradeData : ScriptableObject
{
    public UpgradeType Type;

    public float RoundsPerMinute;
    public int MagazineCapacity;

    public float HullMaxDepth;
}
