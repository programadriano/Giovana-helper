'use strict';

const mongoose = require('mongoose');
const Schema = mongoose.Schema;

const schema = new Schema({

    Name: {
        type: String
    },
    Status: {
        type: String
    },
    DtUpdate: {
        type: Date
    }
});

module.exports = mongoose.model('Machine', schema);