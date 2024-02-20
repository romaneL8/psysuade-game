using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatPrefab : MonoBehaviour
{
    public int band;
    public float startScale, scaleMultiplier;
    public GameObject beatProjectile;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(transform.localScale.x, (AudioPeer.freqBand[band] * scaleMultiplier) + startScale, transform.localScale.z);
        GameObject go = Instantiate(beatProjectile);
        go.transform.position = this.transform.position;
    }
}
