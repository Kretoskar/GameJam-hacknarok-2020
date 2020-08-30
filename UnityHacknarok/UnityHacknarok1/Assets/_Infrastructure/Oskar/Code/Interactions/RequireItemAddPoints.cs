using System.Collections;
using System.Collections.Generic;
using Infrastructure;
using Infrastructure.Interactions;
using Infrastructure.LevelManagement;
using UnityEngine;

public class RequireItemAddPoints : InteractionRequireItem
{
    [SerializeField] private AudioClip _audio;
    [SerializeField] private int _addPoints;
    [SerializeField] private int _addTime;

    private AudioSource _audioSource;

    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public override void Interact()
    {
        base.Interact();

        if (_hasItem)
        {
            Timer.Instance.AddTime(_addTime);
            ScoreManager.Instance.AddScore(_addPoints);
            
            _audioSource.PlayOneShot(_audio);
        }
    }
}
