using System.IO;
using UnityEngine;
using GamestureInterviewTask.Utilities;

namespace GamestureInterviewTask
{
    [CreateAssetMenu(fileName = "ImageEntityFactory", menuName = "GamestureInterviewTask/ImageEntityFactory")]
    public class ImageEntityFactory : ScriptableObject
    {

        [SerializeField]
        private ImageEntity prefab;

        public ImageEntity GetImageEntity(FileInfo fileInfo)
        {
            return GetImageEntity(fileInfo.Name, fileInfo.CreationTime.ToLongDateString(), FileConverter.ToTexture2D(fileInfo), null);
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
