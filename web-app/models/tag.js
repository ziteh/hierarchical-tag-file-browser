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

  getChildTags: (id, cb) => {
    db.query(
      'SELECT * FROM tags INNER JOIN tag_relation ON tag_relation.child_tag_id = tags.id WHERE tag_relation.parent_tag_id = ?', [id], (err, results) => {
        if (err) return cb(err);
        cb(null, results)
      }
    )
  }
}

module.exports = tagModel