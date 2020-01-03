using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace SBA.Expense.Repos
{
     public interface IAzureBlobRepo
    {
        /// <summary>
        /// Get all files from the given container and the given path.
        /// </summary>
        /// <param name="containerName"></param>
        /// <param name="relativepath"></param>
        /// <returns></returns>
        Task<Tuple<string, Stream>> GetFile(string containerName, string relativepath);

        /// <summary>
        /// Storea the content of a file with the given filename to the azure storage blob.
        /// </summary>
        /// <param name="containerName"></param>
        /// <param name="relativePath"></param>
        /// <param name="fileName"></param>
        /// <param name="contents"></param>
        Task Store(string containerName, string relativePath, string fileName, Stream contents);

        /// <summary>
        /// Delete the file
        /// </summary>
        /// <param name="containername"></param>
        /// <param name="fullPathFileName"></param>
        Task DeleteFile(string containerName, string fullPathFileName);
    }
}