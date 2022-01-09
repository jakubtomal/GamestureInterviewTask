using System.IO;
using System.Collections.Generic;
using UnityEngine;

namespace GamestureInterviewTask
{
    public class ImageEntitiesManager : MonoBehaviour
    {
        [SerializeField]
        private Transform defaultParent;
        [SerializeField]
        private ImageEntityFactory imageEntityFactory;
        private Dictionary<string,ImageEntity> imageEntities = new Dictionary<string, ImageEntity>();
        private List<string> tmpKeys = new List<string>();

        public void CreateImageEntity(FileInfo fileInfo)
        {
            ImageEntity imageEntity = imageEntityFactory.GetImageEntity(fileInfo, defaultParent);
            imageEntities.Add(fileInfo.FullName, imageEntity);
        }

        public void RemoveImageEntity(FileInfo fileInfo)
        {
            RemoveImageEntity(fileInfo.FullName);
        }

        public void RemoveImageEntity(string path)
        {
            if(imageEntities.TryGetValue(path, out ImageEntity imageEntity))
            {
                Destroy(imageEntity.gameObject);
                imageEntities.Remove(path);
            }
        }

        public void Synchronize(IReadOnlyDictionary<string, FileInfo> fileInfos)
        {
            foreach(var fileInfoKey in fileInfos.Keys)
            {
                if(!imageEntities.ContainsKey(fileInfoKey))
                {
                    CreateImageEntity(fileInfos[fileInfoKey]);
                }
            }

            tmpKeys.Clear();
            foreach(var imageEntityKey in imageEntities.Keys)
            {
                if(!fileInfos.ContainsKey(imageEntityKey))
                {
                    tmpKeys.Add(imageEntityKey);
                }
            }

            foreach(var keyToRemove in tmpKeys)
            {
                imageEntities.Remove(keyToRemove);
            }
        }
    }
}
