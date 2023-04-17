using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThiefInHome : MonoBehaviour
{
    [SerializeField] private AudioSource _audio;
    private float _noise = 1f;

    private void Start()
    {
        _audio.volume = _noise;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Thief>(out Thief player))
        {
            _audio.Play();
        }
    }
}
