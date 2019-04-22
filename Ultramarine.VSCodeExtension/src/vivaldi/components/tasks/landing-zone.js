import React, { Component } from 'react'

class LandingZone extends Component {
  handleTaskLanded = () => {}

  allowDragOver = e => {
    e.preventDefault()
  }

  render() {
    return (
      <div
        className="card z-depth-0 x-small task-landing-zone"
        onDrop={this.handleTaskLanded}
        onDragOver={this.allowDragOver}
      >
        <div className="card-content">
          <p className="note center">You may drop a task here.</p>
        </div>
      </div>
    )
  }
}

export default LandingZone
