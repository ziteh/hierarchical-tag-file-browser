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
    var thisTag
    var childTags
    tagModel.get(id, (err, results) => {
      if (err) return console.log(err);
      thisTag = results[0]
    })
    tagModel.getChildTags(id, (err, results) => {
      if (err) return console.log(err);
      childTags = results
      res.render('tag', {
        tag: thisTag,
        childTags
      })
    })
  }}

module.exports = tagController