import React, { Component } from 'react'
import { hot } from 'react-hot-loader'
import './App.css'
import { Navbar } from './vivaldi'
import Configuration from './vivaldi/components/configuration'

class App extends Component {
  constructor(props) {
    super(props)
    this.state = {
      configuration: undefined
    }
  }

  handleFileRead = e => {
    const content = e.target.result
    const generatorContent = JSON.parse(content)

    this.setState({ configuration: generatorContent })
  }

  handleFileChoosen = e => {
    const fileReader = new FileReader()
    fileReader.onload = this.handleFileRead
    fileReader.readAsText(e.target.files[0])
  }

  render() {
    const { configuration } = this.state
    return (
      <div>
        <Navbar handleFileChoosen={this.handleFileChoosen} />
        <Configuration settings={configuration} />
      </div>
    )
  }
}

export default hot(module)(App)
