window.summerNoteJsInterop = {

  initialiseEditor: function (params) {

    $('#' + params.textAreaElementName).summernote({
      toolbar: [
        ['style', ['bold', 'italic', 'underline', 'clear']],
        ['font', ['strikethrough', 'superscript', 'subscript']],
        ['para', ['ul', 'ol', 'paragraph']],
      ],

      callbacks: {
        onChange: function (contents) {
          DotNet.invokeMethodAsync('Blazor.SummerNote', 'updateText', contents);
        }
      }

    });

  }

};
