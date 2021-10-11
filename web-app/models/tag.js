const db = require('../db')

const tagModel = {
  getAll: (cb) => {
    db.query(
      'SELECT * FROM tags', (err, results) => {
        if (err) return cb(err);
        cb(null, results);
      }
    )
  },

  get: (id, cb) => {
    db.query(
      'SELECT * FROM tags WHERE id = ?', [id], (err, results) => {
        if (err) return cb(err);
        cb(null, results);
      }
    )
  },

  getChildTags: (id, cb) => {
    db.query(
      'SELECT * FROM tags INNER JOIN tag_relation ON tag_relation.child_tag_id = tags.id WHERE tag_relation.parent_tag_id = ?', [id], (err, results) => {
        if (err) return cb(err);
        cb(null, results);
      }
    )
  },

  getChildFiles: (id, cb) => {
    db.query(
      'SELECT * FROM files INNER JOIN file_relation ON file_relation.child_file_id = files.id WHERE file_relation.parent_tag_id = ?', [id], (err, results) => {
        if (err) return cb(err);
        cb(null, results);
      }
    )
  },

  add: (tag, cb) => {
    tag.type = tag.type || 1; // tag type 1: general.
    tag.alias = tag.alias || null;
    tag.remark = tag.remark || null;
    tag.thumbnallPath = tag.thumbnallPath || null;
    tag.fontColor = tag.fontColor || null;
    tag.backColor = tag.backColor || null;

    db.query(
      'INSERT INTO `tags` (`id`, `name`, `type`, `alias`, `remark`, `thumbnail_path`, `font_color`, `back_color`) VALUES (NULL, ?, ?, ?, ?, ?, ?, ?)',
      [tag.name,
      tag.type,
      tag.alias,
      tag.remark,
      tag.thumbnallPath,
      tag.fontColor,
      tag.backColor],
      (err, results) => {
        if (err) return cb(err);
        cb(null, results);
      }
    )
  }
}

module.exports = tagModel