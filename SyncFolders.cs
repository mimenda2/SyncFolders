using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncFolders
{
    public class SyncFolders
    {
        bool cancelSync = false;
        string originSrcFolder = "";
        string originDstFolder = "";
        TraceLevels traceLevel = TraceLevels.Normal;

        public SyncFolders(string srcFolder, string dstFolder, TraceLevels traceLevel = TraceLevels.Normal)
        {
            this.originSrcFolder = srcFolder;
            this.originDstFolder = dstFolder;
            this.traceLevel = traceLevel;
        }
        #region Public methods
        public void StartSyncFolders()
        {
            TraceFired?.Invoke("Empezando sincronización");

            CopyFolderRecursive(new DirectoryInfo(originSrcFolder));
            
            Finished?.Invoke("Fin sincronización");
        }
        public void Cancel()
        {
            TraceFired?.Invoke("Cancelando...");
            cancelSync = true;
        }
        #endregion

        #region Public events
        public event StringDelegate TraceFired;
        public event StringDelegate Finished;
        #endregion

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
                    TraceFired?.Invoke($"Creando directorio en destino {dstFolder.FullName}");
                    dstFolder.Create();
                }
                catch (Exception ex)
                {
                    TraceFired?.Invoke($"Error al crear directorio {dstFolder.FullName}: {ex.Message}");
                    cancelSync = true;
                }
            }
            return folderExist;
        }
        void CheckDestinationFile(FileInfo srcFile, bool isNewFolder)
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
                        TraceFired?.Invoke($"El fichero origen tiene tamaño cero {srcFile.FullName}. No se copia!");
                        copyFile = false;
                    }
                    else if (srcFile.LastWriteTime < dstFile.LastWriteTime && 
                        (dstFile.LastWriteTime - srcFile.LastWriteTime).TotalSeconds > 5)
                    {
                        TraceFired?.Invoke($"El fichero origen es más antiguo {srcFile.FullName}. No se copia!");
                        copyFile = false;
                    }
                    else if (srcFile.Length == dstFile.Length &&
                        Math.Abs((srcFile.LastWriteTime - dstFile.LastWriteTime).TotalSeconds) < 5)
                    {
                        if (traceLevel == TraceLevels.All)
                            TraceFired?.Invoke($"Tamaño ficheros igual {originSrcFolder}. Src({srcFile.Length}) != Dst({dstFile.Length})");
                        copyFile = false;
                    }
                }
            }

            if (copyFile)
            {
                try
                {
                    if (traceLevel == TraceLevels.All)
                        TraceFired?.Invoke($"Copiando fichero {srcFile.FullName} a {dstFileName}");
                    srcFile.CopyTo(dstFileName, true);
                }
                catch (Exception ex)
                {
                    TraceFired?.Invoke($"Error al reemplazar fichero {dstFileName}: {ex.Message}");
                }
            }
        }

    }
    public delegate void StringDelegate(string msg);
}
