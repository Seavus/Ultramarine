// eslint-disable-next-line prefer-destructuring
const NODE_ENV = process.env.NODE_ENV

const path = require('path')
// The module 'vscode' contains the VS Code extensibility API
// Import the module and reference it with the alias vscode in your code below
const vscode = require('vscode') //eslint-disable-line

const webViewBuilder =
  NODE_ENV === 'production'
    ? require('./webview.production')
    : require('./webview.develop')
// this method is called when your extension is activated
// your extension is activated the very first time the command is executed
const buildScriptsUri = (context, scriptName) =>
  vscode.Uri.file(path.join(context.extensionPath, 'build', scriptName)).with({
    scheme: 'vscode-resource'
  })

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
    'ultramarine.showGeneratorEditor',
    // eslint-disable-next-line func-names
    function() {
      // The code you place here will be executed every time your command is executed
      const panel = vscode.window.createWebviewPanel(
        'generatorEditor', // Identifies the type of the webview. Used internally
        'Project generator', // Title of the panel displayed to the user
        vscode.ViewColumn.One, // Editor column to show the new webview panel in.
        {
          enableScripts: true
        }
      )

      // eslint-disable-next-line no-use-before-define
      const bundleScript = buildScriptsUri(context, 'bundle.js')
      const vendorScripts = buildScriptsUri(context, 'vendor.js')
      panel.webview.html = webViewBuilder(bundleScript, vendorScripts)
      // Display a message box to the user
      // vscode.window.showInformationMessage('Hello World!')
    }
  )

  context.subscriptions.push(disposable)
}

exports.activate = activate

// this method is called when your extension is deactivated
function deactivate() {}

module.exports = {
  activate,
  deactivate
}
