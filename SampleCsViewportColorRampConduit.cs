using System.Drawing;
using RMA.Rhino;
using RMA.UI;

namespace SampleCsViewportColorRamp
{
  /// <summary>
  /// SampleCsViewportColorRampConduit display conduit.
  /// Note, this conduit inherits from the MRhinoDisplayConduit,
  /// which is part of the Rhino_DotNet.dll assembly.
  /// </summary>
  public class SampleCsViewportColorRampConduit : MRhinoDisplayConduit
  {
    private readonly Bitmap m_color_ramp;

    /// <summary>
    /// Public constructor
    /// </summary>
    public SampleCsViewportColorRampConduit()
      : base(new MSupportChannels(MSupportChannels.SC_DRAWFOREGROUND))
    {
      m_color_ramp = SampleCsViewportColorRamp.Properties.Resources.HueColorRamp;
    }

    /// <summary>
    /// ExecConduit override
    /// </summary>
    public override bool ExecConduit(ref MRhinoDisplayPipeline pipeline, uint channel, ref bool terminate)
    {
      if (channel == MSupportChannels.SC_DRAWFOREGROUND)
      {
        int left = 0, right = 0, bottom = 0, top = 0;
        pipeline.GetRhinoVP().VP().GetScreenPort(ref left, ref right, ref bottom, ref top);

        int width = m_color_ramp.Width;
        int height = bottom - top;

        Bitmap color_ramp = new Bitmap(width, height);
        using (Graphics g = Graphics.FromImage(color_ramp))
          g.DrawImage(m_color_ramp, 0, 0, width, height);

        MRhinoUiDib dib = new MRhinoUiDib(color_ramp);
        pipeline.DrawBitmap(dib, left, top);
      }

      return true;
    }
  }
}
