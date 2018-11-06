# blazor.summernote
Wrapper for the new MS Blazor framework, allowing the use of the Summernote Wysiwyg editor in a form.

There's no indepth instructions or anything here, as I've not really finished this yet.  It works for what I need it to do right now, but I do eventually want to implement the full functionality of the underlying library's API.  Things will improve in time.

# how to use
in your index.html make sure you include the bootstrap and summernote CSS files. (Order is important)

    <!DOCTYPE html>
    <html>
    <head>
      <meta charset="utf-8" />
      <meta name="viewport" content="width=device-width">
      <title>My App</title>
      <base href="/" />
      <link href="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/4.1.3/css/bootstrap.min.css" rel="stylesheet" />
      <link href="https://cdnjs.cloudflare.com/ajax/libs/summernote/0.8.9/summernote-bs4.css" rel="stylesheet">
      ....
    </head>
 
 After your `<app>` loading tag and after the `<script>` tag that kicks off the blazor load, add JQuery, Popper, Bootstrap 4 and the current release of summernote for BS4.
 
     <body>
      <app>Loading...</app>

      <script src="_framework/blazor.webassembly.js"></script>
      <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.js"></script>
      <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js"></script>
      <script src="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/4.1.3/js/bootstrap.min.js"></script>
      <script src="https://cdnjs.cloudflare.com/ajax/libs/summernote/0.8.9/summernote-bs4.js"></script>

Once that's all in place, make sure your master `_ViewImports.cshtml` looks as follows:

    @using System.Net.Http
    @using Microsoft.AspNetCore.Blazor.Layouts
    @using Microsoft.AspNetCore.Blazor.Routing
    @using Microsoft.JSInterop
    @addTagHelper *,Blazor.SummerNote

It's the last line that's important, that allows the tag helper system to find the component tag.

At this point you can use the tag in your page or component by doing the following.

    <div class="form-group">
      <label for="Description" class="control-label">Description</label>
      <SummerNoteEditor EditorContent="@initalContent" OnEditorChanged="@contentChangeHandler"></SummerNoteEditor>
    </div>
    
    ....
    
    @functions {
    
      string initialContent = "<p>Some HTML markup</p>";
      string updatedContent = "";
    
      void contentChangeHandler(string newContent)
      {
        updatedContent = newContent;
      }
    
    }

# Some final notes
Don't try to update the initial content from the Update Content handler, I don't fully understand how all the eventing works yet and things seem to get in a bit of a know if you do.

I don't know how or even if multiple tags will work on a page yet as I've not tried it.  The creation of the handler and JS Interop however does try to make sure the ID's of the replaced tags etc are unique, so it *should* work :-)

Doc's for summernote can be found at : https://summernote.org/deep-dive/

That's all for now, I can't promise any great progress on this, my time and schedules are all over the place at the moment, but I will in time update it as I get time to do so.

Project files are all VS2017 V15.8 and above
