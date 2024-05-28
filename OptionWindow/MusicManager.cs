using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class MusicManager : MonoBehaviour
{
    [SerializeField] private Slider _musicSlider;
    private AudioSource _audioSource;

    private const string MUSIC_TAG = "Music";

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();

        _musicSlider.value = PlayerPrefs.HasKey(MUSIC_TAG) ? PlayerPrefs.GetFloat(MUSIC_TAG) : 0.0f;
        _audioSource.volume = _musicSlider.value;

        _musicSlider.onValueChanged.AddListener(delegate { ChangeVolume(); });
    }

    private void ChangeVolume()
    {
        _audioSource.volume = _musicSlider.value;
        PlayerPrefs.SetFloat(MUSIC_TAG, _musicSlider.value);
    }
}
