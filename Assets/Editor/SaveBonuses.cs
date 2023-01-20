using System.IO;
using UnityEditor;
using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;

namespace MF
{
    [CustomEditor(typeof(SaveBonusesView))]
    public class SaveBonuses : Editor
    {
        private static XmlSerializer _serializer;
        public List<SVect3> SavingBonusesT = new List<SVect3>();
        public SVect3 bonusesPos;
        // public List<SVect3> LoadBonusesT = new List<SVect3>();

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            SaveBonusesView saveBonusesView = (SaveBonusesView)target;
            if(_serializer == null)
            {
                _serializer = new XmlSerializer(typeof(SVect3[]));
            }
            if (GUILayout.Button("Save"))
            {
                if (saveBonusesView.bonuses.Count > 0)
                {
                    foreach(Transform item in saveBonusesView.bonuses)
                    {
                        if (!SavingBonusesT.Contains(item.position))
                        {
                            SavingBonusesT.Add(item.position);
                        }
                    }
                }
                using (FileStream fs = new FileStream(saveBonusesView.SavePath, FileMode.Create))
                {
                    _serializer.Serialize(fs, SavingBonusesT.ToArray());
                }
                using (XmlTextReader reader = new XmlTextReader(saveBonusesView.SavePath))
                {
                    var LoadBonusesT = _serializer.Deserialize(reader);
                    bonusesPos = (SVect3)LoadBonusesT;
                }
            }
        }
    }
}