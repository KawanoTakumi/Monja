using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SE : MonoBehaviour
{
    private AudioSource audioSourceSE;
    public AudioClip se;
    

    public static SE Instance
    {
        get; private set;
    }

    void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    private void Start()
    {
       // audioSourceSE = this.GetComponent();
    }

    // Update is called once per frame
    public void SettingPlaySE()
    {
        audioSourceSE.PlayOneShot(se);
    }
}
