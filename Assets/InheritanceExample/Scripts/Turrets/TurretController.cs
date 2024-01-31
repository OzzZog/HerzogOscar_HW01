using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    [SerializeField] private TouchInput _input;
    [SerializeField] private List<Turret> _turrets = new List<Turret>();
    [SerializeField] private GameObject _aimIndicator;

    public float FireCooldown { get; set; } = .5f;

    public bool IsReadyToFire { get; private set; } = true;

    private Camera _camera;
    private float _elapsedCooldownTime;

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void TrackCooldown()
    {
        if (IsReadyToFire == false)
        {
            _elapsedCooldownTime += Time.deltaTime;
            if (_elapsedCooldownTime >= FireCooldown)
            {
                IsReadyToFire = true;
            }
        }
    }

    private void Update()
    {
        TrackCooldown();

        if (_turrets == null || _turrets.Count == 0) return;

        // if input is held, shoot
        if (_input.TouchIsHeld)
        {
            // attempt raycast
            RaycastHit hit;
            Ray ray = _camera.ScreenPointToRay(_input.TouchScreenPosition);
            if (Physics.Raycast(ray, out hit))
            {
                // display the aim indicator
                _aimIndicator.SetActive(true);
                _aimIndicator.transform.position = hit.point;
                // fire zeh missiles
                if (IsReadyToFire)
                {
                    ActivateTurrets(hit.point);
                }
            }
        }
        else
        {
            _aimIndicator.SetActive(false);
        }
    }

    private void ActivateTurrets(Vector3 targetPos)
    {
        foreach (Turret turret in _turrets)
        {
            Vector3 targetPosition = new Vector3(targetPos.x,
                turret.transform.position.y, targetPos.z);
            turret.transform.LookAt(targetPosition);
            //Debug.Log("Fire");
            turret.Fire();
            StartCooldown();
        }
    }

    private void StartCooldown()
    {
        IsReadyToFire = false;
        _elapsedCooldownTime = 0;
    }
}
