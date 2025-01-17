using System;
using UnityEngine;

namespace Minigames.CrazyControls
{
    public class CrazyMoveController : MonoBehaviour
    {

        [SerializeField] private Rigidbody2D rb;
        [SerializeField] private float speed;
        private Vector2 _direction;

        public Vector2 Direction => _direction;

        [HideInInspector]public bool moveRight;
        [HideInInspector]public bool moveUp;
        [HideInInspector]public bool moveDown;
        [HideInInspector]public bool moveLeft;

        private IMovePreset _currentPreset;

        private readonly NormalMovePreset _normalMovePreset = new NormalMovePreset();
        private readonly PressInversionMovePreset _pressInversionMovePreset = new PressInversionMovePreset();

        public void ButtonRightUp() => _currentPreset.RightUp(this);
        public void ButtonRightDown() => _currentPreset.RightDown(this);
        public void ButtonLeftUp() => _currentPreset.LeftUp(this);
        public void ButtonLeftDown() => _currentPreset.LeftDown(this);
        public void ButtonUpUp() => _currentPreset.UpUp(this);
        public void ButtonUpDown() => _currentPreset.UpDown(this);
        public void ButtonDownUp() => _currentPreset.DownUp(this);
        public void ButtonDownDown() => _currentPreset.DownDown(this);

        public void SetDirection()
        {
            _direction=Vector2.zero;
            if (moveUp) _direction.y++;
            if (moveDown) _direction.y--;
            if (moveRight) _direction.x++;
            if (moveLeft) _direction.x--;
        }

        public void StopMovement() => rb.velocity = Vector2.zero;
        public void Move()=> rb.velocity = _direction * (speed * Time.deltaTime);
        void Start()
        {
            _currentPreset = _normalMovePreset;
        }
    }
}
