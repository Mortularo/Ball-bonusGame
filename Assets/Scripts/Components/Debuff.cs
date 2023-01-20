using System.Collections;
using System.Collections.Generic;
using MF;
using UnityEngine;

namespace MF
{
    public class Debuff : Additions, IFlay, IRotation
    {
        public delegate void AddCoughtChange(string name, Color color);
        public event AddCoughtChange CoughtPlayer;

        private LevelObjView _view;

        public Debuff(LevelObjView view) : base(view)
        {
            _view = view;
            Init();
        }

        public void Init()
        {
            _lengthFlay = Random.Range(1f, 1.5f);
            _rotationSpeed = Random.Range(10f, 50f);
        }
        public override void Update()
        {
            Flay();
            Rotate();
        }
        protected override void Interaction()
        {
            CoughtPlayer?.Invoke(_view.name, _color);
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
