using System;
using System.Xml;
using System.IO;
using UnityEngine;

namespace MF
{
    public class XMLData : ISaveData
    {
        public static Vector3 StringToVector(string sVector)
        {
            if (sVector.StartsWith("(") && sVector.EndsWith(")"))
            {
                sVector = sVector.Substring(1, sVector.Length - 2);
            }
            string[] sArray = sVector.Split(",");
            Vector3 result = new Vector3(
                float.Parse(sArray[0]),
                float.Parse(sArray[1]),
                float.Parse(sArray[2]));
            return result;
        }

        string SavePath = Path.Combine(Application.dataPath, "XMLData.xml");

        public void SaveData(PlayerData player)
        {
            XmlDocument xmlDoc = new XmlDocument();
            XmlNode rootNode = xmlDoc.CreateElement("Player");
            xmlDoc.AppendChild(rootNode);
            /*XmlElement element = xmlDoc.CreateElement("PlayerName");
            element.SetAttribute("value", player.Name);
            rootNode.AppendChild(element);*/

            XmlElement element = xmlDoc.CreateElement("PlayerHealth");
            element.SetAttribute("value", player.Health.ToString());
            rootNode.AppendChild(element);
            
            element = xmlDoc.CreateElement("PlayerDead");
            element.SetAttribute("value", player.PlayerDead.ToString());
            rootNode.AppendChild(element);

            element = xmlDoc.CreateElement("PlayerPOsition");
            element.SetAttribute("value", player.Position.ToString());
            rootNode.AppendChild(element);
            
            element = xmlDoc.CreateElement("PlayerRotation");
            element.SetAttribute("value", player.Rotation.ToString());
            rootNode.AppendChild(element);

            xmlDoc.Save(SavePath);
        }
        public PlayerData Load()
        {
            PlayerData result = new PlayerData();
            if (!File.Exists(SavePath))
            {
                Debug.Log("NO saved Data");
                return result;
            }

            using (XmlTextReader reader = new XmlTextReader(SavePath))
            {
                while(reader.Read())
                {
                    /*if (reader.IsStartElement("PlayerName"))
                    {
                        result.Name = reader.GetAttribute("value");
                    }*/
                    if (reader.IsStartElement("PlayerHealth"))
                    {
                        result.Health = Convert.ToInt32(reader.GetAttribute("value"));
                    }
                    if (reader.IsStartElement("PlayerDead"))
                    {
                        result.PlayerDead = Convert.ToBoolean(reader.GetAttribute("value"));
                    }
                    if (reader.IsStartElement("PlayerPosition"))
                    {
                        result.Position = StringToVector(reader.GetAttribute("value"));
                    }
                    /*if (reader.IsStartElement("PlayerRotation"))
                    {
                        result.Rotation = reader.GetAttribute("value");
                    }*/
                }
            }

            return result;
        }
    }
}