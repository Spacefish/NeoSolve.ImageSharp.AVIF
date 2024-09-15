using System.IO;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace NeoSolve.ImageSharp.AVIF; 
/// <summary>
/// Extension methods for the <see cref="Image"/> type.
/// </summary>
public static partial class ImageExtensions {
    /// <summary>
    /// Saves the image to the given stream with the png format.
    /// </summary>
    /// <param name="source">The image this method extends.</param>
    /// <param name="stream">The stream to save the image to.</param>
    /// <exception cref="System.ArgumentNullException">Thrown if the stream is null.</exception>
    public static void SaveAsAVIF<TPixel>(this Image<TPixel> source, Stream stream)
        where TPixel : unmanaged, IPixel<TPixel> =>
            source.Save(
                stream,
                AVIFEncoder.Instance);
}