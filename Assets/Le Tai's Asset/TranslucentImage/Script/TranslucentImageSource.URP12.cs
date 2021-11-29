#if URP12_OR_NEWER
namespace LeTai.Asset.TranslucentImage
{
public partial class TranslucentImageSource
{
    public enum SourceBuffer
    {
        A,
        B
    }

    public SourceBuffer sourceBuffer = SourceBuffer.A;
}
}
#endif
