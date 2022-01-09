using UnityEngine;
using UnityEngine.Events;
using System.IO;

namespace GamestureInterviewTask
{
    public class FileDataContainerEventListener : MonoBehaviour
    {
        [SerializeField]
        private FileDataContainer fileDataContainer;
        [SerializeField]
        private UnityEvent<FileInfo> OnFileAdded;
        [SerializeField]
        private UnityEvent<FileInfo> OnFileRemoved;
        private void Awake()
        {
            fileDataContainer.OnFileAdded += RiseOnFileAdded;
            fileDataContainer.OnFileRemoved += RiseOnFileRemoved;
        }

        private void OnDestroy()
        {
            fileDataContainer.OnFileAdded -= RiseOnFileAdded;
            fileDataContainer.OnFileRemoved -= RiseOnFileRemoved;
        }

        private void RiseOnFileAdded(FileInfo fileInfo)
        {
            OnFileAdded?.Invoke(fileInfo);
        }

        private void RiseOnFileRemoved(FileInfo fileInfo)
        {
            OnFileRemoved?.Invoke(fileInfo);
        }
    }
}
