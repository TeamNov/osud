// By Novang

using UnityEngine;
using System.Collections;

public class BarSpectrum : MonoBehaviour
{
    public float[] spectrum = new float[1024], avg = new float[32];
    float pre_spc = 0f;
    int cnt_n, cnt_m;
    public bool beat = false;

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
        _AS.GetSpectrumData(spectrum, 0, FFTWindow.BlackmanHarris);

        for(int i = 0; i <= 31; i++) {
            for (int a = cnt_n; a <= cnt_m; a++)
            {
                avg[i] = avg[i] + spectrum[a];
            }
            cnt_n = cnt_n + 32;
            cnt_m = cnt_m + 32;
            avg[i] = (avg[i] / 32) * 250 * ((i+2)/2);
            if (avg[i] >= 20)
            {
                _BS[i].transform.localScale = new Vector3(1f, 20f, 1f);
            }
            else
            {
                _BS[i].transform.localScale = new Vector3(1f, avg[i], 1f);
            }

            if (avg[0] - pre_spc >= 5f)
            {
                beat = true;
            }
            pre_spc = avg[0];
            avg[i] = 0f;
        }

    }
}
