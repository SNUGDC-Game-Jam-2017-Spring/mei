using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SoundState {Jump, Land, Meow};

public class SoundPlayer : MonoBehaviour {

    AudioSource audio;
    public AudioClip CatJump;
    public AudioClip CatLand;
    public AudioClip CatMeow1;
    public AudioClip CatMeow2;
    public AudioClip CatMeow3;

    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    public void PlayClip(SoundState state)
    {
        audio.Stop();
        switch (state)
        {
            case SoundState.Jump:{ audio.clip = CatJump; break; }
            case SoundState.Land: { audio.clip = CatLand; break;}
            case SoundState.Meow:
                {
                    int rand = Random.Range((int)1, (int)4);
                    switch (rand)
                    {
                        case 1: { audio.clip = CatMeow1; break; }
                        case 2: { audio.clip = CatMeow2; break; }
                        case 3: { audio.clip = CatMeow3; break; }
                    }
                    break;
                }
        }
        audio.pitch = Random.Range(0.95f, 1.05f);
        audio.Play();        
    }

	
	// Update is called once per frame
	void Update () {
		
	}

}
