using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditorInternal;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public static SFXManager instance;
    [SerializeField] private AudioSource SFXObject;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void PlaySFXClip(AudioClip audioClip, Transform spawnTransform, float volume)
    {
        AudioSource source = Instantiate(SFXObject, spawnTransform.position, Quaternion.identity);

        source.clip = audioClip;

        source.volume = volume;

        source.Play();

        float clipLength = source.clip.length;

        Destroy(source.gameObject, clipLength);
    }
}
