const express = require('express');
const connectDB = require('./config/db');
var bodyParser = require('body-parser');
const path = require('path');
const app = express();
var cors = require('cors')
//Connect to database
connectDB();

app.use(cors())
app.use (express.json({extented: false}));
app.use(bodyParser.urlencoded({ extended: false }))
app.use(bodyParser.json());

//Define Routes
app.use('/', require('./routes/index'));
app.use('/api/url', require('./routes/url'));


app.get('/', function(req, res) {
    res.sendFile(path.join(__dirname, 'views/index.html'));
});

app.listen(process.env.PORT || 5000, () => console.log('Server running'));
