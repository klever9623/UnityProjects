using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSound : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    private void OnMouseDown() => _audioSource.Play();
}
