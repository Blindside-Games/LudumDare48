using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderwaterEffect : MonoBehaviour
{
    // Start is called before the first frame update
    public Color fogColor;

    public Material planeMaterial;

    void Start()
    {
        planeMaterial.color = new Color(planeMaterial.color.r, planeMaterial.color.g, planeMaterial.color.b, 0);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LevelChanged(int level)
    {
        Debug.Log(level);

        var color = new Color(planeMaterial.color.r, planeMaterial.color.g, planeMaterial.color.b, level * 0.2f);

        planeMaterial.color = color;
    }
}
