import React, { Component } from 'react'
import PropTypes from 'prop-types'
import ToolboxItem from './toolbox-item'

const Toolbox = ({ tasks, onTaskClicked, onTaskLanded }) => (
  <div className="toolbox">
    <div className="card z-depth-0">
      <div className="card-content">
        <span className="card-title">Toolbox</span>
        <div className="container" />
        {tasks.map(task => (
          <ToolboxItem
            {...task}
            onClick={onTaskClicked}
            onDragEnd={onTaskLanded}
          />
        ))}
      </div>
    </div>
  </div>
)

Toolbox.propTypes = {
  tasks: PropTypes.array.isRequired,
  onTaskClicked: PropTypes.func.isRequired,
  onTaskLanded: PropTypes.func.isRequired
}

export default Toolbox
