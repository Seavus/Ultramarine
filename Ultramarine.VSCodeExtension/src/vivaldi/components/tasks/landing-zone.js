import React, { Component } from 'react'
import PropTypes from 'prop-types'

class LandingZone extends Component {
  handleTaskLanded = e => {
    const type = e.dataTransfer.getData('taskType')
    const { onTaskLanded, name } = this.props
    onTaskLanded(this, name, type)
  }

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

LandingZone.propTypes = {
  name: PropTypes.string.isRequired,
  onTaskLanded: PropTypes.func.isRequired
}

export default LandingZone
