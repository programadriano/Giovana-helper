'use strict'

const mongoose = require('mongoose');
require('../models/machine.js');
const Machine = mongoose.model('Machine');

exports.getAll = () => {

   let m = new Machine();
   m.Name = "teste";
   m.save();


    return Machine.find({})
}





