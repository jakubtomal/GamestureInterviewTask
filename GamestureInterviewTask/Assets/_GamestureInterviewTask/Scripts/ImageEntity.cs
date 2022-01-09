using System.IO;
using UnityEngine;
using UnityEngine.Events;

namespace GamestureInterviewTask
{
    public class ImageEntity : MonoBehaviour
    {
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
        private string creationDate;
        public string CreationDate
        {
            get
            {
                return creationDate;
            }
            private set
            {
                creationDate = value;
                OnCreationDateChanged?.Invoke(creationDate);
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

        public void SetData(string title, string creationDate, Texture2D texture)
        {
            Title = title;
            CreationDate = creationDate;
            Texture = texture;
        }
    }
}
