using System;
using System.Collections.Generic;
using System.IO;

namespace SyncFolders
{
    public class SyncFolders
    {
        bool cancelSync = false;
        string originSrcFolder = "";
        string originDstFolder = "";
        TraceLevels traceLevel = TraceLevels.Normal;
        IList<string> ignoreFiles;

        /// <summary>
        /// Constructor
        /// </summary>
        public SyncFolders(string srcFolder, string dstFolder, TraceLevels traceLevel, IList<string> ignoreFiles)
        {
            this.originSrcFolder = srcFolder;
            this.originDstFolder = dstFolder;
            this.traceLevel = traceLevel;
            this.ignoreFiles = ignoreFiles;
        }

        #region Public methods
        /// <summary>
        /// Start to sync the folders
        /// </summary>
        public void StartSyncFolders()
        {
            TraceFired?.Invoke("Start synchronization");

            CopyFolderRecursive(new DirectoryInfo(originSrcFolder));
            
            Finished?.Invoke("Synchronization completed!");
        }
        /// <summary>
        /// Cancel operation
        /// </summary>
        public void Cancel()
        {
            TraceFired?.Invoke("Cancelling...");
            cancelSync = true;
        }
        #endregion

        #region Public events
        /// <summary>
        /// Generate a trace 
        /// </summary>
        public event StringDelegate TraceFired;
        /// <summary>
        /// Synchronization completed
        /// </summary>
        public event StringDelegate Finished;
        #endregion

        #region Private methods
        /// <summary>
        /// Copy a folder recursively
        /// </summary>
        void CopyFolderRecursive(DirectoryInfo folder)
        {
            bool isNewFolder = !CheckDestinationFolder(folder);

            FileInfo[] files = folder.GetFiles();
            int i = 0;
            foreach (FileInfo f in files)
            {
                i++;
                if (cancelSync)
                    return;
                CheckDestinationFile(f, isNewFolder);
                if (i % 5 == 0)
                    System.Windows.Forms.Application.DoEvents();
            }
            DirectoryInfo[] subFolders = folder.GetDirectories();
            foreach (DirectoryInfo d in subFolders)
            {
                if (cancelSync)
                    return;
                CopyFolderRecursive(d);
            }
        }
        /// <summary>
        /// Check if src folder exists in destination
        /// </summary>
        bool CheckDestinationFolder(DirectoryInfo srcFolder)
        {
            bool folderExist = true;
            string dstFolderName = srcFolder.FullName.Replace(originSrcFolder, originDstFolder);
            DirectoryInfo dstFolder = new DirectoryInfo(dstFolderName);
            if (!dstFolder.Exists)
            {
                folderExist = false;
                try
                {
                    TraceFired?.Invoke($"Creating destination folder {dstFolder.FullName}");
                    dstFolder.Create();
                }
                catch (Exception ex)
                {
                    TraceFired?.Invoke($"Error creating the folder {dstFolder.FullName}: {ex.Message}");
                    cancelSync = true;
                }
            }
            return folderExist;
        }
        /// <summary>
        /// Check if destination file exists or it is older
        /// </summary>
        void CheckDestinationFile(FileInfo srcFile, bool isNewFolder)
        {
            if (ignoreFiles == null || !ignoreFiles.Contains(srcFile.Name))
            {
                bool copyFile = true;
                string dstFileName = srcFile.FullName.Replace(originSrcFolder, originDstFolder);
                if (!isNewFolder)
                {
                    FileInfo dstFile = new FileInfo(dstFileName);
                    if (dstFile.Exists)
                    {
                        if (srcFile.Length == 0)
                        {
                            TraceFired?.Invoke($"Source file has zero size {srcFile.FullName}. Ignore file!");
                            copyFile = false;
                        }
                        else if (srcFile.LastWriteTime < dstFile.LastWriteTime &&
                            (dstFile.LastWriteTime - srcFile.LastWriteTime).TotalSeconds > 5)
                        {
                            TraceFired?.Invoke($"Origin file is older {srcFile.FullName}. Ignore file!");
                            copyFile = false;
                        }
                        else if (srcFile.Length == dstFile.Length &&
                            Math.Abs((srcFile.LastWriteTime - dstFile.LastWriteTime).TotalSeconds) < 5)
                        {
                            if (traceLevel == TraceLevels.All)
                                TraceFired?.Invoke($"Same files {originSrcFolder}. Src({srcFile.Length}) != Dst({dstFile.Length})");
                            copyFile = false;
                        }
                    }
                }

                if (copyFile)
                {
                    try
                    {
                        if (traceLevel == TraceLevels.All)
                            TraceFired?.Invoke($"Copying file {srcFile.FullName} a {dstFileName}");
                        srcFile.CopyTo(dstFileName, true);
                    }
                    catch (Exception ex)
                    {
                        TraceFired?.Invoke($"Error replacing the file {dstFileName}: {ex.Message}");
                    }
                }
            }
        }
        #endregion
    }
    /// <summary>
    /// Delegate used to send a string
    /// </summary>
    public delegate void StringDelegate(string msg);
}
