const path = require("path");

const fileName = `${path.basename(path.dirname(__filename)) }.js`;

module.exports = {
    experiments: {
        outputModule: true,
    },
    module: {
        rules: [
            {
                test: /\.(js|jsx)$/,
                exclude: /node_modules/,
                use: {
                    loader: "babel-loader"
                }
            }
        ]
    },
    output: {
        path: path.resolve(__dirname, './wwwroot'),
        filename: fileName,
        library: {
            type: "module",
        },
    }
};
