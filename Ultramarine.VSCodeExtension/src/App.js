import React from 'react'
import { hot } from 'react-hot-loader'
import './App.css'
import Composer, { Task } from './vivaldi'

const app = () => (
  <div>
    <p>Hello Bozidar !!111 </p>
    <Composer />
  </div>
)

export default hot(module)(app)
