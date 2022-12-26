using System;
using System.IO;

namespace DropboxSignApi.Requests
{
    /// <summary>
    /// Represents a file for creating signature requests.
    /// </summary>
    public class PendingFile
    {
  //      /// <summary>
  //      /// Initializes a new instance of the <see cref="PendingFile" /> class.
  //      /// </summary>
  //      /// <param name="remoteFilePath">The remote file path.</param>
		///// <param name="fileName">Obsolete. Has no bearing on the name of the remote file.</param>
  //      /// <exception cref="ArgumentNullException">remoteFilePath</exception>
  //      /// <exception cref="ArgumentException">Only remote http/https file is supported.</exception>
  //      [Obsolete("Use constructor without fileName for Uri files.")]
  //      public PendingFile(Uri remoteFilePath, string fileName) : this(remoteFilePath) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PendingFile" /> class.
        /// </summary>
        /// <param name="remoteFilePath">The remote file path.</param>
        /// <exception cref="ArgumentNullException">remoteFilePath</exception>
        /// <exception cref="ArgumentException">Only remote http/https file is supported.</exception>
        public PendingFile(Uri remoteFilePath)
        {
            if (remoteFilePath == null) { throw new ArgumentNullException(nameof(remoteFilePath)); }

            if (string.Equals(remoteFilePath.Scheme, "http") ||
                string.Equals(remoteFilePath.Scheme, "https"))
            {
                RemotePath = remoteFilePath;
            }
            else
            {
                throw new ArgumentException("Only remote http/https file is supported.");
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PendingFile"/> class.
        /// </summary>
        /// <param name="fileData">The file data.</param>
        /// <param name="fileName">Name of the file.</param>
        /// <exception cref="ArgumentNullException">fileData</exception>
        /// <exception cref="ArgumentException">File name is required.</exception>
        public PendingFile(byte[] fileData, string fileName)
        {
            if (fileData == null) { throw new ArgumentNullException(nameof(fileData)); }
            if (string.IsNullOrEmpty(fileName)) { throw new ArgumentException("File name is required."); }

            Data = fileData;
            FileName = fileName;
        }
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

            LocalPath = localFilePath;
            FileName = fileName ?? Path.GetFileName(localFilePath);
        }

        /// <summary>
        /// Gets the local file path.
        /// </summary>
        public string LocalPath { get; private set; }

        /// <summary>
        /// Gets the remote (http/https) file path.
        /// </summary>
        public Uri RemotePath { get; private set; }

        /// <summary>
        /// Gets the byte array data.
        /// </summary>
        public byte[] Data { get; private set; }

        /// <summary>
        /// Gets the stream data.
        /// </summary>
        public Stream Stream { get; private set; }

        /// <summary>
        /// Gets the name of the file. This is only for local files.
        /// </summary>
        public string FileName { get; private set; }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            if (RemotePath != null) return RemotePath.ToString();
            return FileName;
        }

    }
}
