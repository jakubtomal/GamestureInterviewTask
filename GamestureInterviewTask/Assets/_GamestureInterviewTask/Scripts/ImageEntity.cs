using System.IO;
using UnityEngine;
using UnityEngine.Events;

namespace GamestureInterviewTask
{
    public class ImageEntity : MonoBehaviour
    {
        private System.DateTime creationTime;
        private string title;
        public string Title
        {
            get
            {
                return title;
            }
            private set
            {
                title = value;
                OnTitleChanged?.Invoke(title);
            }
        }
        private string timeFromCreation;
        public string TimeFromCreation
        {
            get
            {
                return timeFromCreation;
            }
            private set
            {
                timeFromCreation = value;
                OnCreationDateChanged?.Invoke(timeFromCreation);
            }
        }
        private Texture2D texture;
        public Texture2D Texture
        {
            get
            {
                return texture;
            }
            private set
            {
                texture = value;
                OnSpriteChanged?.Invoke(texture);
            }
        }

        public UnityEvent<string> OnTitleChanged;
        public UnityEvent<string> OnCreationDateChanged;
        public UnityEvent<Texture2D> OnSpriteChanged;

        public void SetData(string title, System.DateTime creationTime, Texture2D texture)
        {
            Title = title;
            this.creationTime = creationTime;
            Texture = texture;
            RefreshData();
        }

        public void SetData(FileInfo fileInfo, Texture2D texture)
        {
            SetData(fileInfo.Name, fileInfo.CreationTime, texture);
        }

        public void RefreshData()
        {
            TimeFromCreation = (System.DateTime.Now - creationTime).ToString();
        }
        
    }
}
