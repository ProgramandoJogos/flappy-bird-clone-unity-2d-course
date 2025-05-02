using UnityEngine;

public class MusicController : MonoBehaviour
{
    private static GameObject Instance;
    public AudioSource MusicAudioSource;

    void Start()
    {
        if(MusicController.Instance == null)
        {
            MusicController.Instance = gameObject;
        }

        if(MusicController.Instance != gameObject)
        {
            Destroy(gameObject);
            return;
        }

        PlayMusic();
        DontDestroyOnLoad(gameObject);
    }

    private void PlayMusic()
    {
        MusicAudioSource.Play();
    }
}
