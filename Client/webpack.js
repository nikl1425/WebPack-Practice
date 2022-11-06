const HtmlWebpackPlugin = require("html-webpack-plugin");



const prod = process.env.NODE_ENV === "production";

module.exports = {
    mode: prod ? "production" : "development",
    entry: "./src/index.tsx",
    output: {
        path: "dist/bundle"
    }
}