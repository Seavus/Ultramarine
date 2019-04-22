import React from 'react'
import PropTypes from 'prop-types'

const Task = ({ name, description, children }) => (
  <div className="card z-depth-0">
    <div className="card-content">
      <span className="card-title">{name}</span>
      <p className="mb-small">{description}</p>
      {children}
    </div>
  </div>
)

Task.propTypes = {
  name: PropTypes.string.isRequired,
  description: PropTypes.string,
  children: PropTypes.oneOfType([
    PropTypes.arrayOf(PropTypes.node),
    PropTypes.node
  ])
}

Task.defaultProps = {
  description: '',
  children: null
}

export default Task
