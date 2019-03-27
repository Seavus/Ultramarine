const path = require('path')
// The module 'vscode' contains the VS Code extensibility API
// Import the module and reference it with the alias vscode in your code below
const vscode = require('vscode')

// this method is called when your extension is activated
// your extension is activated the very first time the command is executed

/**
 * @param {vscode.ExtensionContext} context
 */
function activate(context) {
  // Use the console to output diagnostic information (console.log) and errors (console.error)
  // This line of code will only be executed once when your extension is activated

  // The command has been defined in the package.json file
  // Now provide the implementation of the command with  registerCommand
  // The commandId parameter must match the command field in package.json
  const disposable = vscode.commands.registerCommand(
    'extension.helloWorld',
    // eslint-disable-next-line func-names
    function() {
      // The code you place here will be executed every time your command is executed
      const panel = vscode.window.createWebviewPanel(
        'reactComponent', // Identifies the type of the webview. Used internally
        'React component', // Title of the panel displayed to the user
        vscode.ViewColumn.One, // Editor column to show the new webview panel in.
        {
          enableScripts: true
        }
      )

      // eslint-disable-next-line no-use-before-define
      const bundleScript = buildScriptsUri(context, 'bundle.js')
      const vendorScripts = buildScriptsUri(context, 'vendor.js')
      panel.webview.html = getWebviewContentDebug() //getWebviewContent(bundleScript, vendorScripts);
      // Display a message box to the user
      vscode.window.showInformationMessage('Hello World!')
    }
  )

  context.subscriptions.push(disposable)
}
const buildScriptsUri = (context, scriptName) =>
  vscode.Uri.file(path.join(context.extensionPath, 'build', scriptName)).with({
    scheme: 'vscode-resource'
  })

exports.activate = activate

// this method is called when your extension is deactivated
function deactivate() {}

module.exports = {
  activate,
  deactivate
}

function getWebviewContent(scriptUri, vendorScripts) {
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
    <script src="${vendorScripts}"></script>
    <script src="${scriptUri}" ></script>
  </body>
</html>`
}

function getWebviewContentDebug() {
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
    <script src="http://localhost:64825/assets/bundle.js"></script>
  </body>
</html>`
}
