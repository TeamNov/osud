// By Novang

using UnityEngine;
using System.Collections;

public class Beat_Lner : MonoBehaviour {

    public BarSpectrum AudioSp;
    Animation anim;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animation>();
	}
	
	// Update is called once per frame
	void Update () {
        animation[""].speed = 0f;
        if (AudioSp.beat == true)
        {
            anim.Play();
        }
    }
}
