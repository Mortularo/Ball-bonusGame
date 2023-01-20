using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace MF
{
    public abstract class Unit : MonoBehaviour
    {
        public Transform _transform;
        public Rigidbody _rb;

        //private float _speed = 5f;
        private int _health = 100;
        private bool _isDead;

        public int Health
        {   get
            {
                return _health;
            }
            set
            {
                if (value<=100 && value >= 0)
                {
                    _health = value;
                }
                else
                {
                    _health = 100;
                    Debug.Log("WRONG health amount!");
                }
            }
        }

        public bool IsDead { get => _isDead; set => _isDead = value; }

        public virtual void Awake()
        {
            if(!TryGetComponent<Transform>(out _transform))
            {
                Debug.Log("NO Transform component!");
            }
            if (!TryGetComponent<Rigidbody>(out _rb))
            {
                Debug.Log("NO Rigidbody component!");
            }
        }
        public abstract void Move(float x, float y, float z);
    }
}

