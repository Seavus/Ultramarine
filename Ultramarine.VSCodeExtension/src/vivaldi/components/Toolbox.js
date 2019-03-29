import React from 'react'
import PropTypes from 'prop-types'

const handleDragStart = (e, t) => {
  e.dataTransfer.setData('taskType', t.type)
}

const Toolbox = props => {
  const { taskTypes } = props
  return (
    <div className="toolbar">
      <div className="card z-depth-0">
        <div className="card-content">
          <span className="card-title">Toolbox</span>
          <div className="container">
            {taskTypes.map(type => {
              const icon = type.icon ? (
                <i
                  className="material-icons tooltipped"
                  data-tooltip={type.name}
                >
                  {type.icon}
                </i>
              ) : (
                <span className="tooltipped" data-tooltip={type.name}>
                  {type.abbr}
                </span>
              )
              return (
                <div
                  className="d-ib plr-small"
                  draggable
                  key={type.abbr}
                  onDragStart={e => {
                    handleDragStart(e, type)
                  }}
                >
                  {icon}
                </div>
              )
            })}
          </div>
        </div>
      </div>
    </div>
  )
}

Toolbox.propTypes = {
  taskTypes: PropTypes.arrayOf(PropTypes.any)
}

Toolbox.defaultProps = {
  taskTypes: []
}

export default Toolbox
