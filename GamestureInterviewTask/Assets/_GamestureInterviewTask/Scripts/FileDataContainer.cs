using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace GamestureInterviewTask
{
    [CreateAssetMenu(fileName = "FileDataContainer", menuName = "GamestureInterviewTask/FileDataContainer")]
    public class FileDataContainer : ScriptableObject
    {

        [SerializeField]
        [Tooltip("path relative to game data folder")]
        private string relativePath;
        [SerializeField]
        private string fileFormat;
        private string path;
        private Dictionary<string, FileInfo> fileInfos = new Dictionary<string, FileInfo>();
        private List<string> files = new List<string>();
        private List<string> filesToRemove = new List<string>();

        public Action<FileInfo> OnFileAdded;
        public Action<FileInfo> OnFileRemoved;

        private void OnEnable()
        {
            path = Application.dataPath + relativePath;
        }

        [ContextMenu("Refresh Data")]
        public void RefreshData()
        {
            files.Clear();
            filesToRemove.Clear();
            files.AddRange(Directory.GetFiles(path, fileFormat));

            foreach(var file in files)
            {
                if(!fileInfos.ContainsKey(file))
                {
                    FileInfo fileInfo = new FileInfo(file);
                    fileInfos.Add(file, fileInfo);
                    OnFileAdded?.Invoke(fileInfo);
                }
            }

            foreach(var item in fileInfos.Keys)
            {
                if(!files.Contains(item))
                {
                    filesToRemove.Add(item);
                }
            }

            foreach(var fileToRemove in filesToRemove)
            {
                FileInfo fileInfo = fileInfos[fileToRemove];
                fileInfos.Remove(fileToRemove);
                OnFileRemoved?.Invoke(fileInfo);
            }

        }
    }
}
