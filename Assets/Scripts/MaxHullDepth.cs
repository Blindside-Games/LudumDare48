using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaxHullDepth : MonoBehaviour
{
    public StatsController player;

    private Text text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void OnGUI()
    {
        text.text = $"Max: {player.MaxHullDepth}m";
    }
}
