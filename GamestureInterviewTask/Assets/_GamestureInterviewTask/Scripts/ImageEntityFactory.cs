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


        public ImageEntity CreateImageEntity(FileInfo fileInfo)
        {
            return CreateImageEntity(fileInfo.Name, fileInfo.CreationTime.ToLongDateString(), FileConverter.ToTexture2D(fileInfo), defaultParent);
        }

        public ImageEntity CreateImageEntity(FileInfo fileInfo, Transform parent)
        {
            return CreateImageEntity(fileInfo.Name, fileInfo.CreationTime.ToLongDateString(), FileConverter.ToTexture2D(fileInfo),parent);
        }

        public ImageEntity CreateImageEntity(string title, string creationDate, Texture2D texture, Transform parent)
        {
            ImageEntity imageEntity = Instantiate(prefab, parent);
            imageEntity.SetData(title, creationDate, texture);
            return imageEntity;
        }
    }
}
