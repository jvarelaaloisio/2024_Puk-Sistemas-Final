using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace AbstractFactory.Enemies
{
    public class Squaris : MonoBehaviour,ICrazyEnemy
    {
        private ICrazyWeapon _weapon;

        [SerializeField]private float _speed;
        [SerializeField] private Vector3 Direction=Vector3.one;
        private GameObject _lastCollision;
        
        private void Update()
        {
            Move();
        }

        public void Move()
        {
            transform.position += new Vector3(_speed*Direction.x, _speed*Direction.y, 0)*Time.deltaTime;
        }

        public void Attack()
        {
            _weapon.Attack();
        }

        public void Death()
        {
            throw new System.NotImplementedException();
        }

        public void SetUp(ICrazyWeapon weapon)
        {
            _weapon = weapon;
        }

        public GameObject GetGameObject() => gameObject;

        private void OnCollisionEnter2D(Collision2D other)
        {
            Debug.Log(other.gameObject);
            ContactPoint2D contact = other.GetContact(0);

            Vector2 collisionDirection = contact.normal;

            if (Vector2.Dot(collisionDirection, Vector2.up) > 0.5f)
            {
                Direction.y = 1;
            }
            else if (Vector2.Dot(collisionDirection, Vector2.down) > 0.5f)
            {
                Direction.y = -1;
            }
            else if (Vector2.Dot(collisionDirection, Vector2.left) > 0.5f)
            {
                Direction.x = -1;
            }
            else if (Vector2.Dot(collisionDirection, Vector2.right) > 0.5f)
            {
                Direction.x = 1;
            }

        }

        public void SetValues()
        {
            
        }
    }
}
