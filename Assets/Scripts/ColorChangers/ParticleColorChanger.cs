using System;
using UnityEngine;

[RequireComponent(typeof(ColorChanger), typeof(Follower))]
public class ParticleColorChanger : MonoBehaviour
{
    private readonly Quaternion Rotation = Quaternion.Euler(-17f, 0f, 0f);

    [SerializeField] private GameObject _particle;
    [SerializeField] private GameMaterial _material;
    
    private ColorChanger _colorChanger;
    private Follower _follower;

    private void Awake()
    {
        _colorChanger = GetComponent<ColorChanger>();
        _follower = GetComponent<Follower>();
    }

    [Obsolete]
    private void OnEnable()
    {
        _follower.Die += OnDie;

        if (_follower is StickmanFollower stickman)
            stickman.BeganDead += OnDie;
    }

    [Obsolete]
    private void OnDisable()
    {
        _follower.Die -= OnDie;

        if (_follower is StickmanFollower stickman)
            stickman.BeganDead -= OnDie;
    }

    [Obsolete]
    private void OnDie(Follower follower)
    {
        GameObject particleSystem = Instantiate(_particle, transform.position, Rotation);
        SpriteRenderer[] particles = particleSystem.GetComponentsInChildren<SpriteRenderer>();

        foreach (var particle in particles)
            particle.color = _material.Get(_colorChanger.Current).color;
    }
}
