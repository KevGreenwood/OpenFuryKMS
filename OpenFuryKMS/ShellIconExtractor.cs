using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;

namespace OpenFuryKMS
{
    /// <summary>
    /// Shell Icon Extractor Class
    /// </summary>
    public class ShellIconExtractor : IDisposable
    {
        private IntPtr _iconHandle;

        [DllImport("Shell32.dll")]
        private static extern IntPtr ExtractIcon(IntPtr hInst, string lpszExeFileName, int nIconIndex);

        [DllImport("User32.dll")]
        private static extern bool DestroyIcon(IntPtr hIcon);

        /// <summary>
        /// Initializes a new instance of the <see cref="ShellIconExtractor"/> class with the specified file path and icon index.
        /// </summary>
        /// <param name="filePath">The path of the file containing the icons.</param>
        /// <param name="iconIndex">The index of the icon to extract.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the <paramref name="iconIndex"/> is negative.</exception>
        /// <exception cref="ArgumentException">
        /// Thrown when the <paramref name="filePath"/> is null or empty, or the icon handle is invalid.
        /// </exception>
        public ShellIconExtractor(string filePath, int iconIndex)
        {
            if (iconIndex < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(iconIndex), "Icon index cannot be negative.");
            }

            if (string.IsNullOrEmpty(filePath))
            {
                throw new ArgumentException("File path cannot be null or empty.", nameof(filePath));
            }

            _iconHandle = ExtractIcon(IntPtr.Zero, filePath, iconIndex);

            if (_iconHandle == IntPtr.Zero)
            {
                throw new ArgumentException("Icon handle is invalid.", nameof(filePath));
            }

        }

        /// <summary>
        /// Gets the icon with the specified size.
        /// </summary>
        /// <param name="size">The size of the icon.</param>
        /// <returns>The icon with the specified size.</returns>
        /// <exception cref="InvalidOperationException">Thrown when the icon handle is invalid.</exception>
        /// <exception cref="ArgumentException">Thrown when an invalid argument exception occurs.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when an out of memory exception occurs.</exception>
        /// <exception cref="Win32Exception">Thrown when a Win32 exception occurs.</exception>
        /// <exception cref="ExternalException">Thrown when an external exception occurs.</exception>
        /// <exception cref="NotSupportedException">Thrown when a not supported exception occurs.</exception>
        /// <exception cref="Exception">Thrown when an unknown error occurs.</exception>
        public System.Drawing.Icon GetIcon(int size)
        {
            if (_iconHandle == IntPtr.Zero)
                throw new InvalidOperationException("Icon handle is invalid.");

            try
            {
                return System.Drawing.Icon.FromHandle(GetResizedIconHandle(size));
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException("Invalid argument exception: " + ex.Message, ex);
            }
            catch (OutOfMemoryException ex)
            {
                throw new OutOfMemoryException("Out of memory exception: " + ex.Message, ex);
            }
            catch (Win32Exception ex)
            {
                throw new Win32Exception("Win32 exception: " + ex.Message, ex);
            }
            catch (ExternalException ex)
            {
                throw new ExternalException("External exception: " + ex.Message, ex);
            }
            catch (NotSupportedException ex)
            {
                throw new NotSupportedException("Not supported exception: " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred: " + ex.Message, ex);
            }
        }

        private IntPtr GetResizedIconHandle(int size)
        {
            IntPtr resizedIconHandle = IntPtr.Zero;

            try
            {
                System.Drawing.Icon icon = System.Drawing.Icon.FromHandle(_iconHandle);
                Bitmap bitmap = new Bitmap(icon.ToBitmap(), new Size(size, size));
                resizedIconHandle = bitmap.GetHicon();
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException("Invalid argument exception: " + ex.Message, ex);
            }
            catch (OutOfMemoryException ex)
            {
                throw new OutOfMemoryException("Out of memory exception: " + ex.Message, ex);
            }
            catch (Win32Exception ex)
            {
                throw new Win32Exception("Win32 exception: " + ex.Message, ex);
            }
            catch (ExternalException ex)
            {
                throw new ExternalException("External exception: " + ex.Message, ex);
            }
            catch (NotSupportedException ex)
            {
                throw new NotSupportedException("Not supported exception: " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred: " + ex.Message, ex);
            }
            return resizedIconHandle;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            if (_iconHandle != IntPtr.Zero)
            {
                DestroyIcon(_iconHandle);
                _iconHandle = IntPtr.Zero;
            }
        }
    }
}
