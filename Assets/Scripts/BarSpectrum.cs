// By Novang

using UnityEngine;
using System.Collections;

public class BarSpectrum : MonoBehaviour
{
    float[] spectrum = new float[1024], avg = new float[32];
    float pre_avg = 0f;
    int cnt_n, cnt_m;
    public bool beat;

    AudioSource _AS;
    public GameObject[] _BS;

    // Use this for initialization
    void Start()
    {
        _AS = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        beat = false;
        cnt_n = 0;
        cnt_m = 31;
        _AS.GetSpectrumData(spectrum, 0, FFTWindow.Hamming);

        for(int i = 0; i <= 31; i++) {
            for (int a = cnt_n; a <= cnt_m; a++)
            {
                avg[i] = avg[i] + spectrum[a];
            }
            cnt_n = cnt_n + 32;
            cnt_m = cnt_m + 32;
            avg[i] = (avg[i] / 32) * 5 * i * i;
            if (avg[i] >= 20)
            {
                _BS[i].transform.localScale = new Vector3(1f, 20f, 1f);
            }
            else
            {
                _BS[i].transform.localScale = new Vector3(1f, avg[i], 1f);
            }

            if (avg[16] - pre_avg >= 2f)
            {
                beat = true;
            }

            pre_avg = avg[16];
            avg[i] = 0f;
        }

    }
}
