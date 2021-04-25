using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class AttackController : MonoBehaviour
{
    private float interval, currentInterval = 0;

    private int currentAmmo, maxAmmo;

    private bool canFire = true;

    public Text ammoLabel, rateOfFireLabel;
    private SubmarineUpgradeData upgradeLevel;
    private AudioSource gunshot;

    // Start is called before the first frame update
    void Start()
    {
        ApplyUpgrade();
        gunshot = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            currentInterval += Time.deltaTime * 1000;

            if (currentInterval >= interval)
            {
                if (canFire)
                {
                    Debug.Log("fire!");
                    FireBullet();

                    gunshot.Play();

                    currentInterval = 0;
                    currentAmmo--;
                }

                if (currentAmmo == 0)
                {
                    StartCoroutine(Reload());
                }
            }
        }
    }

    void OnGUI()
    {
        ammoLabel.text = $"Ammo: {currentAmmo}";
    }

    private IEnumerator Reload()
    {
        canFire = false;

        yield return new WaitForSecondsRealtime(1.5f);

        currentAmmo = maxAmmo;
        canFire = true;
    }

    public void ApplyUpgrade()
    {
        upgradeLevel = GetComponent<SubmarineUpgradeManager>().CurrentUpgrade;

        interval = (60 / upgradeLevel.RoundsPerMinute) * 1000;

        rateOfFireLabel.text = $"ROF: {upgradeLevel.RoundsPerMinute}";

        maxAmmo = currentAmmo = upgradeLevel.MagazineCapacity;
    }

    private void FireBullet()
    {
        var ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));

        Debug.DrawRay(ray.origin, Camera.main.transform.forward * 100000, Color.yellow, 0.5f);

        if (Physics.Raycast(ray, out var hit, 200, 1 << 6))
        {
            var targetTransform = hit.transform;

            Debug.Log($"hit {targetTransform.name}");

            var attackable = targetTransform.gameObject.GetComponent<IAttackable>();

            if (attackable == null)
                return;

            attackable.Attack(new AttackInfo
            {
                Damage = 20
            });
        }
    }
}
