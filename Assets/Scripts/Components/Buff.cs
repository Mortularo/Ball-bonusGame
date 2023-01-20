using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace MF
{
    public class Buff : Additions, IFlay, IRotation
    {
        public event Action<int> AddPoints = delegate (int i) { };
        private int _point;
        private Material _material;
        private LevelObjView _view;

        public Buff(LevelObjView view) : base(view)
        {
            _view = view;
            _material = _view.Rend.material;
            Init();
        }

        public void Init()
        {
            _lengthFlay = Random.Range(1f, 1.5f);
            _rotationSpeed = Random.Range(10f, 50f);
            _point = 1;
        }
        public override void Update()
        {
            Flay();
            Rotate();
        }
        protected override void Interaction()
        {
            AddPoints?.Invoke(_point);
            IsInteractable = false;
        }
        public void Flay()
        {
            _view.Transform.localPosition = new Vector3(_view.Transform.localPosition.x,
                Mathf.PingPong(Time.time, _lengthFlay), _view.Transform.localPosition.z);
        }
        public void Rotate()
        {
            _view.Transform.Rotate(Vector3.up * (Time.deltaTime * _rotationSpeed), Space.World);
        }

    }
}

