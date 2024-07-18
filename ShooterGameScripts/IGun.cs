using UnityEngine;

public interface IGun
{
    GameObject Bullet { get; set; }
    Transform BulletSpawner { get; set; }
    float BulletForce { get; set; }
    float Spread { get; set; }
    float ShootDelay { get; set; }
    int BulletCount { get; set; }
    int BulletClip { get; set; }
    bool Automatic { get; set; }
}