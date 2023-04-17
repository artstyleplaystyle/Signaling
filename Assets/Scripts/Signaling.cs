using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Signaling : MonoBehaviour
{
    [SerializeField] private AudioSource _audio;
    [SerializeField] private float _duration;

    private float _soundTime = 0;
    private float _volumeScale;
    private float _runningTime;
    private float _target;
    private float _noise = 1f;
    private float _silence = 0f;

    private void OnTriggerStay2D(Collider2D collision)
    {
        _runningTime += Time.deltaTime;
        _volumeScale = _runningTime / _duration;

        if (_audio.volume == _noise)
        {
            _target = _silence;
            _runningTime = _soundTime;
        }
        else if (_audio.volume == _silence)
        {
            _target = _noise;
            _runningTime = _soundTime;
        }

        _audio.volume = Mathf.MoveTowards(_audio.volume, _target, _volumeScale);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Thief>(out Thief player))
        {
            _audio.Stop();
        }
    }
}