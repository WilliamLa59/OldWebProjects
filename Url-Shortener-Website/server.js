const express = require('express');
const cors = require('cors');
const app = express();
var bodyParser = require('body-parser');
const mongoose = require('mongoose');
const path = require('path');

app.use(express.urlencoded({ extended: false }))
app.use("/static", express.static('./static/'));
app.use(cors());
app.use(express.json());
app.use(bodyParser.urlencoded({ extended: false }))
app.use(bodyParser.json());

app.get('/', function(req, res) {
    res.sendFile(path.join(__dirname, 'views/index.html'));
});

app.post('/shorten', (req, res) => {
    console.log(req);
});

app.listen(process.env.PORT || 5000);