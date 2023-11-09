/** @type {import('tailwindcss').Config} */
module.exports = {
  content: ["../**/*.{razor,cshtml,html}", "./node_modules/flowbite/**/*.js"],
  darkMode: "class",
  theme: {
    extend: {},
  },
  plugins: [require("flowbite/plugin")],
};
