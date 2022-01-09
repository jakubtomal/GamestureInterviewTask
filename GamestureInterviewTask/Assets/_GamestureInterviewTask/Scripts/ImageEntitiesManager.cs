using System.IO;
using System.Collections;
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
        private Dictionary<FileInfo,ImageEntity> imageEntities = new Dictionary<FileInfo, ImageEntity>();
        private List<FileInfo> tmpKeys = new List<FileInfo>();

        public void CreateImageEntity(FileInfo fileInfo)
        {
            ImageEntity imageEntity = imageEntityFactory.GetImageEntity(fileInfo, defaultParent);
            imageEntities.Add(fileInfo, imageEntity);
        }

        public void RemoveImageEntity(FileInfo fileInfo)
        {
            if(imageEntities.TryGetValue(fileInfo, out ImageEntity imageEntity))
            {
                Destroy(imageEntity.gameObject);
                imageEntities.Remove(fileInfo);
            }
        }

        public void Synchronize(IReadOnlyDictionary<string, FileInfo> fileInfos)
        {
            foreach(var fileInfoValue in fileInfos.Values)
            {
                if(!imageEntities.ContainsKey(fileInfoValue))
                {
                    CreateImageEntity(fileInfoValue);
                }

            }
            tmpKeys.Clear();
            foreach(var imageEntityKey in imageEntities.Keys)
            {
                tmpKeys.Add(imageEntityKey);
            }

            foreach(var value in fileInfos.Values)
            {
                tmpKeys.Remove(value);
            }

            foreach(var keyToRemove in tmpKeys)
            {
                imageEntities.Remove(keyToRemove);
            }
        }

        public void RefreshAllImageEntities()
        {
            foreach(var imageEntity in imageEntities.Values)
            {
                imageEntity.RefreshData();
            }
        }
    }
}
