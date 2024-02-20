using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongConductor : MonoBehaviour
{
    public float songBpm;
    public float secPerBeat;
    public float songPosition;
    public float songPositionInBeats;
    public float dspSongTime;
    public AudioSource musicSource;

    public float firstBeatOffset;

    //float bpm;
    //float[] notes;
    //int nextIndex = 0;

    public GameObject beatProjectile;

    // Start is called before the first frame update
    void Start()
    {
        musicSource = GetComponent<AudioSource>();
        secPerBeat = 60f / songBpm;
        dspSongTime = (float)AudioSettings.dspTime;
        musicSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        //songPosition = (float)(AudioSettings.dspTime - dspSongTime);
        songPosition = (float)(AudioSettings.dspTime - dspSongTime - firstBeatOffset);
        songPositionInBeats = songPosition / secPerBeat;

        //if (nextIndex < notes.Length && notes[nextIndex] < songPositionInBeats)
        //{
        //    Instantiate(beatProjectile);
        //    nextIndex++;
        //}

        InvokeRepeating("ShootBeats", 0, secPerBeat);
    }

    void ShootBeats()
    {
        Instantiate(beatProjectile);
    }
}
