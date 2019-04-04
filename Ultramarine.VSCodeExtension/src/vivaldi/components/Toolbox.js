import React from 'react'
import PropTypes from 'prop-types'

const handleDragStart = (e, t) => {
  e.dataTransfer.setData('taskType', t.type)
}

const Toolbox = props => {
  const { taskTypes, onTaskLanded, onLandingCheck } = props

  return (
    <div className="toolbox">
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
                // eslint-disable-next-line jsx-a11y/click-events-have-key-events, jsx-a11y/interactive-supports-focus
                <div
                  className="d-ib plr-small"
                  key={type.abbr}
                  role="button"
                  draggable
                  onClick={() => onTaskLanded(type.type)}
                  onDragStart={e => {
                    handleDragStart(e, type)
                  }}
                  onDragEnd={onLandingCheck}
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
  taskTypes: PropTypes.arrayOf(PropTypes.any),
  onTaskLanded: PropTypes.func,
  onLandingCheck: PropTypes.func
}

Toolbox.defaultProps = {
  taskTypes: [],
  onTaskLanded: () => {},
  onLandingCheck: () => {}
}

export default Toolbox
