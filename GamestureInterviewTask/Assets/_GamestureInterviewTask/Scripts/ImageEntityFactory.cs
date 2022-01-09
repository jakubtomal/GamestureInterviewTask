using System.IO;
using UnityEngine;
using GamestureInterviewTask.Utilities;

namespace GamestureInterviewTask
{
    [CreateAssetMenu(fileName = "FileDataContainer", menuName = "GamestureInterviewTask/FileDataContainer")]
    public class ImageEntityFactory : ScriptableObject
    {

        [SerializeField]
        private ImageEntity prefab;

        public ImageEntity GetImageEntity(FileInfo fileInfo)
        {
            return GetImageEntity(fileInfo.Name, fileInfo.CreationTime, FileConverter.ToTexture2D(fileInfo), null);
        }

        public ImageEntity GetImageEntity(FileInfo fileInfo, Transform parent)
        {
            return GetImageEntity(fileInfo.Name, fileInfo.CreationTime, FileConverter.ToTexture2D(fileInfo),parent);
        }

        public ImageEntity GetImageEntity(string title, System.DateTime creationTime, Texture2D texture, Transform parent)
        {
            ImageEntity imageEntity = Instantiate(prefab, parent);
            imageEntity.SetData(title, creationTime, texture);
            return imageEntity;
        }
    }
}
