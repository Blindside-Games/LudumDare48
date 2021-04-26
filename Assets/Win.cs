using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{

    private AudioSource winSound;
    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = Vector3.zero;
        winSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void WinGame()
    {
        transform.localScale = Vector3.one;
        Time.timeScale = 0;
        winSound.Play();
    }
}
