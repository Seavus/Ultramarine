var path = require('path') // eslint-disable-line

module.exports = {
  mode: 'production',
  entry: './src/index',
  devtool: 'source-maps',
  //   resolve: {
  //     alias: { '~': path.resolve(__dirname) }
  //   },
  output: {
    filename: 'bundle.js',
    path: path.join(__dirname, './build/'),
    publicPath: '/'
  },
  module: {
    rules: [
      {
        test: /\.js$/,
        loader: 'eslint-loader',
        exclude: /node_modules/,
        enforce: 'pre'
      },
      {
        test: /\.jsx?$/,
        loader: 'babel-loader',
        exclude: /node_modules/
      },
      {
        test: /\.(css|scss)$/,
        use: ['style-loader', 'css-loader', 'sass-loader']
      },
      { test: /\.(?:ico|gif|png|jpg|jpeg|webp)$/, use: 'url-loader' }
    ]
  },
  optimization: {
    splitChunks: {
      chunks: 'async',
      minSize: 30000,
      minChunks: 1,
      maxAsyncRequests: 5,
      maxInitialRequests: 3,
      name: true,
      cacheGroups: {
        vendors: {
          chunks: 'all',
          test: /[\\/]node_modules[\\/]/,
          name: 'vendor',
          filename: 'vendor.js',
          priority: -10
        }
      }
    }
  },
  plugins: [
    // new webpack.optimize.OccurrenceOrderPlugin(),
    // new webpack.optimization.splitChunks({ // eslint-disable-line
    //     name: 'vendor',
    //     filename: 'vendor.js',
    //     minChunks: module => (
    //         // this assumes your vendor imports exist in the node_modules directory
    //         module.context && module.context.indexOf('node_modules') !== -1
    //     )
    // }),
    // new webpack.optimize.UglifyJsPlugin({
    //     sourceMap: true,
    //     comments: false
    // }),
    // new webpack.DefinePlugin({
    //     'proces.env': {
    //         NODE_ENV: JSON.stringify('production')
    //     }
    // })
  ]
}
