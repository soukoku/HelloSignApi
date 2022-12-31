using System;
using System.Collections.Generic;

namespace DropboxSignApi.Requests
{
    /// <summary>
    /// Base request type that contains files.
    /// </summary>
    public abstract class FileRequestBase : IDisposable
    {
        private bool disposedValue;

        /// <summary>
        /// File urls to upload. This cannot be used with <see cref="File"/>.
        /// </summary>
        public IList<Uri> FileUrl { get; } = new List<Uri>();

        /// <summary>
        /// File data to upload. This cannot be used with <see cref="FileUrl"/>.
        /// </summary>
        public IList<PendingFile> File { get; } = new List<PendingFile>();

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
                    foreach (var f in File)
                    {
                        try
                        {
                            f.Dispose();
                        }
                        catch { }
                    }
                }
                disposedValue = true;
            }
        }

        // ~FileRequestBase()
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
