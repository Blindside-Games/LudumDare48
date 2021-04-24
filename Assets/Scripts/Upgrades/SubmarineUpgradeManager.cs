using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SubmarineUpgradeManager : MonoBehaviour
{
    public SubmarineUpgradeData CurrentUpgrade;

    public UnityEvent UpgradeCollected;

    public void Collect(SubmarineUpgradeData upgradeData)
    {
        CurrentUpgrade = upgradeData;

        UpgradeCollected.Invoke();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
