var restify = require('restify');
var builder = require('botbuilder');
const mongoose = require('mongoose');




const repository = require('../src/repositories/machine-repository')


mongoose.connect('mongodb://localhost:27017/Manager', { useMongoClient: true });

// Setup Restify Server
var server = restify.createServer();
server.listen(process.env.port || process.env.PORT || 3978, function () {
    console.log('%s listening to %s', server.name, server.url);
});

// Create chat connector for communicating with the Bot Framework Service
var connector = new builder.ChatConnector({
    appId: "df633514-6de2-49ba-89a4-9adb1fcb85f3",
    appPassword: "aGgxFcWsiphhJd267T4qg5w"
});

// Listen for messages from users 
server.post('/api/messages', connector.listen());

// Receive messages from the user and respond by echoing each message back (prefixed with 'You said:')
var bot = new builder.UniversalBot(connector, function (session) {
    session.send("Hi " + session.message.user.name);

    session.send("You said: %s", session.message.text);

    repository.getAll()
        .then(data => {
            //  res.status(200).send({ data });
            session.send("You said: %s", data);
            //  console.log("TESTE TESTE TESTE")
            console.log("data:", data)
        }).catch(e => {
            //res.status(400).send({ message: 'error', data: e });
        });


});

