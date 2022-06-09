using Microsoft.ClearScript;
using Microsoft.ClearScript.V8;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

using (var engine = new V8ScriptEngine())
{
    engine.DocumentSettings.AccessFlags |= DocumentAccessFlags.EnableFileLoading;

    // This is the line that fails in the debugger! If you set a breakpoint on
    // the below line and step over, the debugger will terminate with the error
    //
    // The program '[22971] DemoConsoleApp.dll' has exited with code 0 (0x0).
    engine.ExecuteDocument(@"webpack-output.js");

    var result = engine.Script.demo();

    Console.WriteLine(result);
}

Console.WriteLine("Finished. Press enter");
Console.ReadLine();