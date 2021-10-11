// Source: https://hackmd.io/@Heidi-Liu/note-be201-express-node#%E5%9C%A8-Nodejs-%E4%B8%8A%E5%AF%A6%E4%BD%9C-MVC-%E6%9E%B6%E6%A7%8B
// Start with "nodemon index.js"

const port = 5002;
const express = require('express');
const app = express();
const db = require('./db')
const tagController = require('./controllers/tag')

// Middleware
app.use(express.urlencoded({ extender: true }))

app.set('view engine', 'ejs')

app.post('/', tagController.add)

app.get('/', (req, res) => {
  res.render('hello')
})

app.get('/tags', tagController.getAll)
app.get('/tags/:id', tagController.get)

app.listen(port, () => {
  db.connect()
  console.log(`Example app listening at http://localhost:${port}`)
})
