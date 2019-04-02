import React, { Component } from 'react'
import { hot } from 'react-hot-loader'
import './App.css'
import Composer, { Navbar } from './vivaldi'

class App extends Component {
  state = {}

  handleFileRead = e => {
    const content = e.target.result
    const generatorContent = JSON.parse(content)
    window.postMessage({ generator: generatorContent })
  }

  handleFileChoosen = e => {
    const fileReader = new FileReader()
    fileReader.onload = this.handleFileRead
    fileReader.readAsText(e.target.files[0])
  }

  render() {
    const { tasks } = this.state
    return (
      <div>
        <Navbar handleFileChoosen={this.handleFileChoosen} />
        <Composer />
      </div>
    )
  }
}

export default hot(module)(App)
