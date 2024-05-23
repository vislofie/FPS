using MVS.Static;
using UnityEngine;

public class PlayerWeaponManagement : MonoBehaviour
{
    [SerializeField]
    private Transform[] _weapons = new Transform[5];
    private int _activeWeaponIndex = -1;

    private void Awake()
    {
        PlayerInput.OnWeaponSelected += SelectWeapon;
    }

    private void SelectWeapon(int slotIndex)
    {
        for (int i = 0; i < _weapons.Length; i++)
        {
            if (_weapons[i] != null)
            {
                _weapons[i].gameObject.SetActive(false);
            }
        }

        if (_weapons[slotIndex] != null)
        {
            _activeWeaponIndex = slotIndex;
            _weapons[slotIndex].gameObject.SetActive(true);
        }
    }

    private void ExamineMagazine()
    {

    }

    private void ExamineWeapon()
    {

    }
}
