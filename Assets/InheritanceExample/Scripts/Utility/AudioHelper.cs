using UnityEngine;

public static class AudioHelper
{
    public static AudioSource PlayClip2D(AudioClip clip,
        float volume = 1, float pitchRange = .03f)
    {
        pitchRange = Mathf.Clamp(pitchRange, 0, 1);
        // create
        GameObject audioObject = new GameObject("2DAudio");
        AudioSource audioSource = audioObject.AddComponent<AudioSource>();
        //configure
        audioSource.clip = clip;
        audioSource.volume = volume;
        audioSource.pitch = 1 + Random.Range(-pitchRange, pitchRange);
        // activate
        audioSource.Play();
        Object.Destroy(audioObject, clip.length);
        // return in case the caller wants to do other things
        return audioSource;
    }

    public static AudioSource PlayClip3D(AudioClip clip, Vector3 position,
        float volume = 1, float pitchRange = .03f)
    {
        pitchRange = Mathf.Clamp(pitchRange, 0, 1);
        // create
        GameObject audioObject = new GameObject("3DAudio");
        AudioSource audioSource = audioObject.AddComponent<AudioSource>();
        //configure
        audioSource.clip = clip;
        audioSource.volume = volume;
        audioSource.pitch = 1 + Random.Range(-pitchRange, pitchRange);
        audioSource.spatialBlend = 1;
        audioObject.transform.position = position;
        // activate
        audioSource.Play();
        Object.Destroy(audioObject, clip.length);
        // return in case the caller wants to do other things
        return audioSource;
    }
}
