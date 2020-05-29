using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.Video;

public class VbuttonManager : MonoBehaviour
{
    public VideoPlayer player;
    //public Renderer rend;
    public GameObject playButton;
    // Start is called before the first frame update
    void Start()
    {
        //playButton = GameObject.Find("btn");
        Debug.Log("I reached in start of image target");
        //rend = 
        var vbbs = GetComponentsInChildren<VirtualButtonBehaviour>();
        for (int i = 0; i < vbbs.Length; ++i)
        {
            vbbs[i].RegisterOnButtonPressed(OnButtonPressed);
            vbbs[i].RegisterOnButtonReleased(OnButtonReleased);
        }
        GetComponent<VirtualButtonBehaviour>().OnTrackerUpdated(this);   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnButtonPressed(VirtualButtonBehaviour vb) {
        player.Play();
        playButton.GetComponent<Renderer>().enabled = false;
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb) {
        player.Pause();
        playButton.GetComponent<Renderer>().enabled = true;
    }
}
