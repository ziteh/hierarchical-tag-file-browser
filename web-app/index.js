// Source: https://hackmd.io/@Heidi-Liu/note-be201-express-node#%E5%9C%A8-Nodejs-%E4%B8%8A%E5%AF%A6%E4%BD%9C-MVC-%E6%9E%B6%E6%A7%8B
// Start with "nodemon app.js"

const express = require('express');
const app = express();
const db = require('./db')
const port = 5002;

// 引入 controller
const todoController = require('./controllers/todo')

app.set('view engine', 'ejs')

app.get('/', (req, res) =>{
  // 叫 express 去 render views 底下叫做 hello 的檔案，副檔名可省略
  res.render('hello')
})

// 可直接使用 controller 的方法拿取資料和進行 render
app.get('/todos', todoController.getAll)
app.get('/todos/:id', todoController.get)

app.listen(port, () => {
  db.connect()
  console.log(`Example app listening at http://localhost:${port}`)
})
