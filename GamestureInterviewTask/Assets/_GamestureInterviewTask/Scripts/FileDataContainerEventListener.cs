using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;
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
        [SerializeField]
        private UnityEvent<IReadOnlyDictionary<string,FileInfo>> OnSynchronization;

        private void Awake()
        {
            fileDataContainer.OnFileAdded += RiseOnFileAdded;
            fileDataContainer.OnFileRemoved += RiseOnFileRemoved;
        }

        private void Start()
        {
            OnSynchronization?.Invoke(fileDataContainer.ReadOnlyFilesInfo);
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
