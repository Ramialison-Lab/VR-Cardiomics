
// C# wrapper for Unity XR SDK Native APIs.

#if USING_XR_SDK
public static class OculusXRPlugin
{
	[DllImport("OculusXRPlugin")]
	public static extern void SetColorScale(float x, float y, float z, float w);

	[DllImport("OculusXRPlugin")]
	public static extern void SetColorOffset(float x, float y, float z, float w);
}
#endif
