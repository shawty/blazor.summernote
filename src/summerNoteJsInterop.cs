using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace Blazor.SummerNote
{
  public static class SummerNoteJsInterop
  {
    public static event EventHandler<string> EditorUpdate;

    private static string _editorText { get; set; }

    public static Task<string> initialiseEditor(string textAreaElementName, string initialContent)
    {
      return JSRuntime.Current.InvokeAsync<string>(
          "summerNoteJsInterop.initialiseEditor",
          new { textAreaElementName });
    }

    [JSInvokable]
    public static Task<bool> updateText(string editorText)
    {
      _editorText = editorText;
      EditorUpdate?.Invoke(null, editorText);

      return Task.FromResult(true);
    }

  }
}
