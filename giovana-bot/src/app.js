const mongoose = require('mongoose');
const connector = require('./connector');



//mongoose.connect('mongodb://localhost:27017/Machine', { useMongoClient: true });

//const Machine = mongoose.model('Machine');
//const repository = require('../repositories/machine-repository')


// Receive messages from the user and respond by echoing each message back (prefixed with 'You said:')
var bot = new builder.UniversalBot(connector, function (session) {
    session.send("Hi " + session.message.user.name);

   // session.send("You said: %s", session.message.text);

    // repository.get()
    //     .then(data => {
    //         res.status(200).send({ data });
    //     }).catch(e => {
    //         res.status(400).send({ message: 'error', data: e });
    //     });

});



