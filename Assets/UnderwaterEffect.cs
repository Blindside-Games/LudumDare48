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

        StartCoroutine(LerpPlaneAlpha(level));
    }

    private IEnumerator LerpPlaneAlpha(int level)
    {
        var elaspedTime = 0f;
        var duration = 1f;
        var startValue = planeMaterial.color.a;
        var endValue = level * 0.2f;

        while (elaspedTime < duration)
        {
            elaspedTime += Time.deltaTime;

            var newAlpha = Mathf.Lerp(startValue, endValue, elaspedTime / duration);
            var color = new Color(planeMaterial.color.r, planeMaterial.color.g, planeMaterial.color.b, newAlpha);

            planeMaterial.color = color;

            yield return null;
        }
    }
}
