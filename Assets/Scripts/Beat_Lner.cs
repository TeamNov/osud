// By Novang

using UnityEngine;
using System.Collections;

public class Beat_Lner : MonoBehaviour {
    int frame_skip = 0;
    bool beats = false;

    public AudioSpectrum AudioSp;
    Animation anim;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animation>();
        
	}
	
	// Update is called once per frame
	void Update () {
        beats = AudioSp.beat;
        if(frame_skip == 0) {
            if (beats == true)
            {
                anim.Stop();
                anim.Play();
            }
            frame_skip = 0;
        }else {
            frame_skip--;
        }
    }
}
