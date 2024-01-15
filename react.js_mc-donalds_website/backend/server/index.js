const express = require("express");
const apiRoutes = require("./apiRoutes");

const PORT = process.env.PORT || 3001;
const app = express();

app.use(apiRoutes);

app.listen(PORT, () => {
    console.log(`Server listening on ${PORT}`);
});
