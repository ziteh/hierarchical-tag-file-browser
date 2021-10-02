// app.js
// import modules
const express = require('express')
const app = express()
const port = 3000
const exphbs = require('express-handlebars')

// setting template engine
app.engine('handlebars', exphbs('defaultLayout: main'))
app.set('view engine', 'handlebars')
app.use(express.static('public'))

// route setting
app.get('/', (req, res) => {
  // res.send('This is my first Express app')
  res.render('index')
})

// create server
app.listen(port, () => {
  console.log(`server listen to http://localhost:${port}`)
})