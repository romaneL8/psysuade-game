using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBeats : MonoBehaviour
{
    public GameObject sampleBeatPrefab;
    GameObject[] sampleBeat = new GameObject[512];
    public float maxScale;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 512; i++)
        {
            GameObject _instanceSampleBeat = (GameObject)Instantiate(sampleBeatPrefab);
            _instanceSampleBeat.transform.position = this.transform.position;
            _instanceSampleBeat.transform.parent = this.transform;
            _instanceSampleBeat.name = "SampleBeat" + i;
            this.transform.eulerAngles = new Vector3(0, -0.703125f * i, 0);
            _instanceSampleBeat.transform.position = Vector3.forward * 100;
            sampleBeat[i] = _instanceSampleBeat;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 512; i++)
        {
            if (sampleBeat != null)
            {
                sampleBeat[i].transform.localScale = new Vector3(10, (AudioPeer.samples[i] * maxScale) + 2, 10);
            }
        }
    }
}
