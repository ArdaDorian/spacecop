using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuidioPlayer : MonoBehaviour
{
    [Header("Shooter")]
    [SerializeField] AudioClip[] shootingClips;
    [SerializeField] [Range(0f, 1f)] float shootingVolume = 1f;

    [Header("Damage")]
    [SerializeField] AudioClip[] damagingClips;
    [SerializeField] [Range(0f,1f)] float damagingVolume = 1f;

    [Header("Destroy")]
    [SerializeField] AudioClip[] destroyingClips;
    [SerializeField][Range(0f, 1f)] float destroyingVolume = 1f;

    OptionsManager options;

    private void Awake()
    {
        options= FindObjectOfType<OptionsManager>();
    }

    private void Start()
    {
        GetComponent<AudioSource>().enabled= options.GetMusicStatues();
    }

    private void Update()
    {
        GetComponent<AudioSource>().enabled = options.GetMusicStatues();
    }

    public void PlayShootingClip()
    {
        SoundPlayer(shootingClips, shootingClips.Length, shootingVolume);
    }

    public void PlayDamagingClip()
    {
        SoundPlayer(damagingClips,damagingClips.Length,damagingVolume);
    }

    public void PlayDestroyingClip()
    {
        SoundPlayer(destroyingClips,destroyingClips.Length,destroyingVolume);
    }

    void SoundPlayer(AudioClip[] clips, int clipsLength, float volume)
    {
        if (clips != null && options.GetSoundStatues())
        {
            AudioSource.PlayClipAtPoint(clips[Random.Range(0, clipsLength)],
                                        Camera.main.transform.position,
                                        volume);
        }
    }
}
