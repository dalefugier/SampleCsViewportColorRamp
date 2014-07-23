using Rhino.PlugIns;

namespace SampleCsViewportColorRamp
{
  /// <summary>
  /// SampleCsViewportColorRampPlugIn plug-in
  /// </summary>
  public class SampleCsViewportColorRampPlugIn : PlugIn
  {
    /// <summary>
    /// Public constructor
    /// </summary>
    public SampleCsViewportColorRampPlugIn()
    {
      Instance = this;
    }

    /// <summary> 
    /// Gets the only instance of the SampleCsViewportColorRampPlugIn plug-in.
    /// </summary>
    public static SampleCsViewportColorRampPlugIn Instance
    {
      get;
      private set;
    }

    // You can override methods here to change the plug-in behavior on
    // loading and shut down, add options pages to the Rhino _Option command
    // and mantain plug-in wide options in a document.
  }
}