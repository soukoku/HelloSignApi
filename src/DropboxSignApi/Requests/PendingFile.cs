using Soukoku.DropboxSignApi.Internal;
using Newtonsoft.Json;
using System;
using System.IO;

namespace Soukoku.DropboxSignApi.Requests
{
    /// <summary>
    /// Represents a single local file data for uploads.
    /// </summary>
    [JsonConverter(typeof(PendingFileConverter))]
    public class PendingFile : IDisposable
    {
        private bool disposedValue;

        /// <summary>
        /// Initializes a new instance of the <see cref="PendingFile"/> class.
        /// </summary>
        /// <param name="fileData">The file data.</param>
        /// <param name="fileName">Name of the file.</param>
        /// <exception cref="ArgumentNullException">fileData</exception>
        /// <exception cref="ArgumentException">File name is required.</exception>
        public PendingFile(byte[] fileData, string fileName) :
            this(new MemoryStream(fileData), fileName)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PendingFile"/> class.
        /// </summary>
        /// <param name="fileData">The file data.</param>
        /// <param name="fileName">Name of the file.</param>
        /// <exception cref="ArgumentNullException">fileData</exception>
        /// <exception cref="ArgumentException">File name is required.</exception>
        public PendingFile(Stream fileData, string fileName)
        {
            if (fileData == null) { throw new ArgumentNullException(nameof(fileData)); }
            if (string.IsNullOrEmpty(fileName)) { throw new ArgumentException("File name is required."); }

            Stream = fileData;
            FileName = fileName;
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="PendingFile" /> class.
        /// </summary>
        /// <param name="localFilePath">The local file path.</param>
        /// <param name="fileName">Name of the file.</param>
        /// <exception cref="ArgumentException">File path is required.</exception>
        public PendingFile(string localFilePath, string fileName = null)
        {
            if (string.IsNullOrEmpty(localFilePath)) { throw new ArgumentException("File path is required."); }

            Stream = File.Open(localFilePath, FileMode.Open, FileAccess.Read, FileShare.Read);
            FileName = fileName ?? Path.GetFileName(localFilePath);
        }

        /// <summary>
        /// Gets the file stream data.
        /// </summary>
        public Stream Stream { get; }

        /// <summary>
        /// Gets the name of the file.
        /// </summary>
        public string FileName { get; }

        /// <summary>
        /// Returns a <see cref="string" /> that represents this instance.
        /// </summary>
        public override string ToString()
        {
            return FileName;
        }

        /// <summary>
        /// Clean up this object.
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    Stream.Dispose();
                }

                disposedValue = true;
            }
        }

        // ~PendingFile()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        /// <summary>
        /// Clean up this object.
        /// </summary>
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
