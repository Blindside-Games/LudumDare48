using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatBar : MonoBehaviour
{
    public StatsController stats;

    private Image bar;

    // Start is called before the first frame update
    void Start()
    {
        bar = GetComponent<Image>();
    }

    // Update is called once per frame
    void OnGUI()
    {
        bar.fillAmount = 1 / (stats.maxHealth / stats.currentHealth);
    }
}
