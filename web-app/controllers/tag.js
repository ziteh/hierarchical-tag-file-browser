const tagModel = require('../models/tag')

const tagController = {
  getAll: (req, res) => {
    tagModel.getAll((err, results) => {
      if (err) return console.log(err);
      res.render('tags', {
        tags: results
      })
    })
  },

  get: (req, res) => {
    const id = req.params.id
    tagModel.get(id, (err, results) => {
      if (err) return console.log(err);
      res.render('tag', {
        tag: results[0]
      })
    })
  }
}

module.exports = tagController