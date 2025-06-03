using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour


{

    public Camera camera;
    public void DisableAudio()
    {
        camera.GetComponent<AudioListener>().enabled = true;

    }
    public void EnableAudio()
    {
        camera.GetComponent<AudioListener> ().enabled  =  false;

    }
    
}
