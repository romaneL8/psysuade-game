using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowOnBeat : MonoBehaviour
{
    public Transform target;
    private float currentSize;
    public float growSize, shrinkSize;
    [Range(0.8f, 0.99f)]
    public float shrinkFactor;
    [Range(0, 3)]
    public int onFullBeat;
    [Range(0, 7)]
    public int[] onBeatD8;
    private int beatCountFull;

    // Start is called before the first frame update
    void Start()
    {
        if (target == null)
        {
            target = this.transform;
        }
        currentSize = shrinkSize;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentSize > shrinkSize)
        {
            currentSize *= shrinkFactor;
        }
        else
        {
            currentSize = shrinkSize;
        }
        CheckBeat();
        target.localScale = new Vector3(target.localScale.x, currentSize, target.localScale.z);

    }

    void Grow()
    {
        currentSize = growSize;
    }

    void CheckBeat()
    {
        beatCountFull = BPM.beatCountFull % 4;
        for (int i = 0; i < onBeatD8.Length; i++)
        {
            if (BPM.beatD8 && beatCountFull == onFullBeat && BPM.beatCountD8 % 8 == onBeatD8[i])
            {
                Grow();
            }
        }
    }
}
