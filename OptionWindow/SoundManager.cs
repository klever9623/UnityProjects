using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public Slider SoundSlider;
    private const string SOUND_TAG = "Sound";

    private void Start()
    {
        SoundSlider.value = PlayerPrefs.HasKey(SOUND_TAG) ? PlayerPrefs.GetFloat(SOUND_TAG) : 0.0f;
        SoundSlider.onValueChanged.AddListener(delegate { ChangeVolume(); });
    }

    private void ChangeVolume() => PlayerPrefs.SetFloat(SOUND_TAG, SoundSlider.value);
}
