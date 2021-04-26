using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class SubmarineUpgradeManager : MonoBehaviour
{
    public SubmarineUpgradeData CurrentUpgrade;

    public UnityEvent<SubmarineUpgradeData> UpgradeCollected;


    public AudioSource upgradeSound;

    public void Collect(SubmarineUpgradeData upgradeData)
    {
        CurrentUpgrade = upgradeData;

        upgradeSound.Play();

        UpgradeCollected.Invoke(upgradeData);
    }

    // Start is called before the first frame update
    void Start()
    {
        upgradeSound = GetComponents<AudioSource>().First(a => a.clip.name.Equals("Upgrade-sound"));
    }

    // Update is called once per frame
    void Update()
    {

    }
}
