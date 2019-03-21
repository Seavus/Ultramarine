const path = require("path");
// The module 'vscode' contains the VS Code extensibility API
// Import the module and reference it with the alias vscode in your code below
const vscode = require("vscode");

// this method is called when your extension is activated
// your extension is activated the very first time the command is executed

/**
 * @param {vscode.ExtensionContext} context
 */
function activate(context) {
  // Use the console to output diagnostic information (console.log) and errors (console.error)
  // This line of code will only be executed once when your extension is activated
  console.log(
    'Congratulations, your extension "helloworldcomponent" is now active!'
  );

  // The command has been defined in the package.json file
  // Now provide the implementation of the command with  registerCommand
  // The commandId parameter must match the command field in package.json
  let disposable = vscode.commands.registerCommand(
    "extension.helloWorld",
    function() {
      // The code you place here will be executed every time your command is executed
      const panel = vscode.window.createWebviewPanel(
        "reactComponent", // Identifies the type of the webview. Used internally
        "React component", // Title of the panel displayed to the user
        vscode.ViewColumn.One, // Editor column to show the new webview panel in.
        {
          enableScripts: true
        }
      );

      const manifest = require(path.join(
        context.extensionPath,
        "build",
        "asset-manifest.json"
      ));
      const mainScript = manifest["main.js"];
      // const mainStyle = manifest["main.css"];

      const scriptPathOnDisk = vscode.Uri.file(
        path.join(context.extensionPath, "build", mainScript)
      );
      const scriptUri = scriptPathOnDisk.with({ scheme: "vscode-resource" });

      panel.webview.html = getWebviewContent(scriptUri);
      console.log(panel.webview.html);
      // Display a message box to the user
      vscode.window.showInformationMessage("Hello World!");
    }
  );

  context.subscriptions.push(disposable);
}
exports.activate = activate;

// this method is called when your extension is deactivated
function deactivate() {}

module.exports = {
  activate,
  deactivate
};

function getWebviewContent(scriptUri) {
  //const nonce = getNonce();
  return `<!DOCTYPE html>
<html lang="en">
  <head>
    <meta charset="utf-8">
				<meta name="viewport" content="width=device-width,initial-scale=1,shrink-to-fit=no">
				<meta name="theme-color" content="#000000">
				<title>React App Boza</title>
  </head>
  <body>
    <noscript>You need to enable JavaScript to run this app.</noscript>
    <div id="root"></div>
    <p>boza</p>
    <script src="${scriptUri}" ></script>
  </body>
</html>`;
}

// function getNonce() {
//   let text = "";
//   const possible =
//     "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
//   for (let i = 0; i < 32; i++) {
//     text += possible.charAt(Math.floor(Math.random() * possible.length));
//   }
//   return text;
// }
