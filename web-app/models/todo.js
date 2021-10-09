const db = require('../db')

// 建立一個 todoModel 物件，裡面放存取資料的方法（function）
const todoModel = {
  getAll: (cb) => {
    db.query(
      'SELECT * FROM todos', (err, results) => {
        if(err) return cb(err);
        cb(null, results)
      }
    )
  },
  
  get: (id, cb) => {
    db.query(
      'SELECT * FROM todos WHERE id = ?', [id], (err, results) => {
        if (err) return cb(err)
        cb(null, results)
      }
    )
  }
}

module.exports = todoModel