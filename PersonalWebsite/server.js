const express = require('express');
const path = require('path');
const app = express();
const port = process.env.PORT || 8080;


app.use(express.static(path.join(__dirname, 'public')));
app.set('views', path.join(__dirname, '/views'));


app.get('/', function(req, res) {
  res.sendFile(path.join(__dirname, 'views/index.html'));
});

app.get('/code', function(req, res) {
  res.sendFile(path.join(__dirname,'views/code.html'));
});

app.get('/videoediting', function(req, res) {
  res.sendFile(path.join(__dirname,'views/ve.html'));
});

app.listen(port);
console.log('Server started at http://localhost:' + port);