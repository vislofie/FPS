using System;
using UnityEngine;

namespace MVS.Static
{
    public static class PlayerInput
    {
        private static PlayerInputAction _inputAction = new PlayerInputAction();

        #region Main actions
        public static event Action<Vector2> Movement = delegate { };
        public static event Action<Vector2> Rotation = delegate { };
        public static event Action OnShoot = delegate { };
        #endregion

        #region Selecting weapons actions
        public static event Action<int> OnWeaponSelected = delegate { };
        #endregion


        public static void Initialize()
        {
            _inputAction.Enable();

            LockCursor();
            InitializeMainActions();
            InitializeWeaponSelectingActions();
        }

        public static void LockCursor()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        public static void UnlockCursor()
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }

        private static void InitializeMainActions()
        {
            _inputAction.Main.Movement.performed += context => { Movement(context.ReadValue<Vector2>()); };
            _inputAction.Main.Movement.canceled  += context => { Movement(context.ReadValue<Vector2>()); };

            _inputAction.Main.Rotation.performed += context => { Rotation(context.ReadValue<Vector2>()); };

            _inputAction.Main.Shoot.performed    += context => { OnShoot(); };
        }

        private static void InitializeWeaponSelectingActions()
        {
            _inputAction.SelectingWeapons.SelectFirst.performed  += context => { OnWeaponSelected(0); };
            _inputAction.SelectingWeapons.SelectSecond.performed += context => { OnWeaponSelected(1); };
            _inputAction.SelectingWeapons.SelectThird.performed  += context => { OnWeaponSelected(2); };
            _inputAction.SelectingWeapons.SelectFourth.performed += context => { OnWeaponSelected(3); };
            _inputAction.SelectingWeapons.SelectFifth.performed  += context => { OnWeaponSelected(4); };
        }
    }
}
