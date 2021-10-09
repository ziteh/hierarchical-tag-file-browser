// 先從 model 引入 todos 資料
const todoModel = require('../models/todo')

// 建立一個 todoController 物件，透過方法來存取 model 的資料
const todoController = {
  // 傳入參數 req, res
  getAll: (req, res) => {
    todoModel.getAll((err, results) => {
      if (err) return console.log(err);
      res.render('todos', {
        todos: results
      })
    })
  },

  get: (req, res) => {
    const id = req.params.id
    todoModel.get(id, (err, results) => {
      if (err) return console.log(err);
      res.render('todo', {
        todo: results[0]
      })
    })
  }
}

module.exports = todoController