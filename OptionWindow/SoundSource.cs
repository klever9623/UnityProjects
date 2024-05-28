using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundSource : MonoBehaviour
{
    [SerializeField] private SoundManager _soundManager;
    [SerializeField] private AudioSource _audioSource;

    private void Start()
    {
        _soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();

        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = _soundManager.SoundSlider.value;
    }

    private void FixedUpdate() => _audioSource.volume = _soundManager.SoundSlider.value;
}
