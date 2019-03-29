import React from 'react'
import { hot } from 'react-hot-loader'
import './App.css'
import Composer from './vivaldi'

const App = () => (
  <div>
    <span>web</span>
    <Composer />
  </div>
)

export default hot(module)(App)
