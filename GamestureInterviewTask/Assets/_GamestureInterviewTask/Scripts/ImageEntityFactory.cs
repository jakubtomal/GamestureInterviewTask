using System.IO;
using UnityEngine;
using GamestureInterviewTask.Utilities;

namespace GamestureInterviewTask
{
    public class ImageEntityFactory : MonoBehaviour
    {
        [SerializeField]
        private Transform defaultParent;
        [SerializeField]
        private ImageEntity prefab;

        public void CreateImageEntity(FileInfo fileInfo)
        {
            GetImageEntity(fileInfo);
        }

        public ImageEntity GetImageEntity(FileInfo fileInfo)
        {
            return GetImageEntity(fileInfo.Name, fileInfo.CreationTime.ToLongDateString(), FileConverter.ToTexture2D(fileInfo), defaultParent);
        }

        public ImageEntity GetImageEntity(FileInfo fileInfo, Transform parent)
        {
            return GetImageEntity(fileInfo.Name, fileInfo.CreationTime.ToLongDateString(), FileConverter.ToTexture2D(fileInfo),parent);
        }

        public ImageEntity GetImageEntity(string title, string creationDate, Texture2D texture, Transform parent)
        {
            ImageEntity imageEntity = Instantiate(prefab, parent);
            imageEntity.SetData(title, creationDate, texture);
            return imageEntity;
        }
    }
}
