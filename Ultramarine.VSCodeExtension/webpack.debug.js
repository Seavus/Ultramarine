var path = require('path') // eslint-disable-line
var webpack = require('webpack') // eslint-disable-line

module.exports = {
  mode: 'development',
  devtool: 'cheap-module-eval-source-map',
  resolve: {
    alias: { '~': path.resolve(__dirname) }
  },
  entry: {
    app: [
      'webpack-dev-server/client?http://localhost:64825/',
      'webpack/hot/only-dev-server',
      './src/index.js'
    ]
  },
  output: {
    path: path.resolve(__dirname, 'build'),
    filename: 'bundle.js',
    publicPath: 'http://localhost:64825/assets/'
  },
  devServer: {
    port: 64825,
    hot: true,
    headers: { 'Access-Control-Allow-Origin': '*' },
    contentBase: './src',
    disableHostCheck: true
  },

  plugins: [
    new webpack.NamedModulesPlugin(),
    new webpack.optimize.OccurrenceOrderPlugin(true),
    new webpack.HotModuleReplacementPlugin()
  ],
  module: {
    rules: [
      {
        test: /\.js$/,
        loader: 'eslint-loader',
        exclude: /node_modules/,
        enforce: 'pre'
      },
      { test: /\.js$/, loader: 'babel-loader', exclude: /node_modules/ },
      {
        test: /\.(css|scss)$/,
        use: ['style-loader', 'css-loader', 'sass-loader']
      },
      { test: /\.(?:ico|gif|png|jpg|jpeg|webp)$/, use: 'url-loader' }
    ]
  }
}
