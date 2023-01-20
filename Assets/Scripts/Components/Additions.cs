using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MF
{
    public abstract class Additions : IExecute
    {
        private bool _isInteractable;
        protected Color _color;
        public float _lengthFlay;
        public float _rotationSpeed;
        private Renderer _rend;
        private Collider _col;

        public bool IsInteractable
        { 
            get => _isInteractable; 
            set
            {
                _isInteractable = value;
                _rend.enabled = value;
                _col.enabled = value;
            } 
        }

        public Additions(LevelObjView view)
        {
            _rend = view.Rend;
            _col = view.Col;
            IsInteractable = true;
            _color = Random.ColorHSV();
            _rend.sharedMaterial.color = _color;
        }

        public void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Debug.Log("Got collision");
                Interaction();
            }
        }
        protected abstract void Interaction();
        public abstract void Update();
    }
}

