const path = require('path');
const webpack = require('webpack');
const ExtractTextPlugin = require('extract-text-webpack-plugin');
const extractCSS = new ExtractTextPlugin('bundle.css');

module.exports = {
    entry: {
        'main': './wwwroot/javascripts/index.js'
    },
    output: {
        path: path.resolve(__dirname, 'wwwroot/dist'),
        filename: 'bundle.js',
        publicPath: 'dist/'
    },
    plugins: [
        extractCSS,
        // new webpack.ProvidePlugin({
        //     $: 'jquery',
        //     jQuery: 'jquery',
        //     'window.jQuery': 'jquery',
        // }),
        new webpack.DefinePlugin({
            'process.env.NODE_ENV': JSON.stringify('development')
        }),
    ],
    module: {
        rules: [
        {
            test: /\.scss$/,
            exclude: /(node_modules|bower_components|lib)/,
            include: [
                path.resolve(__dirname, "wwwroot/stylesheets"),
            ],
            loader: 'style-loader!css-loader!sass-loader'
        }, 
        {
            test: /\.js?$/,
            exclude: /(node_modules|bower_components|lib)/,
            include: [
                path.resolve(__dirname, "wwwroot/javascripts"),
            ],
            use: {
                loader: 'babel-loader',
                options: {
                    presets: ['@babel/preset-react', '@babel/preset-env']
                }
            }
        }, ]
    }
};