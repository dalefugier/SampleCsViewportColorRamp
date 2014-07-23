using Rhino;
using Rhino.Commands;
using Rhino.Input;
using Rhino.Input.Custom;

namespace SampleCsViewportColorRamp
{
  /// <summary>
  /// SampleCsViewportColorRampCommand command
  /// </summary>
  [System.Runtime.InteropServices.Guid("a9a16fc5-d38f-431f-87c0-fd37cc390cc6")]
  public class SampleCsViewportColorRampCommand : Command
  {
    private SampleCsViewportColorRampConduit m_conduit;

    /// <summary>
    /// Public constructor
    /// </summary>
    public SampleCsViewportColorRampCommand()
    {
    }

    /// <summary>
    /// English name override
    /// </summary>
    public override string EnglishName
    {
      get { return "SampleCsViewportColorRamp"; }
    }

    /// <summary>
    /// Run command override
    /// </summary>
    protected override Result RunCommand(RhinoDoc doc, RunMode mode)
    {
      if (null == m_conduit)
        m_conduit = new SampleCsViewportColorRampConduit();

      bool bEnabled = m_conduit.IsEnabled();
      string[] list_values = new string[] { "Yes", "No", "Toggle" };
      int list_index = bEnabled ? 0 : 1;

      GetOption go = new GetOption();
      go.SetCommandPrompt("Choose command option");
      go.AddOptionList("Enable", list_values, list_index);
      go.AcceptNothing(true);

      GetResult res = go.Get();

      if (res == GetResult.Option)
      {
        CommandLineOption opt = go.Option();
        if (null != opt)
        {
          int index = opt.CurrentListOptionIndex;
          if (0 == index && !bEnabled)
          {
            m_conduit.Enable();
            doc.Views.Redraw();
          }
          else if (1 == index && bEnabled)
          {
            m_conduit.Disable();
            doc.Views.Redraw();
          }
          else if (2 == index)
          {
            if (bEnabled)
              m_conduit.Disable();
            else
              m_conduit.Enable();
            doc.Views.Redraw();
          }
        }
      }

      return Result.Success;
    }
  }
}
