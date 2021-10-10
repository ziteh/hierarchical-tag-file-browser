const db = require('../db')

const tagModel = {
  getAll: (cb) => {
    db.query(
      'SELECT * FROM tags', (err, results) => {
        if (err) return cb(err);
        cb(null, results)
      }
    )
  },

  get: (id, cb) => {
    db.query(
      'SELECT * FROM tags WHERE id = ?', [id], (err, results) => {
        if (err) return cb(err);
        cb(null, results)
      }
    )
  },

  getChildTagsId: (id, cb) => {
    db.query(
      'SELECT * FROM tag_relation WHERE parent_tag_id = ?', [id], (err, results) => {
        if (err) return cb(err);
        cb(null, results)
      }
    )
  }
}

module.exports = tagModel