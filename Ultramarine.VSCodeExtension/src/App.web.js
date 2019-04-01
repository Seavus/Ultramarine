import React from 'react'
import { hot } from 'react-hot-loader'
import './App.css'
import Composer, { Toolbar } from './vivaldi'

const App = () => (
  <div>
    {/* <Toolbar /> */}
    <Composer />
  </div>
)

export default hot(module)(App)
