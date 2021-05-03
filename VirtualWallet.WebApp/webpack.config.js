var path = require("path");

module.exports = {
    entry: {
        test : "./Scripts/TestJsx.jsx"
        },
    output: {
        filename: "[name]-bundle.js", //zostaną nam wygenerowane pliki out-home.js i out-app.js
        path: path.resolve(__dirname, "./wwwroot/js")
    },
    mode: "development",
    devtool: "source-map",
    module: {
        rules: [
            {
                test: /\.(js|jsx)$/,
                exclude: /(node_modules|bower_components)/,
                use: {
                    loader: 'babel-loader',
                    options: {
                        presets: ["@babel/preset-env", "@babel/preset-react", { //for syntax issue
                            'plugins': ['@babel/plugin-proposal-class-properties'] // for = () => syntax
                        }] 
                    }
                }
            }
        ]
    }
};