using System.Collections;
using UnityEngine;
using TMPro;

public class GunScript : MonoBehaviour, IGun
{
    private ShootingScript _shootingScript;

    [field: SerializeField] public GameObject Bullet { get; set; }
    [field: SerializeField] public Transform BulletSpawner { get; set; }
    [field: SerializeField] public float BulletForce { get; set; }
    [field: SerializeField] public float Spread { get; set; }
    [field: SerializeField] public float ShootDelay { get; set; }
    [field: SerializeField] public int BulletCount { get; set; }
    [field: SerializeField] public int BulletClip { get; set; }
    [field: SerializeField] public bool Automatic { get; set; }

    [SerializeField] private TextMeshProUGUI _bulletClipText;
    private bool _isActive;

    private void Start() =>
        _shootingScript = GetComponentInParent<ShootingScript>();

    private void OnEnable()
    {
        _bulletClipText.text = "Кол - во патронов: " + BulletClip;
        _isActive = true;
    }

    private void Update()
    {
        if (_isActive && BulletClip > 0 && (Input.GetMouseButtonDown(0) || (Automatic && Input.GetMouseButton(0))))
        {
            _shootingScript.Shoot(this);
            _bulletClipText.text = "Кол - во патронов: " + BulletClip;

            _isActive = false;
            StartCoroutine(ShootGunDelay());
        }
    }

    private IEnumerator ShootGunDelay()
    {
        yield return new WaitForSeconds(ShootDelay);
        _isActive = true;
    }
}
