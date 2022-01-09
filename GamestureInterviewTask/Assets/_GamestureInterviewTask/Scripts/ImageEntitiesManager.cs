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

        public void CreateImageEntity(FileInfo fileInfo)
        {
            ImageEntity imageEntity = imageEntityFactory.GetImageEntity(fileInfo, defaultParent);
            imageEntities.Add(fileInfo.FullName, imageEntity);
        }

        public void RemoveImageEntity(FileInfo fileInfo)
        {
            if(imageEntities.TryGetValue(fileInfo.FullName, out ImageEntity imageEntity))
            {
                Destroy(imageEntity.gameObject);
                imageEntities.Remove(fileInfo.FullName);
            }
        }
    }
}
