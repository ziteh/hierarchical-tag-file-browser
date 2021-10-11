const { getChildFiles } = require('../models/tag');
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
    var childFiles
    tagModel.get(id, (err, results) => {
      if (err) return console.log(err);
      thisTag = results[0]
    });
    tagModel.getChildTags(id, (err, results) => {
      if (err) return console.log(err);
      childTags = results
    });
    tagModel.getChildFiles(id, (err, results) => {
      if (err) return console.log(err);
      childFiles = results

      res.render('tag', {
        tag: thisTag,
        childTags,
        childFiles
      })
    });
  },

  add: (req, res) => {
    var name = req.body.name;
    var type = req.body.type;

    console.log(name + type);

    tagModel.add(name, type, (err, results) => {
      if (err) return console.log(err);
      res.redirect('/');
    })

  }
}

module.exports = tagController