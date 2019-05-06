import React, { Component } from 'react'
import { hot } from 'react-hot-loader'
import './App.css'
import Configuration from './vivaldi'

class App extends Component {
  constructor(props) {
    super(props)
    this.state = {
      configuration: undefined
    }

    console.log('constructed')
  }

  componentDidMount() {
    window.addEventListener('message', this.handleFileOpen)
  }

  componentWillUnmount() {
    window.removeEventListener('message', this.handleFileOpen)
  }

  handleFileOpen = event => {
    const { generator } = event.data
    if (!generator) return

    this.setState({ configuration: generator })
  }

  render() {
    const { configuration } = this.state
    return <Configuration settings={configuration} />
  }
}

export default hot(module)(App)
