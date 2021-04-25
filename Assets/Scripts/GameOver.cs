using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    private Text text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();

        text.transform.localScale = Vector3.zero;
    }

    public void End()
    {
        text.transform.localScale = Vector3.one;
        Time.timeScale = 0;
    }
}
