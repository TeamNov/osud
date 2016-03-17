// By Novang

using UnityEngine;
using System.Collections;

public class AudioSpectrum : MonoBehaviour {
    public bool beat = false;
    float Threshold = 0.05f;
    float[] spectrum = new float[64], cur_avg = new float[4], pre_avg = new float[4];
    int _onB = 0;

    AudioSource _AS;

    // Use this for initialization
    void Start () {
        _AS = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        for (int f = 0; f <= 3; f++)
        {
            pre_avg[f] = cur_avg[f];
        }
        cur_avg[0] = cur_avg[1] = cur_avg[2] = cur_avg[3] = 0f;
        _AS.GetSpectrumData(spectrum, 1, FFTWindow.Blackman);

        // Low-Range Frequency
        for (int i = 0; i <= 5; i++)
        {
            cur_avg[0] = cur_avg[0] + spectrum[i];
        }
        cur_avg[0] = cur_avg[0] / 6;

        // Mid-Range Frequency
        for (int i = 5; i <= 10; i++)
        {
            cur_avg[1] = cur_avg[1] + spectrum[i];
        }
        cur_avg[1] = cur_avg[1] / 6;

        // High-Range Frequency
        for (int i = 11; i <= 16; i++)
        {
            cur_avg[2] = cur_avg[2] + spectrum[i];
        }
        cur_avg[2] = cur_avg[2] / 6;

        // High-Range Frequency
        for (int i = 17; i <= 22; i++)
        {
            cur_avg[3] = cur_avg[3] + spectrum[i];
        }
        cur_avg[3] = cur_avg[3] / 6;

        for (int k = 0; k <= 3; k++)
        {
            if (cur_avg[k] - pre_avg[k] >= Threshold) {
                _onB++;
            }
        }
        if(_onB >= 1) {
            beat = true;
        }
        else {
            beat = false;
        }
        _onB = 0;
    }
}
