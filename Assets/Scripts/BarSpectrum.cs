// By Novang

using UnityEngine;
using System.Collections;

public class BarSpectrum : MonoBehaviour
{
    float[] spectrum = new float[68], avg = new float[17];
    int cnt = 1;

    AudioSource _AS;
    GameObject[] _BS;

    // Use this for initialization
    void Start()
    {
        _AS = GetComponent<AudioSource>();
        _BS = GameObject.FindGameObjectsWithTag("Bar");
    }

    // Update is called once per frame
    void Update()
    {
        cnt = 1;
        _AS.GetSpectrumData(spectrum, 0, FFTWindow.BlackmanHarris);

        // Input Data
        for (int i = 0; i <= 16; i++)
        {
            // Avg
            for (int k = cnt; k <= cnt + 3; k++)
            {
                avg[i] = avg[i] + spectrum[k];
                cnt = k;
            }
            avg[i] = avg[i] / 4;
            
        }
    }
}
